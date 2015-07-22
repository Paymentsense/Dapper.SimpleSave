using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.SimpleSave.Impl;
using Dapper.SimpleSave.Tests.GuidDtos;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests {

    [TestFixture]
    public class GuidOneToOneRelationshipFkOnChildCommandGenerationTests : BaseTests
    {

        [Test]
        public void insert_with_fk_on_child_no_reference_data_inserts_rows_in_parent_and_child()
        {
            var newDto = new GuidParentDto()
            {
                OneToOneChildDtoWithFk = new GuidOneToOneChildDtoWithFk()
            };

            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, null, newDto, 2, 2, 2, 0, 0, 2, 2, 0, 0);
            var list = new List<BaseCommand>(commands);

            var parentInsert = list [0] as InsertCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(GuidParentDto)).TableName,
                parentInsert.Operation.ValueMetadata.TableName,
                "Unexpected parent table name.");

            var childInsert = list [1] as InsertCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(GuidOneToOneChildDtoWithFk)).TableName,
                childInsert.Operation.ValueMetadata.TableName,
                "Unexpected child table name.");
        }

        [Test]
        public void update_with_fk_on_child_no_reference_data_updates_rows_in_parent_and_child()
        {
            var parentKey = Guid.NewGuid();
            var oldDto = new GuidParentDto()
            {
                ParentKey = parentKey,
                OneToOneChildDtoWithFk = new GuidOneToOneChildDtoWithFk
                {
                    ParentKey = parentKey
                }
            };

            var newDto = new GuidParentDto()
            {
                ParentKey = parentKey,
                ParentName = "Breaking",
                OneToOneChildDtoWithFk = new GuidOneToOneChildDtoWithFk
                {
                    ParentKey = parentKey,
                    Name = "Bad"
                }
            };

            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, oldDto, newDto, 2, 2, 0, 2, 0, 2, 0, 2, 0);
            var list = new List<BaseCommand>(commands);

            var update = list[0] as UpdateCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(GuidOneToOneChildDtoWithFk)).TableName,
                update.Operations.FirstOrDefault().OwnerMetadata.TableName,
                "Unexpected child table name.");

            update = list[1] as UpdateCommand;
            
            Assert.AreEqual(
                cache.GetMetadataFor(typeof(GuidParentDto)).TableName,
                update.Operations.FirstOrDefault().OwnerMetadata.TableName,
                "Unexpected parent table name.");
        }

        [Test]
        public void delete_with_fk_on_child_no_reference_data_deletes_rows_in_child_and_parent() {
            var oldDto = new GuidParentDto()
            {
                OneToOneChildDtoWithFk = new GuidOneToOneChildDtoWithFk()
            };

            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, oldDto, null, 2, 2, 0, 0, 2, 2, 0, 0, 2);
            var list = new List<BaseCommand>(commands);

            var delete = list[0] as DeleteCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(GuidOneToOneChildDtoWithFk)).TableName,
                delete.Operation.ValueMetadata.TableName);

            delete = list[1] as DeleteCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(GuidParentDto)).TableName,
                delete.Operation.ValueMetadata.TableName);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_fk_on_child_and_reference_data_in_child_is_invalid() {
            var newDto = new GuidParentDto()
            {
                OneToOneReferenceChildDtoWithFk = new GuidOneToOneReferenceChildDtoWithFk()
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, null, newDto, 2, 2, 2, 0, 0, 2, 2, 0, 0);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void update_both_with_fk_on_child_and_reference_data_in_child_is_invalid()
        {
            var parentKey = Guid.NewGuid();
            var oldDto = new GuidParentDto()
            {
                ParentKey = parentKey,
                OneToOneReferenceChildDtoWithFk = new GuidOneToOneReferenceChildDtoWithFk
                {
                    ParentKey = parentKey
                }
            };

            var newDto = new GuidParentDto()
            {
                ParentKey = parentKey,
                ParentName = "Breaking",
                OneToOneReferenceChildDtoWithFk = new GuidOneToOneReferenceChildDtoWithFk
                {
                    ParentKey = parentKey,
                    Name = "Bad"
                }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, oldDto, newDto, 2, 2, 0, 2, 0, 2, 0, 2, 0);
        }

        private void update_on_mostly_readonly_child_updates_parent<T>(T oldDto, T newDto)
        {
            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, oldDto, newDto, 1, 1, 0, 1, 0, 1, 0, 1, 0);
            var list = new List<BaseCommand>(commands);

            var command = list [0] as UpdateCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(GuidParentDto)).TableName,
                command.Operations.FirstOrDefault().OwnerMetadata.TableName,
                "Unexpected parent table name.");
        }

        [Test]
        public void update_parent_with_fk_on_child_and_reference_data_in_child_updates_parent()
        {
            var parentKey = Guid.NewGuid();
            var oldDto = new GuidParentDto()
            {
                ParentKey = parentKey,
                OneToOneReferenceChildDtoWithFk = new GuidOneToOneReferenceChildDtoWithFk
                {
                    ParentKey = parentKey
                }
            };

            var newDto = new GuidParentDto()
            {
                ParentKey = parentKey,
                ParentName = "Breaking",
                OneToOneReferenceChildDtoWithFk = new GuidOneToOneReferenceChildDtoWithFk
                {
                    ParentKey = parentKey
                }
            };

            update_on_mostly_readonly_child_updates_parent(oldDto, newDto);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void delete_with_fk_on_child_and_reference_data_in_child_is_invalid()
        {
            var parentKey = Guid.NewGuid();
            var oldDto = new GuidParentDto()
            {
                ParentKey = parentKey,
                OneToOneReferenceChildDtoWithFk = new GuidOneToOneReferenceChildDtoWithFk
                {
                    ParentKey = parentKey
                }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, oldDto, null, 2, 2, 0, 0, 2, 2, 0, 0, 2);
        }

        [Test]
        public void insert_with_fk_on_child_and_special_data_in_child_inserts_in_parent_and_updates_child() {
            var newDto = new GuidParentDto()
            {
                OneToOneSpecialChildDtoWithFk = new GuidOneToOneSpecialChildDtoWithFk()
            };

            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, null, newDto, 2, 2, 1, 1, 0, 2, 1, 1, 0);
            var list = new List<BaseCommand>(commands);

            var parentInsert = list [0] as InsertCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(GuidParentDto)).TableName,
                parentInsert.Operation.ValueMetadata.TableName,
                "Unexpected parent table name.");

            var childUpdate = list [1] as UpdateCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(GuidOneToOneSpecialChildDtoWithFk)).TableName,
                childUpdate.Operations.FirstOrDefault().ValueMetadata.TableName,
                "Unexpected child table name.");
        }

        [Test]
        public void update_with_fk_on_child_and_special_data_in_child_updates_parent()
        {
            var parentKey = Guid.NewGuid();
            var oldDto = new GuidParentDto()
            {
                ParentKey = parentKey,
                OneToOneSpecialChildDtoWithFk = new GuidOneToOneSpecialChildDtoWithFk
                {
                    ParentKey = parentKey
                }
            };

            var newDto = new GuidParentDto()
            {
                ParentKey = parentKey,
                ParentName = "Breaking",
                OneToOneSpecialChildDtoWithFk = new GuidOneToOneSpecialChildDtoWithFk
                {
                    ParentKey = parentKey
                }
            };

            update_on_mostly_readonly_child_updates_parent(oldDto, newDto);
        }

        [Test]
        public void delete_with_fk_on_child_and_special_data_in_child_updates_child_and_deletes_parent() {
            var oldDto = new GuidParentDto()
            {
                OneToOneSpecialChildDtoWithFk = new GuidOneToOneSpecialChildDtoWithFk()
            };

            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, oldDto, null, 2, 2, 0, 1, 1, 2, 0, 1, 1);
            var list = new List<BaseCommand>(commands);

            var update = list [0] as UpdateCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(GuidOneToOneSpecialChildDtoWithFk)).TableName,
                update.Operations.FirstOrDefault().ValueMetadata.TableName);

            var delete = list [1] as DeleteCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(GuidParentDto)).TableName,
                delete.Operation.ValueMetadata.TableName);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_fk_on_child_and_reference_data_in_parent_is_invalid() {
            var newDto = new GuidParentReferenceDto
            {
                OneToOneChildDtoWithFk = new GuidOneToOneChildDtoWithFk()
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, null, newDto, 2, 2, 2, 0, 0, 2, 2, 0, 0);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void update_with_fk_on_child_and_reference_data_in_parent_is_invalid()
        {
            var parentKey = Guid.NewGuid();
            var oldDto = new GuidParentReferenceDto()
            {
                ParentKey = parentKey,
                OneToOneChildDtoWithFk = new GuidOneToOneChildDtoWithFk
                {
                    ParentKey = parentKey
                }
            };

            var newDto = new GuidParentReferenceDto()
            {
                ParentKey = parentKey,
                ParentName = "Breaking",
                OneToOneChildDtoWithFk = new GuidOneToOneChildDtoWithFk
                {
                    ParentKey = parentKey
                }
            };

            update_on_mostly_readonly_child_updates_parent(oldDto, newDto);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void delete_with_fk_on_child_and_reference_data_in_parent_is_invalid()
        {
            var parentKey = Guid.NewGuid();
            var oldDto = new GuidParentReferenceDto
            {
                ParentKey = parentKey,
                OneToOneChildDtoWithFk = new GuidOneToOneChildDtoWithFk
                {
                    ParentKey = parentKey
                }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, oldDto, null, 2, 2, 0, 0, 2, 2, 0, 0, 2);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_fk_on_child_and_reference_data_in_both_parent_and_child_is_invalid() {
            var newDto = new GuidParentReferenceDto
            {
                OneToOneReferenceChildDtoWithFk = new GuidOneToOneReferenceChildDtoWithFk()
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, null, newDto, 2, 2, 2, 0, 0, 2, 2, 0, 0);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void update_with_fk_on_child_and_reference_data_in_both_parent_and_child_is_invalid()
        {
            var parentKey = Guid.NewGuid();
            var oldDto = new GuidParentReferenceDto()
            {
                ParentKey = parentKey,
                OneToOneReferenceChildDtoWithFk = new GuidOneToOneReferenceChildDtoWithFk
                {
                    ParentKey = parentKey
                }
            };

            var newDto = new GuidParentReferenceDto()
            {
                ParentKey = parentKey,
                ParentName = "Breaking",
                OneToOneReferenceChildDtoWithFk = new GuidOneToOneReferenceChildDtoWithFk
                {
                    ParentKey = parentKey
                }
            };

            update_on_mostly_readonly_child_updates_parent(oldDto, newDto);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void delete_with_fk_on_child_and_reference_data_in_both_parent_and_child_is_invalid()
        {
            var parentKey = Guid.NewGuid();
            var oldDto = new GuidParentReferenceDto
            {
                ParentKey = parentKey,
                OneToOneReferenceChildDtoWithFk = new GuidOneToOneReferenceChildDtoWithFk
                {
                    ParentKey = parentKey
                }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, oldDto, null, 2, 2, 0, 0, 2, 2, 0, 0, 2);
        }
    }
}
