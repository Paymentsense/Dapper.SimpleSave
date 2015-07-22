using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.SimpleSave.Impl;
using Dapper.SimpleSave.Tests.Dto;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests {

    [TestFixture]
    public class OneToOneRelationshipFkOnParentCommandGenerationTests : BaseTests
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
            var newDto = new ParentDto
            {
                OneToOneChildDtoNoFk = new OneToOneChildDtoNoFk()
            };

            insert_maybe_inserts_in_child_and_always_in_parent(newDto, typeof(OneToOneChildDtoNoFk), true);
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
            var oldDto = new ParentDto
            {
                ParentKey = 52879,
                OneToOneChildDtoNoFk = new OneToOneChildDtoNoFk()
            };

            var newDto = new ParentDto
            {
                ParentKey = 52879,
                ParentName = "I will fight you",
                OneToOneChildDtoNoFk = new OneToOneChildDtoNoFk
                {
                    Name = "On the beaches"
                }
            };

            update_updates_in_parent_and_maybe_child(oldDto, newDto, typeof(OneToOneChildDtoNoFk), 2, true);
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
            var oldDto = new ParentDto
            {
                OneToOneChildDtoNoFk = new OneToOneChildDtoNoFk()
            };

            delete_deletes_from_parent_and_maybe_child(oldDto, typeof(OneToOneChildDtoNoFk), true);
        }

        [Test]
        public void insert_with_fk_on_parent_and_reference_data_in_child_inserts_in_parent_only()
        {
            var newDto = new ParentDto
            {
                OneToOneReferenceChildDtoNoFk = new OneToOneReferenceChildDtoNoFk()
            };

            insert_maybe_inserts_in_child_and_always_in_parent(newDto, typeof(OneToOneReferenceChildDtoNoFk), false);
        }

        [Test]
        public void update_with_fk_on_parent_and_reference_data_in_child_updates_in_parent_only() {
            var oldDto = new ParentDto
            {
                ParentKey = 52879,
                OneToOneReferenceChildDtoNoFk = new OneToOneReferenceChildDtoNoFk()
            };

            var newDto = new ParentDto
            {
                ParentKey = 52879,
                ParentName = "I will fight you",
                OneToOneReferenceChildDtoNoFk = new OneToOneReferenceChildDtoNoFk()
            };

            update_updates_in_parent_and_maybe_child(oldDto, newDto, typeof(OneToOneChildDtoNoFk), 1, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void update_both_with_fk_on_parent_and_reference_data_in_child_is_invalid()
        {
            var oldDto = new ParentDto
            {
                ParentKey = 52879,
                OneToOneReferenceChildDtoNoFk = new OneToOneReferenceChildDtoNoFk()
            };

            var newDto = new ParentDto
            {
                ParentKey = 52879,
                ParentName = "I will fight you",
                OneToOneReferenceChildDtoNoFk = new OneToOneReferenceChildDtoNoFk
                {
                    Name = "On the beaches"
                }
            };

            update_updates_in_parent_and_maybe_child(oldDto, newDto, typeof(OneToOneReferenceChildDtoNoFk), 2, true);
        }

        [Test]
        public void delete_with_fk_on_parent_and_reference_data_in_child_deletes_in_parent_only() {
            var oldDto = new ParentDto
            {
                OneToOneReferenceChildDtoNoFk = new OneToOneReferenceChildDtoNoFk()
            };

            delete_deletes_from_parent_and_maybe_child(oldDto, typeof(OneToOneReferenceChildDtoNoFk), false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_fk_on_parent_and_reference_data_in_parent_is_invalid()
        {
            var newDto = new ParentReferenceDto
            {
                OneToOneChildDtoNoFk = new OneToOneChildDtoNoFk()
            };

            insert_maybe_inserts_in_child_and_always_in_parent(newDto, typeof(OneToOneChildDtoNoFk), false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void update_with_fk_on_parent_and_reference_data_in_parent_is_invalid() {
            var oldDto = new ParentReferenceDto
            {
                ParentKey = 52879,
                OneToOneChildDtoNoFk = new OneToOneChildDtoNoFk()
            };

            var newDto = new ParentReferenceDto
            {
                ParentKey = 52879,
                ParentName = "I will fight you",
                OneToOneChildDtoNoFk = new OneToOneChildDtoNoFk()
            };

            update_updates_in_parent_and_maybe_child(oldDto, newDto, typeof(OneToOneChildDtoNoFk), 1, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void delete_with_fk_on_parent_and_reference_data_in_parent_is_invalid() {
            var newDto = new ParentReferenceDto
            {
                OneToOneChildDtoNoFk = new OneToOneChildDtoNoFk()
            };

            insert_maybe_inserts_in_child_and_always_in_parent(newDto, typeof(OneToOneChildDtoNoFk), false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_fk_on_parent_and_special_data_in_parent_is_invalid()
        {
            var newDto = new ParentSpecialDto
            {
                OneToOneChildDtoNoFk = new OneToOneChildDtoNoFk()
            };

            insert_maybe_inserts_in_child_and_always_in_parent(newDto, typeof(OneToOneChildDtoNoFk), false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void update_with_fk_on_parent_and_special_data_in_parent_is_invalid() {
            var oldDto = new ParentSpecialDto
            {
                ParentKey = 52879,
                OneToOneChildDtoNoFk = new OneToOneChildDtoNoFk()
            };

            var newDto = new ParentSpecialDto
            {
                ParentKey = 52879,
                ParentName = "I will fight you",
                OneToOneChildDtoNoFk = new OneToOneChildDtoNoFk()
            };

            update_updates_in_parent_and_maybe_child(oldDto, newDto, typeof(OneToOneChildDtoNoFk), 1, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void delete_with_fk_on_parent_and_special_data_in_parent_is_invalid() {
            var newDto = new ParentSpecialDto
            {
                OneToOneChildDtoNoFk = new OneToOneChildDtoNoFk()
            };

            insert_maybe_inserts_in_child_and_always_in_parent(newDto, typeof(OneToOneChildDtoNoFk), false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_fk_on_parent_and_reference_data_in_both_parent_and_child_is_invalid()
        {
            var newDto = new ParentReferenceDto
            {
                OneToOneReferenceChildDtoNoFk = new OneToOneReferenceChildDtoNoFk()
            };

            insert_maybe_inserts_in_child_and_always_in_parent(newDto, typeof(OneToOneReferenceChildDtoNoFk), false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void update_with_fk_on_parent_and_reference_data_in_both_parent_and_child_is_invalid() {
            var oldDto = new ParentReferenceDto
            {
                ParentKey = 52879,
                OneToOneReferenceChildDtoNoFk = new OneToOneReferenceChildDtoNoFk()
            };

            var newDto = new ParentReferenceDto
            {
                ParentKey = 52879,
                ParentName = "I will fight you",
                OneToOneReferenceChildDtoNoFk = new OneToOneReferenceChildDtoNoFk()
            };

            update_updates_in_parent_and_maybe_child(oldDto, newDto, typeof(OneToOneReferenceChildDtoNoFk), 1, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void delete_with_fk_on_parent_and_reference_data_in_both_parent_and_child_is_invalid() {
            var newDto = new ParentReferenceDto
            {
                OneToOneReferenceChildDtoNoFk = new OneToOneReferenceChildDtoNoFk()
            };

            insert_maybe_inserts_in_child_and_always_in_parent(newDto, typeof(OneToOneReferenceChildDtoNoFk), false);
        }
    }
}
