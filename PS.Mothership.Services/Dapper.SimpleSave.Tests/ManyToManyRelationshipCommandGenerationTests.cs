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
        public void update_with_no_reference_data_updates_child_and_parent() {
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

            var command = list[0] as UpdateCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(ManyToManyChildDto)).TableName,
                command.TableName,
                "Unexpected table name.");

            Assert.AreEqual(
                "Name",
                command.Operations.FirstOrDefault().OwnerPropertyMetadata.ColumnName,
                "Unexpected column name.");

            command = list[1] as UpdateCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(ParentDto)).TableName,
                command.TableName,
                "Unexpected table name.");

            Assert.AreEqual(
                "ParentName",
                command.Operations.FirstOrDefault().OwnerPropertyMetadata.ColumnName);
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
        [ExpectedException(typeof(InvalidOperationException))]
        public void update_parent_and_child_with_reference_data_in_child_is_invalid() {
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
            GetCommands(cache, oldDto, newDto, 2, 2, 0, 2, 0, 1, 0, 1, 0);
        }

        [Test]
        public void update_parent_with_reference_data_in_child_updates_parent_only()
        {
            var oldDto = new ParentDto {
                ParentKey = 1,
                ManyToManyReferenceChildDto = new ManyToManyReferenceChildDto()
            };

            var newDto = new ParentDto {
                ParentKey = 1,
                ParentName = "Wibble",
                ManyToManyReferenceChildDto = new ManyToManyReferenceChildDto() {}
            };

            update_updates_parent_only(oldDto, newDto);
        }

        private void update_updates_parent_only(ParentDto oldDto, ParentDto newDto)
        {
            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, oldDto, newDto, 1, 1, 0, 1, 0, 1, 0, 1, 0);
            var list = new List<BaseCommand>(commands);
            var command = list [0] as UpdateCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(ParentDto)).TableName,
                command.TableName,
                "Unexpected table name.");

            Assert.AreEqual(
                1,
                command.Operations.Count(),
                "Unexpected number of operations.");

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(ParentDto)).Properties.Where(p => p.ColumnName == "ParentName").FirstOrDefault().ColumnName,
                command.Operations.FirstOrDefault().ColumnName,
                "Unexpected column name.");
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
        [ExpectedException(typeof(InvalidOperationException))]
        public void update_parent_and_non_fk_column_in_child_with_special_data_in_child_is_invalid() {
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
            GetCommands(cache, oldDto, newDto, 2, 2, 0, 2, 0, 1, 0, 1, 0);
        }

        [Test]
        public void update_parent_with_special_data_in_child_updates_parent()
        {
            var oldDto = new ParentDto {
                ParentKey = 1,
                ManyToManySpecialChildDto = new ManyToManySpecialChildDto()
            };

            var newDto = new ParentDto {
                ParentKey = 1,
                ParentName = "Wibble",
                ManyToManySpecialChildDto = new ManyToManySpecialChildDto()
            };

            update_updates_parent_only(oldDto, newDto);
        }

        [Test]
        public void delete_with_special_data_in_child_deletes_from_link_table_and_parent() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_reference_data_in_parent_is_invalid() {
            var newDto = new ParentReferenceDto() {
                ManyToManyChildDto = new ManyToManyChildDto()
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, null, newDto, 2, 2, 2, 0, 0, 2, 2, 0, 0);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void update_with_reference_data_in_parent_is_invalid() {
            var oldDto = new ParentReferenceDto {
                ParentKey = 1,
                ManyToManyChildDto = new ManyToManyChildDto()
            };

            var newDto = new ParentReferenceDto {
                ParentKey = 1,
                ParentName = "Wibble",
                ManyToManyChildDto = new ManyToManyChildDto()
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, oldDto, newDto, 1, 1, 0, 1, 0, 1, 0, 1, 0);
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void delete_with_reference_data_in_child_parent_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_reference_data_in_parent_and_child_is_invalid() {
            var newDto = new ParentReferenceDto() {
                ManyToManyReferenceChildDto = new ManyToManyReferenceChildDto()
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, null, newDto, 2, 2, 2, 0, 0, 2, 2, 0, 0);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void update_with_reference_data_in_parent_and_child_is_invalid() {
            var oldDto = new ParentReferenceDto {
                ParentKey = 1,
                ManyToManyReferenceChildDto = new ManyToManyReferenceChildDto()
            };

            var newDto = new ParentReferenceDto {
                ParentKey = 1,
                ParentName = "Wibble",
                ManyToManyReferenceChildDto = new ManyToManyReferenceChildDto()
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, oldDto, newDto, 1, 1, 0, 1, 0, 1, 0, 1, 0);
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void delete_with_reference_data_in_child_parent_and_child_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_special_data_in_parent_and_reference_data_in_child_is_invalid() {
            var newDto = new ParentSpecialDto() {
                ManyToManyReferenceChildDto = new ManyToManyReferenceChildDto()
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, null, newDto, 2, 2, 2, 0, 0, 2, 2, 0, 0);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void update_with_special_data_in_parent_and_reference_data_in_child_is_invalid() {
            var oldDto = new ParentSpecialDto {
                ParentKey = 1,
                ManyToManyReferenceChildDto = new ManyToManyReferenceChildDto()
            };

            var newDto = new ParentSpecialDto {
                ParentKey = 1,
                ParentName = "Wibble",
                ManyToManyReferenceChildDto = new ManyToManyReferenceChildDto()
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, oldDto, newDto, 1, 1, 0, 1, 0, 1, 0, 1, 0);
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void delete_with_special_data_in_parent_and_reference_data_in_child_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_special_data_in_parent_and_child_is_invalid() {
            var newDto = new ParentSpecialDto() {
                ManyToManySpecialChildDto = new ManyToManySpecialChildDto()
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, null, newDto, 2, 2, 2, 0, 0, 2, 2, 0, 0);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void update_with_special_data_in_parent_and_child_is_invalid() {
            var oldDto = new ParentSpecialDto {
                ParentKey = 1,
                ManyToManySpecialChildDto = new ManyToManySpecialChildDto()
            };

            var newDto = new ParentSpecialDto {
                ParentKey = 1,
                ParentName = "Wibble",
                ManyToManySpecialChildDto = new ManyToManySpecialChildDto()
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, oldDto, newDto, 1, 1, 0, 1, 0, 1, 0, 1, 0);
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void delete_with_special_data_in_child_parent_and_child_is_not_supported() {
            throw new NotImplementedException();
        }
    }
}
