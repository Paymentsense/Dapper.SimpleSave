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

        private void insert_inserts_in_child_and_maybe_parent<T>(T newDto, Type childDtoType, bool insertsInChild)
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

            insert_inserts_in_child_and_maybe_parent(newDto, typeof(OneToOneChildDtoNoFk), true);
        }

        [Test]
        public void update_with_fk_on_parent_no_reference_data_updates_rows_in_child_and_parent()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void delete_with_fk_on_parent_no_reference_data_deletes_rows_in_parent_and_child()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void insert_with_fk_on_parent_and_reference_data_in_child_inserts_in_parent_only()
        {
            var newDto = new ParentDto
            {
                OneToOneReferenceChildDtoNoFk = new OneToOneReferenceChildDtoNoFk()
            };

            insert_inserts_in_child_and_maybe_parent(newDto, typeof(OneToOneReferenceChildDtoNoFk), false);
        }

        [Test]
        public void update_with_fk_on_parent_and_reference_data_in_child_updates_in_parent_only() {
            throw new NotImplementedException();
        }

        [Test]
        public void delete_with_fk_on_parent_and_reference_data_in_child_deletes_in_parent_only() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_fk_on_parent_and_reference_data_in_parent_is_invalid()
        {
            var newDto = new ParentReferenceDto
            {
                OneToOneChildDtoNoFk = new OneToOneChildDtoNoFk()
            };

            insert_inserts_in_child_and_maybe_parent(newDto, typeof(OneToOneChildDtoNoFk), false);
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void update_with_fk_on_parent_and_reference_data_in_parent_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void delete_with_fk_on_parent_and_reference_data_in_parent_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_fk_on_parent_and_special_data_in_parent_is_invalid()
        {
            var newDto = new ParentSpecialDto
            {
                OneToOneChildDtoNoFk = new OneToOneChildDtoNoFk()
            };

            insert_inserts_in_child_and_maybe_parent(newDto, typeof(OneToOneChildDtoNoFk), false);
        }

        [Test]
        public void update_with_fk_on_parent_and_special_data_in_parent_updates_parent() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void delete_with_fk_on_parent_and_special_data_in_parent_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_fk_on_parent_and_reference_data_in_both_parent_and_child_is_invalid()
        {
            var newDto = new ParentReferenceDto
            {
                OneToOneReferenceChildDtoNoFk = new OneToOneReferenceChildDtoNoFk()
            };

            insert_inserts_in_child_and_maybe_parent(newDto, typeof(OneToOneReferenceChildDtoNoFk), false);
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void update_with_fk_on_parent_and_reference_data_in_both_parent_and_child_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void delete_with_fk_on_parent_and_reference_data_in_both_parent_and_child_is_not_supported() {
            throw new NotImplementedException();
        }
    }
}
