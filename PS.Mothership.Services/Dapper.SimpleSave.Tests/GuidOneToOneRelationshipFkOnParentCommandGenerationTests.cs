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
    public class GuidOneToOneRelationshipFkOnParentCommandGenerationTests : BaseTests
    {

        private void insert_maybe_inserts_in_child_and_always_in_parent<T>(T newDto, Type childDtoType, bool insertsInChild)
        {
            var counts = insertsInChild ? 2 : 1;
            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, default(T), newDto, 2, counts, counts, 0, 0, counts, counts, 0, 0);
            var list = new List<BaseCommand>(commands);

            if (insertsInChild)
            {
                var childInsert = list[0] as InsertCommand;

                Assert.AreEqual(
                    cache.GetMetadataFor(childDtoType).TableName,
                    childInsert.Operation.ValueMetadata.TableName,
                    "Unexpected child table name.");
            }

            var parentInsert = list[counts - 1] as InsertCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(T)).TableName,
                parentInsert.Operation.ValueMetadata.TableName,
                "Unexpected parent table name.");
        }

        [Test]
        public void insert_with_fk_on_parent_no_reference_data_inserts_rows_in_child_and_parent()
        {
            var newDto = new GuidParentDto
            {
                OneToOneChildDtoNoFk = new GuidOneToOneChildDtoNoFk()
            };

            insert_maybe_inserts_in_child_and_always_in_parent(newDto, typeof(GuidOneToOneChildDtoNoFk), true);
        }

        private void update_updates_in_parent_and_maybe_child<T>(
            T oldDto,
            T newDto,
            Type childDtoType,
            int expectedDifferenceCount,
            bool updatesChildDto)
        {
            var counts = updatesChildDto ? 2 : 1;
            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, oldDto, newDto, expectedDifferenceCount, counts, 0, counts, 0, counts, 0, counts, 0);
            var list = new List<BaseCommand>(commands);

            if (updatesChildDto)
            {
                var childUpdate = list [0] as UpdateCommand;

                Assert.AreEqual(
                    cache.GetMetadataFor(childDtoType).TableName,
                    childUpdate.Operations.FirstOrDefault().OwnerMetadata.TableName,
                    "Unexpected child table name.");
            }

            var parentUpdate = list [counts - 1] as UpdateCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(T)).TableName,
                parentUpdate.Operations.FirstOrDefault().OwnerMetadata.TableName,
                "Unexpected parent table name.");

        }

        [Test]
        public void update_with_fk_on_parent_no_reference_data_updates_rows_in_child_and_parent()
        {
            var oldDto = new GuidParentDto
            {
                ParentKey = Guid.NewGuid(),
                OneToOneChildDtoNoFk = new GuidOneToOneChildDtoNoFk()
            };

            var newDto = new GuidParentDto
            {
                ParentKey = oldDto.ParentKey,
                ParentName = "I will fight you",
                OneToOneChildDtoNoFk = new GuidOneToOneChildDtoNoFk
                {
                    Name = "On the beaches"
                }
            };

            update_updates_in_parent_and_maybe_child(oldDto, newDto, typeof(GuidOneToOneChildDtoNoFk), 2, true);
        }

        private void delete_deletes_from_parent_and_maybe_child<T>(
            T oldDto,
            Type childDtoType,
            bool deletesFromChild)
        {
            var counts = deletesFromChild ? 2 : 1;
            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, oldDto, default(T), 2, counts, 0, 0, counts, counts, 0, 0, counts);
            var list = new List<BaseCommand>(commands);

            var parentDelete = list [0] as DeleteCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(T)).TableName,
                parentDelete.Operation.ValueMetadata.TableName,
                "Unexpected parent table name.");

            if (deletesFromChild)
            {
                var childDelete = list [1] as DeleteCommand;

                Assert.AreEqual(
                    cache.GetMetadataFor(childDtoType).TableName,
                    childDelete.Operation.ValueMetadata.TableName,
                    "Unexpected child table name.");
            }

        }

        [Test]
        public void delete_with_fk_on_parent_no_reference_data_deletes_rows_in_child_and_parent()
        {
            var oldDto = new GuidParentDto
            {
                OneToOneChildDtoNoFk = new GuidOneToOneChildDtoNoFk()
            };

            delete_deletes_from_parent_and_maybe_child(oldDto, typeof(GuidOneToOneChildDtoNoFk), true);
        }

        [Test]
        public void insert_with_fk_on_parent_and_reference_data_in_child_inserts_in_parent_only()
        {
            var newDto = new GuidParentDto
            {
                OneToOneReferenceChildDtoNoFk = new GuidOneToOneReferenceChildDtoNoFk()
            };

            insert_maybe_inserts_in_child_and_always_in_parent(newDto, typeof(GuidOneToOneReferenceChildDtoNoFk), false);
        }

        [Test]
        public void update_with_fk_on_parent_and_reference_data_in_child_updates_in_parent_only() {
            var oldDto = new GuidParentDto
            {
                ParentKey = Guid.NewGuid(),
                OneToOneReferenceChildDtoNoFk = new GuidOneToOneReferenceChildDtoNoFk()
            };

            var newDto = new GuidParentDto
            {
                ParentKey = oldDto.ParentKey,
                ParentName = "I will fight you",
                OneToOneReferenceChildDtoNoFk = new GuidOneToOneReferenceChildDtoNoFk()
            };

            update_updates_in_parent_and_maybe_child(oldDto, newDto, typeof(GuidOneToOneChildDtoNoFk), 1, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void update_both_with_fk_on_parent_and_reference_data_in_child_is_invalid()
        {
            var oldDto = new GuidParentDto
            {
                ParentKey = Guid.NewGuid(),
                OneToOneReferenceChildDtoNoFk = new GuidOneToOneReferenceChildDtoNoFk()
            };

            var newDto = new GuidParentDto
            {
                ParentKey = oldDto.ParentKey,
                ParentName = "I will fight you",
                OneToOneReferenceChildDtoNoFk = new GuidOneToOneReferenceChildDtoNoFk
                {
                    Name = "On the beaches"
                }
            };

            update_updates_in_parent_and_maybe_child(oldDto, newDto, typeof(GuidOneToOneReferenceChildDtoNoFk), 2, true);
        }

        [Test]
        public void delete_with_fk_on_parent_and_reference_data_in_child_deletes_in_parent_only() {
            var oldDto = new GuidParentDto
            {
                OneToOneReferenceChildDtoNoFk = new GuidOneToOneReferenceChildDtoNoFk()
            };

            delete_deletes_from_parent_and_maybe_child(oldDto, typeof(GuidOneToOneReferenceChildDtoNoFk), false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_fk_on_parent_and_reference_data_in_parent_is_invalid()
        {
            var newDto = new GuidParentReferenceDto
            {
                OneToOneChildDtoNoFk = new GuidOneToOneChildDtoNoFk()
            };

            insert_maybe_inserts_in_child_and_always_in_parent(newDto, typeof(GuidOneToOneChildDtoNoFk), false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void update_with_fk_on_parent_and_reference_data_in_parent_is_invalid() {
            var oldDto = new GuidParentReferenceDto
            {
                ParentKey = Guid.NewGuid(),
                OneToOneChildDtoNoFk = new GuidOneToOneChildDtoNoFk()
            };

            var newDto = new GuidParentReferenceDto
            {
                ParentKey = oldDto.ParentKey,
                ParentName = "I will fight you",
                OneToOneChildDtoNoFk = new GuidOneToOneChildDtoNoFk()
            };

            update_updates_in_parent_and_maybe_child(oldDto, newDto, typeof(GuidOneToOneChildDtoNoFk), 1, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void delete_with_fk_on_parent_and_reference_data_in_parent_is_invalid() {
            var newDto = new GuidParentReferenceDto
            {
                OneToOneChildDtoNoFk = new GuidOneToOneChildDtoNoFk()
            };

            insert_maybe_inserts_in_child_and_always_in_parent(newDto, typeof(GuidOneToOneChildDtoNoFk), false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_fk_on_parent_and_special_data_in_parent_is_invalid()
        {
            var newDto = new GuidParentSpecialDto
            {
                OneToOneChildDtoNoFk = new GuidOneToOneChildDtoNoFk()
            };

            insert_maybe_inserts_in_child_and_always_in_parent(newDto, typeof(GuidOneToOneChildDtoNoFk), false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void update_with_fk_on_parent_and_special_data_in_parent_is_invalid() {
            var oldDto = new GuidParentSpecialDto
            {
                ParentKey = Guid.NewGuid(),
                OneToOneChildDtoNoFk = new GuidOneToOneChildDtoNoFk()
            };

            var newDto = new GuidParentSpecialDto
            {
                ParentKey = oldDto.ParentKey,
                ParentName = "I will fight you",
                OneToOneChildDtoNoFk = new GuidOneToOneChildDtoNoFk()
            };

            update_updates_in_parent_and_maybe_child(oldDto, newDto, typeof(GuidOneToOneChildDtoNoFk), 1, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void delete_with_fk_on_parent_and_special_data_in_parent_is_invalid() {
            var newDto = new GuidParentSpecialDto
            {
                OneToOneChildDtoNoFk = new GuidOneToOneChildDtoNoFk()
            };

            insert_maybe_inserts_in_child_and_always_in_parent(newDto, typeof(GuidOneToOneChildDtoNoFk), false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_fk_on_parent_and_reference_data_in_both_parent_and_child_is_invalid()
        {
            var newDto = new GuidParentReferenceDto
            {
                OneToOneReferenceChildDtoNoFk = new GuidOneToOneReferenceChildDtoNoFk()
            };

            insert_maybe_inserts_in_child_and_always_in_parent(newDto, typeof(GuidOneToOneReferenceChildDtoNoFk), false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void update_with_fk_on_parent_and_reference_data_in_both_parent_and_child_is_invalid() {
            var oldDto = new GuidParentReferenceDto
            {
                ParentKey = Guid.NewGuid(),
                OneToOneReferenceChildDtoNoFk = new GuidOneToOneReferenceChildDtoNoFk()
            };

            var newDto = new GuidParentReferenceDto
            {
                ParentKey = oldDto.ParentKey,
                ParentName = "I will fight you",
                OneToOneReferenceChildDtoNoFk = new GuidOneToOneReferenceChildDtoNoFk()
            };

            update_updates_in_parent_and_maybe_child(oldDto, newDto, typeof(GuidOneToOneReferenceChildDtoNoFk), 1, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void delete_with_fk_on_parent_and_reference_data_in_both_parent_and_child_is_invalid() {
            var newDto = new GuidParentReferenceDto
            {
                OneToOneReferenceChildDtoNoFk = new GuidOneToOneReferenceChildDtoNoFk()
            };

            insert_maybe_inserts_in_child_and_always_in_parent(newDto, typeof(GuidOneToOneReferenceChildDtoNoFk), false);
        }
    }
}
