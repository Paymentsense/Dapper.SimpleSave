using System;
using System.Collections.Generic;
using System.Linq;
using Dapper.SimpleSave.Impl;
using Dapper.SimpleSave.Tests.Dto;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests.TestCommands {

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
            var oldDto = new ParentDto()
            {
                OneToOneChildDtoWithFk = new OneToOneChildDtoWithFk()
            };

            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, oldDto, null, 2, 2, 0, 0, 2, 2, 0, 0, 2);
            var list = new List<BaseCommand>(commands);

            var delete = list[0] as DeleteCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(OneToOneChildDtoWithFk)).TableName,
                delete.Operation.ValueMetadata.TableName);

            delete = list[1] as DeleteCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(ParentDto)).TableName,
                delete.Operation.ValueMetadata.TableName);
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
        [ExpectedException(typeof(InvalidOperationException))]
        [Ignore("Replace with test that checks no changes made. Consider validating diff to warn user if ref/special changes are made.")]
        public void update_both_with_fk_on_child_and_reference_data_in_child_is_invalid() {
            var oldDto = new ParentDto()
            {
                ParentKey = 943982,
                OneToOneReferenceChildDtoWithFk = new OneToOneReferenceChildDtoWithFk
                {
                    ParentKey = 943982
                }
            };

            var newDto = new ParentDto()
            {
                ParentKey = 943982,
                ParentName = "Breaking",
                OneToOneReferenceChildDtoWithFk = new OneToOneReferenceChildDtoWithFk
                {
                    ParentKey = 943982,
                    Name = "Bad"
                }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, oldDto, newDto, 2, 2, 0, 2, 0, 2, 0, 2, 0, false);
        }

        private void update_on_mostly_readonly_child_updates_parent<T>(T oldDto, T newDto, bool assertOnCounts = true)
        {
            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, oldDto, newDto, 1, 1, 0, 1, 0, 1, 0, 1, 0, assertOnCounts);
            var list = new List<BaseCommand>(commands);

            var command = list [0] as UpdateCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(ParentDto)).TableName,
                command.Operations.FirstOrDefault().OwnerMetadata.TableName,
                "Unexpected parent table name.");
        }

        [Test]
        public void update_parent_with_fk_on_child_and_reference_data_in_child_updates_parent()
        {
            var oldDto = new ParentDto()
            {
                ParentKey = 943982,
                OneToOneReferenceChildDtoWithFk = new OneToOneReferenceChildDtoWithFk
                {
                    ParentKey = 943982
                }
            };

            var newDto = new ParentDto()
            {
                ParentKey = 943982,
                ParentName = "Breaking",
                OneToOneReferenceChildDtoWithFk = new OneToOneReferenceChildDtoWithFk
                {
                    ParentKey = 943982
                }
            };

            update_on_mostly_readonly_child_updates_parent(oldDto, newDto);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void delete_with_fk_on_child_and_reference_data_in_child_is_invalid() {
            var oldDto = new ParentDto()
            {
                ParentKey = 5321,
                OneToOneReferenceChildDtoWithFk = new OneToOneReferenceChildDtoWithFk
                {
                    ParentKey = 5321
                }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, oldDto, null, 2, 2, 0, 0, 2, 2, 0, 0, 2);
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
            var oldDto = new ParentDto()
            {
                ParentKey = 943982,
                OneToOneSpecialChildDtoWithFk = new OneToOneSpecialChildDtoWithFk
                {
                    ParentKey = 943982
                }
            };

            var newDto = new ParentDto()
            {
                ParentKey = 943982,
                ParentName = "Breaking",
                OneToOneSpecialChildDtoWithFk = new OneToOneSpecialChildDtoWithFk
                {
                    ParentKey = 943982
                }
            };

            update_on_mostly_readonly_child_updates_parent(oldDto, newDto);
        }

        [Test]
        public void delete_with_fk_on_child_and_special_data_in_child_updates_child_and_deletes_parent() {
            var oldDto = new ParentDto()
            {
                OneToOneSpecialChildDtoWithFk = new OneToOneSpecialChildDtoWithFk()
            };

            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, oldDto, null, 2, 2, 0, 1, 1, 2, 0, 1, 1);
            var list = new List<BaseCommand>(commands);

            var update = list [0] as UpdateCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(OneToOneSpecialChildDtoWithFk)).TableName,
                update.Operations.FirstOrDefault().ValueMetadata.TableName);

            var delete = list [1] as DeleteCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(ParentDto)).TableName,
                delete.Operation.ValueMetadata.TableName);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_fk_on_child_and_reference_data_in_parent_is_invalid() {
            var newDto = new ParentReferenceDto
            {
                OneToOneChildDtoWithFk = new OneToOneChildDtoWithFk()
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, null, newDto, 2, 2, 2, 0, 0, 2, 2, 0, 0, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        [Ignore("Replace with test that checks no changes made. Consider validating diff to warn user if ref/special changes are made.")]
        public void update_with_fk_on_child_and_reference_data_in_parent_is_invalid() {
            var oldDto = new ParentReferenceDto()
            {
                ParentKey = 943982,
                OneToOneChildDtoWithFk = new OneToOneChildDtoWithFk
                {
                    ParentKey = 943982
                }
            };

            var newDto = new ParentReferenceDto()
            {
                ParentKey = 943982,
                ParentName = "Breaking",
                OneToOneChildDtoWithFk = new OneToOneChildDtoWithFk
                {
                    ParentKey = 943982
                }
            };

            update_on_mostly_readonly_child_updates_parent(oldDto, newDto, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void delete_with_fk_on_child_and_reference_data_in_parent_is_invalid() {
            var oldDto = new ParentReferenceDto
            {
                ParentKey = 43432,
                OneToOneChildDtoWithFk = new OneToOneChildDtoWithFk
                {
                    ParentKey = 43432
                }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, oldDto, null, 2, 2, 0, 0, 2, 2, 0, 0, 2, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_fk_on_child_and_reference_data_in_both_parent_and_child_is_invalid() {
            var newDto = new ParentReferenceDto
            {
                OneToOneReferenceChildDtoWithFk = new OneToOneReferenceChildDtoWithFk()
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, null, newDto, 2, 2, 2, 0, 0, 2, 2, 0, 0, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        [Ignore("Replace with test that checks no changes made. Consider validating diff to warn user if ref/special changes are made.")]
        public void update_with_fk_on_child_and_reference_data_in_both_parent_and_child_is_invalid() {
            var oldDto = new ParentReferenceDto()
            {
                ParentKey = 943982,
                OneToOneReferenceChildDtoWithFk = new OneToOneReferenceChildDtoWithFk
                {
                    ParentKey = 943982
                }
            };

            var newDto = new ParentReferenceDto()
            {
                ParentKey = 943982,
                ParentName = "Breaking",
                OneToOneReferenceChildDtoWithFk = new OneToOneReferenceChildDtoWithFk
                {
                    ParentKey = 943982
                }
            };

            update_on_mostly_readonly_child_updates_parent(oldDto, newDto, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void delete_with_fk_on_child_and_reference_data_in_both_parent_and_child_is_invalid() {
            var oldDto = new ParentReferenceDto
            {
                ParentKey = 43432,
                OneToOneReferenceChildDtoWithFk = new OneToOneReferenceChildDtoWithFk
                {
                    ParentKey = 43432
                }
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, oldDto, null, 2, 2, 0, 0, 2, 2, 0, 0, 2, false);
        }
    }
}
