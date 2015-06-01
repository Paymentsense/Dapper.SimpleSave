using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.SimpleSave.Impl;
using Dapper.SimpleSave.Tests.Dto;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests {

    [TestFixture]
    public class ManyToManyRelationshipCommandGenerationTests : BaseTests {


        private IEnumerable<BaseCommand> GetCommands<T>(
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
            int expectedDeleteCommands)
        {
            var differ = new Differ(cache);
            var differences = differ.Diff(oldDto, newDto);

            Assert.AreEqual(expectedDifferenceCount, differences.Count(), "Unexpected number of differences.");

            var operationBuilder = new OperationBuilder();
            var operations = operationBuilder.Build(differences);
            var commands = operationBuilder.Coalesce(operations);

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

        private void insert_inserts_in_parent_and_link(ParentDto newDto, string manyToManyPropertyName)
        {
            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, null, newDto, 2, 2, 2, 0, 0, 2, 2, 0, 0);
            var list = new List<BaseCommand>(commands);
            var command = list [0] as InsertCommand;
            Assert.AreEqual(cache.GetMetadataFor(typeof(ParentDto)).TableName, command.Operation.ValueMetadata.TableName, "Unexpected table name");
            command = list [1] as InsertCommand;
            Assert.AreEqual(
                cache.GetMetadataFor(typeof(ParentDto)).Properties.Where(p => p.ColumnName == manyToManyPropertyName).FirstOrDefault().GetAttribute<ManyToManyAttribute>().LinkTableName,
                command.Operation.OwnerPropertyMetadata.GetAttribute<ManyToManyAttribute>().LinkTableName, "Unexpected table name");
        }

        [Test]
        public void insert_with_no_reference_data_inserts_in_parent_and_link_table()
        {
            var newDto = new ParentDto
            {
                ManyToManyChildDto = new ManyToManyChildDto()
            };

            insert_inserts_in_parent_and_link(newDto, "ManyToManyChildDto");
        }

        [Test]
        public void update_with_no_reference_data_updates_parent_and_child() {
            var oldDto = new ParentDto {
                ParentKey = 1,
                ManyToManyChildDto = new ManyToManyChildDto()
            };

            var newDto = new ParentDto {
                ParentKey = 1,
                ParentName = "Wibble",
                ManyToManyChildDto = new ManyToManyChildDto
                {
                    Name = "Wobble"
                }
            };

            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, oldDto, newDto, 2, 2, 0, 2, 0, 2, 0, 2, 0);
            var list = new List<BaseCommand>(commands);

            //  TODO: check commands
        }

        [Test]
        public void delete_with_no_reference_data_deletes_from_link_table_and_parent() {
            throw new NotImplementedException();
        }

        [Test]
        public void insert_with_reference_data_in_child_inserts_in_parent_and_link_table() {
            var newDto = new ParentDto {
                ManyToManyReferenceChildDto = new ManyToManyReferenceChildDto()
            };

            insert_inserts_in_parent_and_link(newDto, "ManyToManyReferenceChildDto");
        }

        [Test]
        public void update_with_reference_data_in_child_updates_parent() {
            var oldDto = new ParentDto {
                ParentKey = 1,
                ManyToManyReferenceChildDto = new ManyToManyReferenceChildDto()
            };

            var newDto = new ParentDto {
                ParentKey = 1,
                ParentName = "Wibble",
                ManyToManyReferenceChildDto = new ManyToManyReferenceChildDto()
                {
                    Name = "Wobble"
                }
            };

            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, oldDto, newDto, 2, 2, 0, 2, 0, 1, 0, 1, 0);
            var list = new List<BaseCommand>(commands);
        }

        [Test]
        public void delete_with_reference_data_in_child_deletes_from_link_table_and_parent() {
            throw new NotImplementedException();
        }

        [Test]
        public void insert_with_special_data_in_child_inserts_in_parent_and_link_table() {
            var newDto = new ParentDto {
                ManyToManySpecialChildDto = new ManyToManySpecialChildDto()
            };

            insert_inserts_in_parent_and_link(newDto, "ManyToManySpecialChildDto");
        }

        [Test]
        public void update_with_special_data_in_child_updates_parent() {
            var oldDto = new ParentDto {
                ParentKey = 1,
                ManyToManySpecialChildDto = new ManyToManySpecialChildDto()
            };

            var newDto = new ParentDto {
                ParentKey = 1,
                ParentName = "Wibble",
                ManyToManySpecialChildDto = new ManyToManySpecialChildDto() {
                    Name = "Wobble"
                }
            };

            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, oldDto, newDto, 2, 2, 0, 2, 0, 1, 0, 1, 0);
            var list = new List<BaseCommand>(commands);
        }

        [Test]
        public void delete_with_special_data_in_child_deletes_from_link_table_and_parent() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void insert_with_reference_data_in_parent_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void update_with_reference_data_in_parent_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void delete_with_reference_data_in_child_parent_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void insert_with_reference_data_in_parent_and_child_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void update_with_reference_data_in_parent_and_child_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void delete_with_reference_data_in_child_parent_and_child_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void insert_with_special_data_in_parent_and_reference_data_in_child_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void update_with_special_data_in_parent_and_reference_data_in_child_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void delete_with_special_data_in_parent_and_reference_data_in_child_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void insert_with_special_data_in_parent_and_child_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void update_with_special_data_in_parent_and_child_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void delete_with_special_data_in_child_parent_and_child_is_not_supported() {
            throw new NotImplementedException();
        }
    }
}
