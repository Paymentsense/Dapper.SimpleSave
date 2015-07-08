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
    public class GuidManyToOneRelationshipCommandGenerationTests : BaseTests {

        private void insert_inserts_in_parent<T>(T parentDto)
        {
            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, default(T), parentDto, 2, 1, 1, 0, 0, 1, 1, 0, 0);
            var list = new List<BaseCommand>(commands);

            var command = list[0] as InsertCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(T)).TableName,
                command.Operation.ValueMetadata.TableName,
                "Unexpected parent table name.");
        }

        private void update_updates_parent<T>(T oldDto, T newDto)
        {
            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, oldDto, newDto, 1, 1, 0, 1, 0, 1, 0, 1, 0);
            var list = new List<BaseCommand>(commands);

            var command = list[0] as UpdateCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(T)).TableName,
                command.Operations.FirstOrDefault().TableName,
                "Unexpected parent table name.");
        }

        private void delete_deletes_from_parent<T>(T oldDto)
        {
            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, oldDto, default(T), 2, 1, 0, 0, 1, 1, 0, 0, 1);
            var list = new List<BaseCommand>(commands);

            var command = list[0] as DeleteCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(T)).TableName,
                command.Operation.ValueMetadata.TableName);
        }

        [Test]
        public void insert_with_no_reference_data_inserts_in_parent()
        {
            var newDto = new GuidParentDto
            {
                ManyToOneChildDto = new GuidManyToOneChildDto()
            };

            insert_inserts_in_parent(newDto);
        }

        [Test]
        public void update_with_no_reference_data_updates_parent() {
            var oldDto = new GuidParentDto
            {
                ParentKey = Guid.NewGuid(),
                ManyToOneChildDto = new GuidManyToOneChildDto()
            };

            var newDto = new GuidParentDto
            {
                ParentKey = oldDto.ParentKey,
                ParentName = "Now that we've found love what are we gonna do with it?",
                ManyToOneChildDto = new GuidManyToOneChildDto
                {
                    ChildKey = oldDto.ManyToOneChildDto.ChildKey
                }
            };

            update_updates_parent(oldDto, newDto);
        }

        [Test]
        public void delete_with_no_reference_data_deletes_from_parent() {
            var oldDto = new GuidParentDto
            {
                ManyToOneChildDto = new GuidManyToOneChildDto()
            };

            delete_deletes_from_parent(oldDto);
        }

        [Test]
        public void insert_with_reference_data_in_child_inserts_in_parent() {
            var newDto = new GuidParentDto
            {
                ManyToOneReferenceChildDto = new GuidManyToOneReferenceChildDto()
            };

            insert_inserts_in_parent(newDto);
        }

        [Test]
        public void update_with_reference_data_in_child_updates_parent() {
            var oldDto = new GuidParentDto
            {
                ParentKey = Guid.NewGuid(),
                ManyToOneReferenceChildDto = new GuidManyToOneReferenceChildDto()
            };

            var newDto = new GuidParentDto
            {
                ParentKey = oldDto.ParentKey,
                ParentName = "Now that we've found love what are we gonna do with it?",
                ManyToOneReferenceChildDto = new GuidManyToOneReferenceChildDto
                {
                    ChildKey = oldDto.ManyToOneReferenceChildDto.ChildKey
                }
            };

            update_updates_parent(oldDto, newDto);
        }

        [Test]
        public void delete_with_reference_data_in_child_deletes_from_parent() {
            var oldDto = new GuidParentDto
            {
                ManyToOneReferenceChildDto = new GuidManyToOneReferenceChildDto()
            };

            delete_deletes_from_parent(oldDto);
        }

        [Test]
        public void insert_with_special_data_in_child_inserts_in_parent() {
            var newDto = new GuidParentDto
            {
                ManyToOneSpecialChildDto = new GuidManyToOneSpecialChildDto()
            };

            insert_inserts_in_parent(newDto);
        }

        [Test]
        public void update_with_special_data_in_child_updates_parent() {
            var oldDto = new GuidParentDto
            {
                ParentKey = Guid.NewGuid(),
                ManyToOneSpecialChildDto = new GuidManyToOneSpecialChildDto()
            };

            var newDto = new GuidParentDto
            {
                ParentKey = oldDto.ParentKey,
                ParentName = "Now that we've found love what are we gonna do with it?",
                ManyToOneSpecialChildDto = new GuidManyToOneSpecialChildDto
                {
                    ChildKey = oldDto.ManyToOneSpecialChildDto.ChildKey
                }
            };

            update_updates_parent(oldDto, newDto);
        }

        [Test]
        public void delete_with_special_data_in_child_deletes_from_parent() {
            var oldDto = new GuidParentDto
            {
                ManyToOneSpecialChildDto = new GuidManyToOneSpecialChildDto()
            };

            delete_deletes_from_parent(oldDto);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_reference_data_in_parent_is_invalid() {
            var newDto = new GuidParentReferenceDto
            {
                ManyToOneChildDto = new GuidManyToOneChildDto()
            };

            insert_inserts_in_parent(newDto);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void update_with_reference_data_in_parent_is_invalid() {
            var oldDto = new GuidParentReferenceDto
            {
                ParentKey = Guid.NewGuid(),
                ManyToOneChildDto = new GuidManyToOneChildDto()
            };

            var newDto = new GuidParentReferenceDto
            {
                ParentKey = oldDto.ParentKey,
                ParentName = "Now that we've found love what are we gonna do with it?",
                ManyToOneChildDto = new GuidManyToOneChildDto
                {
                    ChildKey = oldDto.ManyToOneChildDto.ChildKey
                }
            };

            update_updates_parent(oldDto, newDto);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void delete_with_reference_data_in_parent_is_invalid() {
            var oldDto = new GuidParentReferenceDto
            {
                ManyToOneChildDto = new GuidManyToOneChildDto()
            };

            delete_deletes_from_parent(oldDto);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_reference_data_in_parent_and_child_is_invalid() {
            var newDto = new GuidParentReferenceDto
            {
                ManyToOneReferenceChildDto = new GuidManyToOneReferenceChildDto()
            };

            insert_inserts_in_parent(newDto);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void update_with_reference_data_in_parent_and_child_is_invalid() {
            var oldDto = new GuidParentReferenceDto
            {
                ParentKey = Guid.NewGuid(),
                ManyToOneReferenceChildDto = new GuidManyToOneReferenceChildDto()
            };

            var newDto = new GuidParentReferenceDto
            {
                ParentKey = oldDto.ParentKey,
                ParentName = "Now that we've found love what are we gonna do with it?",
                ManyToOneReferenceChildDto = new GuidManyToOneReferenceChildDto
                {
                    ChildKey = oldDto.ManyToOneReferenceChildDto.ChildKey
                }
            };

            update_updates_parent(oldDto, newDto);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void delete_with_reference_data_in_parent_and_child_is_invalid() {
            var oldDto = new GuidParentReferenceDto
            {
                ManyToOneReferenceChildDto = new GuidManyToOneReferenceChildDto()
            };

            delete_deletes_from_parent(oldDto);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_special_data_in_parent_and_reference_data_in_child_is_invalid() {
            var newDto = new GuidParentSpecialDto
            {
                ManyToOneReferenceChildDto = new GuidManyToOneReferenceChildDto()
            };

            insert_inserts_in_parent(newDto);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void update_with_special_data_in_parent_and_reference_data_in_child_is_invalid() {
            var oldDto = new GuidParentSpecialDto
            {
                ParentKey = Guid.NewGuid(),
                ManyToOneReferenceChildDto = new GuidManyToOneReferenceChildDto()
            };

            var newDto = new GuidParentSpecialDto
            {
                ParentKey = oldDto.ParentKey,
                ParentName = "Now that we've found love what are we gonna do with it?",
                ManyToOneReferenceChildDto = new GuidManyToOneReferenceChildDto
                {
                    ChildKey = oldDto.ManyToOneReferenceChildDto.ChildKey
                }
            };

            update_updates_parent(oldDto, newDto);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void delete_with_special_data_in_parent_and_reference_data_in_child_is_invalid() {
            var oldDto = new GuidParentSpecialDto
            {
                ManyToOneReferenceChildDto = new GuidManyToOneReferenceChildDto()
            };

            delete_deletes_from_parent(oldDto);
        }
    }
}
