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
    public class OneToOneRelationshipFkOnChildCommandGenerationTests : BaseTests
    {

        [Test]
        public void insert_with_fk_on_child_no_reference_data_inserts_rows_in_parent_and_child()
        {
            var newDto = new ParentDto()
            {
                OneToOneChildDtoWithFk = new OneToOneChildDtoWithFk()
            };

            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, null, newDto, 2, 2, 2, 0, 0, 2, 2, 0, 0);
            var list = new List<BaseCommand>(commands);

            var parentInsert = list [0] as InsertCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(ParentDto)).TableName,
                parentInsert.Operation.ValueMetadata.TableName,
                "Unexpected parent table name.");

            var childInsert = list [1] as InsertCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(OneToOneChildDtoWithFk)).TableName,
                childInsert.Operation.ValueMetadata.TableName,
                "Unexpected child table name.");
        }

        [Test]
        public void update_with_fk_on_child_no_reference_data_updates_rows_in_parent_and_child() {
            var oldDto = new ParentDto()
            {
                ParentKey = 943982,
                OneToOneChildDtoWithFk = new OneToOneChildDtoWithFk
                {
                    ParentKey = 943982
                }
            };

            var newDto = new ParentDto()
            {
                ParentKey = 943982,
                ParentName = "Breaking",
                OneToOneChildDtoWithFk = new OneToOneChildDtoWithFk
                {
                    ParentKey = 943982,
                    Name = "Bad"
                }
            };

            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, oldDto, newDto, 2, 2, 0, 2, 0, 2, 0, 2, 0);
            var list = new List<BaseCommand>(commands);

            var update = list[0] as UpdateCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(OneToOneChildDtoWithFk)).TableName,
                update.Operations.FirstOrDefault().OwnerMetadata.TableName,
                "Unexpected child table name.");

            update = list[1] as UpdateCommand;
            
            Assert.AreEqual(
                cache.GetMetadataFor(typeof(ParentDto)).TableName,
                update.Operations.FirstOrDefault().OwnerMetadata.TableName,
                "Unexpected parent table name.");
        }

        [Test]
        public void delete_with_fk_on_child_no_reference_data_deletes_rows_in_child_and_parent() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_fk_on_child_and_reference_data_in_child_is_invalid() {
            var newDto = new ParentDto()
            {
                OneToOneReferenceChildDtoWithFk = new OneToOneReferenceChildDtoWithFk()
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, null, newDto, 2, 2, 2, 0, 0, 2, 2, 0, 0);
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void update_with_fk_on_child_and_reference_data_in_child_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void delete_with_fk_on_child_and_reference_data_in_child_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        public void insert_with_fk_on_child_and_special_data_in_child_inserts_in_parent_and_updates_child() {
            var newDto = new ParentDto()
            {
                OneToOneSpecialChildDtoWithFk = new OneToOneSpecialChildDtoWithFk()
            };

            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, null, newDto, 2, 2, 1, 1, 0, 2, 1, 1, 0);
            var list = new List<BaseCommand>(commands);

            var parentInsert = list [0] as InsertCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(ParentDto)).TableName,
                parentInsert.Operation.ValueMetadata.TableName,
                "Unexpected parent table name.");

            var childUpdate = list [1] as UpdateCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(OneToOneSpecialChildDtoWithFk)).TableName,
                childUpdate.Operations.FirstOrDefault().ValueMetadata.TableName,
                "Unexpected child table name.");
        }

        [Test]
        public void update_with_fk_on_child_and_special_data_in_child_updates_parent() {
            throw new NotImplementedException();
        }

        [Test]
        public void delete_with_fk_on_child_and_special_data_in_child_updates_child_and_deletes_parent() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_fk_on_child_and_reference_data_in_parent_is_invalid() {
            var newDto = new ParentReferenceDto
            {
                OneToOneChildDtoWithFk = new OneToOneChildDtoWithFk()
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, null, newDto, 2, 2, 2, 0, 0, 2, 2, 0, 0);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void update_with_fk_on_child_and_reference_data_in_parent_is_invalid() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void delete_with_fk_on_child_and_reference_data_in_parent_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_fk_on_child_and_reference_data_in_both_parent_and_child_is_invalid() {
            var newDto = new ParentReferenceDto
            {
                OneToOneReferenceChildDtoWithFk = new OneToOneReferenceChildDtoWithFk()
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, null, newDto, 2, 2, 2, 0, 0, 2, 2, 0, 0);
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void update_with_fk_on_child_and_reference_data_in_both_parent_and_child_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void delete_with_fk_on_child_and_reference_data_in_both_parent_and_child_is_not_supported() {
            throw new NotImplementedException();
        }
    }
}
