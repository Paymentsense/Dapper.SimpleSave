using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Dapper.SimpleSave.Impl;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests {
    public abstract class BaseTests {

        protected IEnumerable<BaseCommand> GetCommands<T>(
            DtoMetadataCache cache,
            T oldDto,
            T newDto,
            int expectedDifferenceCount,
            int expectedOperationCount,
            int expectedInsertOperations,
            int expectedUpdateOperations,
            int expectedDeleteOperations,
            int expectedCommandCount,
            int expectedInsertCommands,
            int expectedUpdateCommands,
            int expectedDeleteCommands) {
            var differ = new Differ(cache);
            var differences = differ.Diff(oldDto, newDto);

            Assert.AreEqual(expectedDifferenceCount, differences.Count(), "Unexpected number of differences.");

            var operationBuilder = new OperationBuilder();
            var operations = operationBuilder.Build(differences);

            var commandBuilder = new CommandBuilder();
            var commands = commandBuilder.Coalesce(operations);

            Assert.AreEqual(expectedOperationCount, operations.Count(), "Unexpected number of operations.");
            var counts = CountItemsByType(operations);
            CheckCount(counts, typeof(InsertOperation), expectedInsertOperations);
            CheckCount(counts, typeof(UpdateOperation), expectedUpdateOperations);
            CheckCount(counts, typeof(DeleteOperation), expectedDeleteOperations);

            Assert.AreEqual(expectedCommandCount, commands.Count(), "Unexpected number of commands.");
            counts = CountItemsByType(commands);
            CheckCount(counts, typeof(InsertCommand), expectedInsertCommands);
            CheckCount(counts, typeof(UpdateCommand), expectedUpdateCommands);
            CheckCount(counts, typeof(DeleteCommand), expectedDeleteCommands);

            var scriptBuilder = new ScriptBuilder(cache);
            var transactionScript = scriptBuilder.Build(commands);

            Assert.IsNotNull(transactionScript, "#badtimes - null transaction script");
            Assert.IsTrue(transactionScript.Count > 0, "Should be at least one script.");
            foreach (var script in transactionScript) {
                Assert.IsTrue(script.Buffer.Length > 0, "#badtimes - empty transaction script");
            }

            CheckNoReferenceTypesInParameters(transactionScript);

            return commands;
        }

        protected void CheckCount(IDictionary<Type, int> counts, Type type, int expectedCount) {
            Assert.AreEqual(
                expectedCount,
                counts.ContainsKey(type) ? counts [type] : 0,
                string.Format("Unexpected count for {0}", type));
        }

        protected IDictionary<Type, int> CountItemsByType(IEnumerable items) {
            var results = new Dictionary<Type, int>();
            foreach (var item in items) {
                Type type = item.GetType();
                results [type] = results.ContainsKey(type) ? results [type] + 1 : 1;
            }
            return results;
        }

        protected void CheckNoReferenceTypesInParameters(IList<Script> transactionScript) {
            foreach (var script in transactionScript) {
                foreach (var name in script.Parameters.Keys) {
                    var value = script.Parameters [name];
                    if (null == value || value is string) {
                        continue;
                    }

                    var type = value.GetType();
                    if (type.IsValueType
                        || (type.IsConstructedGenericType
                            && type.GetGenericTypeDefinition() == typeof(Func<>))) {
                        continue;
                    }

                    Assert.Fail("Unexpected reference type as value for parameter {0}: {1}", name, type.FullName);
                }
            }
        }
    }
}
