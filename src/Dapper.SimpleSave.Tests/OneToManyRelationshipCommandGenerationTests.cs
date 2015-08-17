using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Dapper.SimpleSave.Impl;
using Dapper.SimpleSave.Tests.Dto;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests {

    [TestFixture]
    public class OneToManyRelationshipCommandGenerationTests : BaseTests {

        [Test]
        public void insert_with_no_reference_data_inserts_in_parent_and_child()
        {
            var newDto = new ParentDto {
                OneToManyChildDto = new [] { new OneToManyChildDto() }
            };

            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, null, newDto, 2, 2, 2, 0, 0, 2, 2, 0, 0);
            var list = new List<BaseCommand>(commands);

            Assert.AreEqual(
                2,
                list.Count,
                "Unexpected number of commands.");

            var command = list[0] as InsertCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(ParentDto)).TableName,
                command.Operation.ValueMetadata.TableName,
                "Unexpected table name for parent.");

            command = list[1] as InsertCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(OneToManyChildDto)).TableName,
                command.Operation.ValueMetadata.TableName,
                "Unexpected table name for child.");
        }

        [Test]
        public void update_with_no_reference_data_updates_in_parent_and_child() {
            var oldDto = new ParentDto {
                ParentKey = 1,
                OneToManyChildDto = new [] { new OneToManyChildDto
                {
                    ChildKey = 2
                } }
            };

            var newDto = new ParentDto
            {
                ParentKey = 1,
                ParentName = "ParentNameUpdated",
                OneToManyChildDto = new [] { new OneToManyChildDto
                {
                    ChildKey = 2,
                    Name = "Maximum Whoopee! Enabled"
                } }
            };

            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, oldDto, newDto, 2, 2, 0, 2, 0, 2, 0, 2, 0);
            var list = new List<BaseCommand>(commands);

            Assert.AreEqual(
                2,
                list.Count,
                "Unexpected number of commands.");

            var command = list[0] as UpdateCommand;
            
            Assert.AreEqual(
                cache.GetMetadataFor(typeof(OneToManyChildDto)).TableName,
                command.TableName,
                "Unexpected child table name.");

            Assert.AreEqual(
                "ChildKey",
                command.PrimaryKeyColumn,
                "Unexpected child primary key column.");

            Assert.AreEqual(
                1,
                command.Operations.Count(),
                "Unexpected number of update operations on child table.");

            Assert.AreEqual(
                "Name",
                command.Operations.FirstOrDefault().OwnerPropertyMetadata.ColumnName,
                "Unexpected column for child table UPDATE.");

            Assert.AreEqual(
                newDto.OneToManyChildDto[0].Name,
                command.Operations.FirstOrDefault().Value,
                "Unexpected child column value.");

            command = list[1] as UpdateCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(ParentDto)).TableName,
                command.TableName,
                "Unexpected parent table name.");

            Assert.AreEqual(
                "ParentKey",
                command.PrimaryKeyColumn,
                "Unexpected parent primary key column.");

            Assert.AreEqual(
                1,
                command.Operations.Count(),
                "Unexpected number of update operations on child table.");

            Assert.AreEqual(
                "ParentName",
                command.Operations.FirstOrDefault().OwnerPropertyMetadata.ColumnName,
                "Unexpected column for parent table UPDATE.");

            Assert.AreEqual(
                newDto.ParentName,
                command.Operations.FirstOrDefault().Value,
                "Unexpected parent column value.");
        }

        [Test]
        public void delete_with_no_reference_data_deletes_in_child_and_parent() {
            var oldDto = new ParentDto
            {
                ParentKey = 1,
                OneToManyChildDto = new [] { new OneToManyChildDto { ChildKey = 1 }}
            };

            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, oldDto, null, 2, 2, 0, 0, 2, 2, 0, 0, 2);
            var list = new List<BaseCommand>(commands);

            Assert.AreEqual(
                2,
                list.Count,
                "Unexpected number of commands.");

            var command = list[0] as DeleteCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(OneToManyChildDto)).TableName,
                command.Operation.ValueMetadata.TableName,
                "Unexpected child table name.");

            command = list[1] as DeleteCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(ParentDto)).TableName,
                command.Operation.ValueMetadata.TableName,
                "Unexpected parent table name.");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_reference_data_in_child_is_invalid() {
            var newDto = new ParentDto {
                OneToManyReferenceChildDto = new [] { new OneToManyReferenceChildDto() }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, null, newDto, 2, 2, 1, 1, 0, 2, 1, 1, 0);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        [Ignore("Replace with test that checks no changes made. Consider validating diff to warn user if ref/special changes are made.")]
        public void update_with_reference_data_in_child_is_invalid() {
            var oldDto = new ParentDto
            {
                ParentKey = 1,
                OneToManyReferenceChildDto = new [] { new OneToManyReferenceChildDto
                {
                    ChildKey = 2
                } }
            };

            var newDto = new ParentDto
            {
                ParentKey = 1,
                ParentName = "ParentNameUpdated",
                OneToManyReferenceChildDto = new [] { new OneToManyReferenceChildDto
                {
                    ChildKey = 2,
                    Name = "Maximum Whoopee! Enabled"
                } }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, oldDto, newDto, 2, 2, 0, 2, 0, 2, 0, 2, 0, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void delete_with_reference_data_in_child_is_invalid() {
            var oldDto = new ParentDto
            {
                ParentKey = 1,
                OneToManyReferenceChildDto = new [] { new OneToManyReferenceChildDto { ChildKey = 1 } }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, oldDto, null, 2, 2, 0, 0, 2, 2, 0, 0, 2);
        }

        [Test]
        public void insert_with_special_data_in_child_inserts_in_parent_and_updates_child() {
            var newDto = new ParentDto {
                OneToManySpecialChildDto = new [] { new OneToManySpecialChildDto() }
            };

            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, null, newDto, 2, 2, 1, 1, 0, 2, 1, 1, 0);

            var list = new List<BaseCommand>(commands);

            Assert.AreEqual(
                2,
                list.Count,
                "Unexpected number of commands.");

            var insert = list[0] as InsertCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(ParentDto)).TableName,
                insert.Operation.ValueMetadata.TableName,
                "Unexpected table name for parent.");

            var update = list[1] as UpdateCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(OneToManySpecialChildDto)).TableName,
                update.Operations.FirstOrDefault().ValueMetadata.TableName,
                "Unexpected table owner name for child update.");

            Assert.AreEqual(
                "OneToManySpecialChildDto",
                update.Operations.FirstOrDefault().ColumnName,
                "Unexpected owner's column name for child update.");

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(OneToManySpecialChildDto)).TableName,
                update.Operations.FirstOrDefault().ValueMetadata.TableName,
                "Unexected child table name.");
        }

        [Test]
        public void update_with_special_data_in_child_updates_parent() {
            var oldDto = new ParentDto
            {
                ParentKey = 1,
                OneToManySpecialChildDto = new [] { new OneToManySpecialChildDto { ChildKey = 1 } }
            };

            var newDto = new ParentDto
            {
                ParentKey = 1,
                ParentName = "ParentNameUpdated",
                OneToManySpecialChildDto = new [] { new OneToManySpecialChildDto { ChildKey = 1 } }
            };

            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, oldDto, newDto, 1, 1, 0, 1, 0, 1, 0, 1, 0);

            var list = new List<BaseCommand>(commands);

            var command = list[0] as UpdateCommand;
            
            Assert.AreEqual(
                cache.GetMetadataFor(typeof(ParentDto)).TableName,
                command.Operations.FirstOrDefault().TableName);

            Assert.AreEqual(
                1,
                command.Operations.Count(),
                "Unexpected number of operations.");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        [Ignore("Replace with test that checks no changes made. Consider validating diff to warn user if ref/special changes are made.")]
        public void update_of_parent_and_non_fk_columns_in_child_with_special_data_in_child_is_invalid()
        {
            var oldDto = new ParentDto
            {
                ParentKey = 1,
                OneToManySpecialChildDto = new [] { new OneToManySpecialChildDto
                {
                    ChildKey = 2
                } }
            };

            var newDto = new ParentDto
            {
                ParentKey = 1,
                ParentName = "ParentNameUpdated",
                OneToManySpecialChildDto = new [] { new OneToManySpecialChildDto
                {
                    ChildKey = 2,
                    Name = "Maximum Whoopee! Enabled"
                } }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, oldDto, newDto, 2, 2, 0, 2, 0, 2, 0, 2, 0, false);
        }

        [Test]
        public void delete_with_special_data_in_child_updates_child_and_deletes_parent() {
            var oldDto = new ParentDto
            {
                ParentKey = 532,
                OneToManySpecialChildDto = new [] { new OneToManySpecialChildDto { ChildKey = 1 } }
            };

            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, oldDto, null, 2, 2, 0, 1, 1, 2, 0, 1, 1);
            var list = new List<BaseCommand>(commands);

            Assert.AreEqual(
                2,
                list.Count,
                "Unexpected command count.");

            var update = list[0] as UpdateCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(OneToManySpecialChildDto)).TableName,
                update.Operations.FirstOrDefault().ValueMetadata.TableName,
                "Unexpected child table name.");

            var delete = list[1] as DeleteCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(ParentDto)).TableName,
                delete.Operation.ValueMetadata.TableName);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_reference_data_in_parent_is_invalid() {
            var newDto = new ParentReferenceDto {
                OneToManyChildDto = new [] { new OneToManyChildDto() }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, null, newDto, 2, 2, 1, 1, 0, 2, 1, 1, 0, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        [Ignore("Replace with test that checks no changes made. Consider validating diff to warn user if ref/special changes are made.")]
        public void update_with_reference_data_in_parent_is_invalid() {
            var oldDto = new ParentReferenceDto
            {
                ParentKey = 1,
                OneToManyChildDto = new [] { new OneToManyChildDto
                {
                    ChildKey = 2
                } }
            };

            var newDto = new ParentReferenceDto
            {
                ParentKey = 1,
                ParentName = "ParentNameUpdated",
                OneToManyChildDto = new [] { new OneToManyChildDto
                {
                    ChildKey = 2,
                    Name = "Maximum Whoopee! Enabled"
                } }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, oldDto, newDto, 2, 2, 0, 2, 0, 2, 0, 2, 0, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        [Ignore("Replace with test that checks no changes made. Consider validating diff to warn user if ref/special changes are made.")]
        public void delete_with_reference_data_in_parent_is_invalid() {
            var oldDto = new ParentReferenceDto
            {
                ParentKey = 1,
                OneToManyChildDto = new [] { new OneToManyChildDto { ChildKey = 1 }}
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, oldDto, null, 2, 2, 0, 0, 2, 2, 0, 0, 2, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_reference_data_in_parent_and_child_is_invalid() {
            var newDto = new ParentReferenceDto {
                OneToManyReferenceChildDto = new [] { new OneToManyReferenceChildDto() }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, null, newDto, 2, 2, 1, 1, 0, 2, 1, 1, 0, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        [Ignore("Replace with test that checks no changes made. Consider validating diff to warn user if ref/special changes are made.")]
        public void update_with_reference_data_in_parent_and_child_is_invalid() {
            var oldDto = new ParentReferenceDto
            {
                ParentKey = 1,
                OneToManyReferenceChildDto = new [] { new OneToManyReferenceChildDto
                {
                    ChildKey = 2
                } }
            };

            var newDto = new ParentReferenceDto
            {
                ParentKey = 1,
                ParentName = "ParentNameUpdated",
                OneToManyReferenceChildDto = new [] { new OneToManyReferenceChildDto
                {
                    ChildKey = 2,
                    Name = "Maximum Whoopee! Enabled"
                } }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, oldDto, newDto, 2, 2, 0, 2, 0, 2, 0, 2, 0, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        [Ignore("Replace with test that checks no changes made. Consider validating diff to warn user if ref/special changes are made.")]
        public void delete_with_reference_data_in_parent_and_child_is_invalid()
        {
            var oldDto = new ParentReferenceDto
            {
                ParentKey = 1,
                OneToManyReferenceChildDto = new [] { new OneToManyReferenceChildDto { ChildKey =1 }}
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, oldDto, null, 2, 2, 0, 0, 2, 2, 0, 0, 2, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_special_data_in_parent_is_invalid() {
            var newDto = new ParentSpecialDto
            {
                OneToManyChildDto = new [] { new OneToManyChildDto() }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, null, newDto, 2, 2, 2, 0, 0, 2, 2, 0, 0, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        [Ignore("Replace with test that checks no changes made. Consider validating diff to warn user if ref/special changes are made.")]
        public void update_with_special_data_in_parent_is_invalid() {
            var oldDto = new ParentSpecialDto
            {
                ParentKey = 1,
                OneToManyChildDto = new [] { new OneToManyChildDto
                {
                    ChildKey = 2
                } }
            };

            var newDto = new ParentSpecialDto
            {
                ParentKey = 1,
                ParentName = "ParentNameUpdated",
                OneToManyChildDto = new [] { new OneToManyChildDto
                {
                    ChildKey = 2,
                    Name = "Maximum Whoopee! Enabled"
                } }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, oldDto, newDto, 2, 2, 0, 2, 0, 2, 0, 2, 0, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void delete_with_special_data_in_parent_is_invalid() {
            var oldDto = new ParentSpecialDto
            {
                ParentKey = 1,
                OneToManyChildDto = new [] { new OneToManyChildDto { ChildKey = 1 } }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, oldDto, null, 2, 2, 0, 0, 2, 2, 0, 0, 2, false);
        }
    }
}
