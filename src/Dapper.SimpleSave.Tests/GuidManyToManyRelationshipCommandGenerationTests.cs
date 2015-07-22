using System;
using System.Collections.Generic;
using System.Linq;
using Dapper.SimpleSave.Impl;
using Dapper.SimpleSave.Tests.GuidDtos;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests {

    [TestFixture]
    public class GuidManyToManyRelationshipCommandGenerationTests : BaseTests {

        private void insert_inserts_in_parent_and_link(GuidParentDto newDto, string manyToManyPropertyName)
        {
            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, null, newDto, 2, 2, 2, 0, 0, 2, 2, 0, 0);
            var list = new List<BaseCommand>(commands);
            var command = list [0] as InsertCommand;
            Assert.AreEqual(cache.GetMetadataFor(typeof(GuidParentDto)).TableName, command.Operation.ValueMetadata.TableName, "Unexpected table name");
            command = list [1] as InsertCommand;
            Assert.AreEqual(
                cache.GetMetadataFor(typeof(GuidParentDto)).Properties.Where(p => p.ColumnName == manyToManyPropertyName).FirstOrDefault().GetAttribute<ManyToManyAttribute>().SchemaQualifiedLinkTableName,
                command.Operation.OwnerPropertyMetadata.GetAttribute<ManyToManyAttribute>().SchemaQualifiedLinkTableName, "Unexpected table name");
        }

        [Test]
        public void insert_with_no_reference_data_inserts_in_parent_and_link_table()
        {
            var newDto = new GuidParentDto
            {
                ManyToManyChildDto = new [] { new GuidManyToManyChildDto() }
            };

            insert_inserts_in_parent_and_link(newDto, "ManyToManyChildDto");
        }

        [Test]
        public void update_with_no_reference_data_updates_child_and_parent() {
            var oldDto = new GuidParentDto {
                ParentKey = Guid.NewGuid(),
                ManyToManyChildDto = new [] { new GuidManyToManyChildDto() }
            };

            var newDto = new GuidParentDto {
                ParentKey = oldDto.ParentKey,
                ParentName = "Wibble",
                ManyToManyChildDto = new [] { new GuidManyToManyChildDto
                {
                    ChildKey = oldDto.ManyToManyChildDto[0].ChildKey,
                    Name = "Wobble"
                } }
            };

            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, oldDto, newDto, 2, 2, 0, 2, 0, 2, 0, 2, 0);
            var list = new List<BaseCommand>(commands);

            var command = list[0] as UpdateCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(GuidManyToManyChildDto)).TableName,
                command.TableName,
                "Unexpected table name.");

            Assert.AreEqual(
                "Name",
                command.Operations.FirstOrDefault().OwnerPropertyMetadata.ColumnName,
                "Unexpected column name.");

            command = list[1] as UpdateCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(GuidParentDto)).TableName,
                command.TableName,
                "Unexpected table name.");

            Assert.AreEqual(
                "ParentName",
                command.Operations.FirstOrDefault().OwnerPropertyMetadata.ColumnName);
        }

        [Test]
        public void delete_with_no_reference_data_deletes_from_link_table_and_parent() {
            var oldDto = new GuidParentDto {
                ParentKey = Guid.NewGuid(),
                ManyToManyChildDto = new [] { new GuidManyToManyChildDto() }
            };

            delete_deletes_from_link_table_and_parent(oldDto, typeof(GuidManyToManyChildDto));
        }

        private void delete_deletes_from_link_table_and_parent<T>(T oldDto, Type childDtoType) where T: GuidParentDto {
            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, oldDto, default(T), 2, 2, 0, 0, 2, 2, 0, 0, 2);
            var list = new List<BaseCommand>(commands);

            var command = list [0] as DeleteCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(childDtoType).TableName,
                command.Operation.ValueMetadata.TableName,
                "Unexpected table name for child.");

            command = list [1] as DeleteCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(GuidParentDto)).TableName,
                command.Operation.ValueMetadata.TableName,
                "Unexpected table name for parent.");
        }

        [Test]
        public void insert_with_reference_data_in_child_inserts_in_parent_and_link_table() {
            var newDto = new GuidParentDto {
                ManyToManyReferenceChildDto = new [] { new GuidManyToManyReferenceChildDto() }
            };

            insert_inserts_in_parent_and_link(newDto, "ManyToManyReferenceChildDto");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void update_parent_and_child_with_reference_data_in_child_is_invalid() {
            var oldDto = new GuidParentDto {
                ParentKey = Guid.NewGuid(),
                ManyToManyReferenceChildDto = new [] { new GuidManyToManyReferenceChildDto() }
            };

            var newDto = new GuidParentDto {
                ParentKey = oldDto.ParentKey,
                ParentName = "Wibble",
                ManyToManyReferenceChildDto = new [] { new GuidManyToManyReferenceChildDto()
                {
                    ChildKey = oldDto.ManyToManyReferenceChildDto[0].ChildKey,
                    Name = "Wobble"
                } }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, oldDto, newDto, 2, 2, 0, 2, 0, 1, 0, 1, 0);
        }

        [Test]
        public void update_parent_with_reference_data_in_child_updates_parent_only()
        {
            var oldDto = new GuidParentDto {
                ParentKey = Guid.NewGuid(),
                ManyToManyReferenceChildDto = new [] { new GuidManyToManyReferenceChildDto() }
            };

            var newDto = new GuidParentDto {
                ParentKey = oldDto.ParentKey,
                ParentName = "Wibble",
                ManyToManyReferenceChildDto = new [] { new GuidManyToManyReferenceChildDto
                {
                    ChildKey = oldDto.ManyToManyReferenceChildDto[0].ChildKey
                } }
            };

            update_updates_parent_only(oldDto, newDto);
        }

        private void update_updates_parent_only(GuidParentDto oldDto, GuidParentDto newDto)
        {
            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, oldDto, newDto, 1, 1, 0, 1, 0, 1, 0, 1, 0);
            var list = new List<BaseCommand>(commands);
            var command = list [0] as UpdateCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(GuidParentDto)).TableName,
                command.TableName,
                "Unexpected table name.");

            Assert.AreEqual(
                1,
                command.Operations.Count(),
                "Unexpected number of operations.");

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(GuidParentDto)).Properties.Where(p => p.ColumnName == "ParentName").FirstOrDefault().ColumnName,
                command.Operations.FirstOrDefault().ColumnName,
                "Unexpected column name.");
        }

        [Test]
        public void delete_with_reference_data_in_child_deletes_from_link_table_and_parent() {
            var oldDto = new GuidParentDto {
                ParentKey = Guid.NewGuid(),
                ManyToManyReferenceChildDto = new [] { new GuidManyToManyReferenceChildDto() }
            };

            delete_deletes_from_link_table_and_parent(oldDto, typeof(GuidManyToManyReferenceChildDto));
        }

        [Test]
        public void insert_with_special_data_in_child_inserts_in_parent_and_link_table() {
            var newDto = new GuidParentDto {
                ManyToManySpecialChildDto = new [] { new GuidManyToManySpecialChildDto() }
            };

            insert_inserts_in_parent_and_link(newDto, "ManyToManySpecialChildDto");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void update_parent_and_non_fk_column_in_child_with_special_data_in_child_is_invalid() {
            var oldDto = new GuidParentDto {
                ParentKey = Guid.NewGuid(),
                ManyToManySpecialChildDto = new [] { new GuidManyToManySpecialChildDto() }
            };

            var newDto = new GuidParentDto {
                ParentKey = oldDto.ParentKey,
                ParentName = "Wibble",
                ManyToManySpecialChildDto = new [] { new GuidManyToManySpecialChildDto {
                    ChildKey = oldDto.ManyToManySpecialChildDto[0].ChildKey,
                    Name = "Wobble"
                } }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, oldDto, newDto, 2, 2, 0, 2, 0, 1, 0, 1, 0);
        }

        [Test]
        public void update_parent_with_special_data_in_child_updates_parent()
        {
            var oldDto = new GuidParentDto {
                ParentKey = Guid.NewGuid(),
                ManyToManySpecialChildDto = new [] { new GuidManyToManySpecialChildDto() }
            };

            var newDto = new GuidParentDto {
                ParentKey = oldDto.ParentKey,
                ParentName = "Wibble",
                ManyToManySpecialChildDto = new [] { new GuidManyToManySpecialChildDto
                {
                    ChildKey = oldDto.ManyToManySpecialChildDto[0].ChildKey
                } }
            };

            update_updates_parent_only(oldDto, newDto);
        }

        [Test]
        public void delete_with_special_data_in_child_deletes_from_link_table_and_parent() {
            var oldDto = new GuidParentDto {
                ParentKey = Guid.NewGuid(),
                ManyToManySpecialChildDto = new [] { new GuidManyToManySpecialChildDto() }
            };

            delete_deletes_from_link_table_and_parent(oldDto, typeof(GuidManyToManySpecialChildDto));
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_reference_data_in_parent_is_invalid() {
            var newDto = new GuidParentReferenceDto() {
                ManyToManyChildDto = new [] { new GuidManyToManyChildDto() }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, null, newDto, 2, 2, 2, 0, 0, 2, 2, 0, 0);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void update_with_reference_data_in_parent_is_invalid() {
            var oldDto = new GuidParentReferenceDto {
                ParentKey = Guid.NewGuid(),
                ManyToManyChildDto = new [] { new GuidManyToManyChildDto() }
            };

            var newDto = new GuidParentReferenceDto {
                ParentKey = oldDto.ParentKey,
                ParentName = "Wibble",
                ManyToManyChildDto = new [] { new GuidManyToManyChildDto
                {
                    ChildKey = oldDto.ManyToManyChildDto[0].ChildKey
                } }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, oldDto, newDto, 1, 1, 0, 1, 0, 1, 0, 1, 0);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void delete_with_reference_data_in_parent_is_invalid() {
            var oldDto = new GuidParentReferenceDto {
                ParentKey = Guid.NewGuid(),
                ManyToManyChildDto = new [] { new GuidManyToManyChildDto() }
            };

            delete_deletes_from_link_table_and_parent(oldDto, typeof(GuidManyToManyChildDto));
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_reference_data_in_parent_and_child_is_invalid() {
            var newDto = new GuidParentReferenceDto() {
                ManyToManyReferenceChildDto = new [] { new GuidManyToManyReferenceChildDto() }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, null, newDto, 2, 2, 2, 0, 0, 2, 2, 0, 0);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void update_with_reference_data_in_parent_and_child_is_invalid() {
            var oldDto = new GuidParentReferenceDto {
                ParentKey = Guid.NewGuid(),
                ManyToManyReferenceChildDto = new [] { new GuidManyToManyReferenceChildDto() }
            };

            var newDto = new GuidParentReferenceDto {
                ParentKey = oldDto.ParentKey,
                ParentName = "Wibble",
                ManyToManyReferenceChildDto = new [] { new GuidManyToManyReferenceChildDto
                {
                    ChildKey = oldDto.ManyToManyReferenceChildDto[0].ChildKey
                } }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, oldDto, newDto, 1, 1, 0, 1, 0, 1, 0, 1, 0);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void delete_with_reference_data_in_parent_and_child_is_invalid() {
            var oldDto = new GuidParentReferenceDto {
                ParentKey = Guid.NewGuid(),
                ManyToManyReferenceChildDto = new [] { new GuidManyToManyReferenceChildDto() }
            };

            delete_deletes_from_link_table_and_parent(oldDto, typeof(GuidManyToManyReferenceChildDto));
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_special_data_in_parent_and_reference_data_in_child_is_invalid() {
            var newDto = new GuidParentSpecialDto() {
                ManyToManyReferenceChildDto = new [] { new GuidManyToManyReferenceChildDto() }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, null, newDto, 2, 2, 2, 0, 0, 2, 2, 0, 0);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void update_with_special_data_in_parent_and_reference_data_in_child_is_invalid() {
            var oldDto = new GuidParentSpecialDto {
                ParentKey = Guid.NewGuid(),
                ManyToManyReferenceChildDto = new [] { new GuidManyToManyReferenceChildDto() }
            };

            var newDto = new GuidParentSpecialDto {
                ParentKey = oldDto.ParentKey,
                ParentName = "Wibble",
                ManyToManyReferenceChildDto = new [] { new GuidManyToManyReferenceChildDto
                {
                    ChildKey = oldDto.ManyToManyReferenceChildDto[0].ChildKey
                } }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, oldDto, newDto, 1, 1, 0, 1, 0, 1, 0, 1, 0);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void delete_with_special_data_in_parent_and_reference_data_in_child_is_invalid() {
            var oldDto = new GuidParentSpecialDto {
                ParentKey = Guid.NewGuid(),
                ManyToManyReferenceChildDto = new [] { new GuidManyToManyReferenceChildDto() }
            };

            delete_deletes_from_link_table_and_parent(oldDto, typeof(GuidManyToManyReferenceChildDto));
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_special_data_in_parent_and_child_is_invalid() {
            var newDto = new GuidParentSpecialDto() {
                ManyToManySpecialChildDto = new [] { new GuidManyToManySpecialChildDto() }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, null, newDto, 2, 2, 2, 0, 0, 2, 2, 0, 0);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void update_with_special_data_in_parent_and_child_is_invalid() {
            var oldDto = new GuidParentSpecialDto {
                ParentKey = Guid.NewGuid(),
                ManyToManySpecialChildDto = new [] { new GuidManyToManySpecialChildDto() }
            };

            var newDto = new GuidParentSpecialDto {
                ParentKey = oldDto.ParentKey,
                ParentName = "Wibble",
                ManyToManySpecialChildDto = new [] { new GuidManyToManySpecialChildDto
                {
                    ChildKey = oldDto.ManyToManySpecialChildDto[0].ChildKey
                } }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, oldDto, newDto, 1, 1, 0, 1, 0, 1, 0, 1, 0);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void delete_with_special_data_in_parent_and_child_is_invalid() {
            var oldDto = new GuidParentSpecialDto {
                ParentKey = Guid.NewGuid(),
                ManyToManySpecialChildDto = new [] { new GuidManyToManySpecialChildDto() }
            };

            delete_deletes_from_link_table_and_parent(oldDto, typeof(GuidManyToManySpecialChildDto));
        }
    }
}
