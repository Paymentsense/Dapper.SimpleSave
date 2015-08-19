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
    public class ManyToOneRelationshipCommandGenerationTests : BaseTests {

        private void insert_inserts_in_parent<T>(T parentDto, bool assertOnCounts = true)
        {
            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, default(T), parentDto, 2, 1, 1, 0, 0, 1, 1, 0, 0, assertOnCounts);
            var list = new List<BaseCommand>(commands);

            var command = list[0] as InsertCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(T)).TableName,
                command.Operation.ValueMetadata.TableName,
                "Unexpected parent table name.");
        }

        private void update_updates_parent<T>(T oldDto, T newDto, bool assertOnCounts = true)
        {
            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, oldDto, newDto, 1, 1, 0, 1, 0, 1, 0, 1, 0, assertOnCounts);
            var list = new List<BaseCommand>(commands);

            var command = list[0] as UpdateCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(T)).TableName,
                command.Operations.FirstOrDefault().TableName,
                "Unexpected parent table name.");
        }

        private void delete_deletes_from_parent<T>(T oldDto, bool assertOnCounts = true)
        {
            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, oldDto, default(T), 2, 1, 0, 0, 1, 1, 0, 0, 1, assertOnCounts);
            var list = new List<BaseCommand>(commands);

            var command = list[0] as DeleteCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(T)).TableName,
                command.Operation.ValueMetadata.TableName);
        }

        [Test]
        public void insert_with_no_reference_data_inserts_in_parent()
        {
            var newDto = new ParentDto
            {
                ManyToOneChildDto = new ManyToOneChildDto()
            };

            insert_inserts_in_parent(newDto);
        }

        [Test]
        public void update_with_no_reference_data_updates_parent() {
            var oldDto = new ParentDto
            {
                ParentKey = 5462,
                ManyToOneChildDto = new ManyToOneChildDto()
            };

            var newDto = new ParentDto
            {
                ParentKey = 5462,
                ParentName = "Now that we've found love what are we gonna do with it?",
                ManyToOneChildDto = new ManyToOneChildDto()
            };

            update_updates_parent(oldDto, newDto);
        }

        [Test]
        public void delete_with_no_reference_data_deletes_from_parent() {
            var oldDto = new ParentDto
            {
                ManyToOneChildDto = new ManyToOneChildDto()
            };

            delete_deletes_from_parent(oldDto);
        }

        [Test]
        public void insert_with_reference_data_in_child_inserts_in_parent() {
            var newDto = new ParentDto
            {
                ManyToOneReferenceChildDto = new ManyToOneReferenceChildDto()
            };

            insert_inserts_in_parent(newDto);
        }

        [Test]
        public void update_with_reference_data_in_child_updates_parent() {
            var oldDto = new ParentDto
            {
                ParentKey = 5462,
                ManyToOneReferenceChildDto = new ManyToOneReferenceChildDto()
            };

            var newDto = new ParentDto
            {
                ParentKey = 5462,
                ParentName = "Now that we've found love what are we gonna do with it?",
                ManyToOneReferenceChildDto = new ManyToOneReferenceChildDto()
            };

            update_updates_parent(oldDto, newDto);
        }

        [Test]
        public void delete_with_reference_data_in_child_deletes_from_parent() {
            var oldDto = new ParentDto
            {
                ManyToOneReferenceChildDto = new ManyToOneReferenceChildDto()
            };

            delete_deletes_from_parent(oldDto);
        }

        [Test]
        public void insert_with_special_data_in_child_inserts_in_parent() {
            var newDto = new ParentDto
            {
                ManyToOneSpecialChildDto = new ManyToOneSpecialChildDto()
            };

            insert_inserts_in_parent(newDto);
        }

        [Test]
        public void update_with_special_data_in_child_updates_parent() {
            var oldDto = new ParentDto
            {
                ParentKey = 5462,
                ManyToOneSpecialChildDto = new ManyToOneSpecialChildDto()
            };

            var newDto = new ParentDto
            {
                ParentKey = 5462,
                ParentName = "Now that we've found love what are we gonna do with it?",
                ManyToOneSpecialChildDto = new ManyToOneSpecialChildDto()
            };

            update_updates_parent(oldDto, newDto);
        }

        [Test]
        public void delete_with_special_data_in_child_deletes_from_parent() {
            var oldDto = new ParentDto
            {
                ManyToOneSpecialChildDto = new ManyToOneSpecialChildDto()
            };

            delete_deletes_from_parent(oldDto);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_reference_data_in_parent_is_invalid() {
            var newDto = new ParentReferenceDto
            {
                ManyToOneChildDto = new ManyToOneChildDto()
            };

            insert_inserts_in_parent(newDto, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        [Ignore("Replace with test that checks no changes made. Consider validating diff to warn user if ref/special changes are made.")]
        public void update_with_reference_data_in_parent_is_invalid() {
            var oldDto = new ParentReferenceDto
            {
                ParentKey = 5462,
                ManyToOneChildDto = new ManyToOneChildDto()
            };

            var newDto = new ParentReferenceDto
            {
                ParentKey = 5462,
                ParentName = "Now that we've found love what are we gonna do with it?",
                ManyToOneChildDto = new ManyToOneChildDto()
            };

            update_updates_parent(oldDto, newDto, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void delete_with_reference_data_in_parent_is_invalid() {
            var oldDto = new ParentReferenceDto
            {
                ManyToOneChildDto = new ManyToOneChildDto()
            };

            delete_deletes_from_parent(oldDto, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_reference_data_in_parent_and_child_is_invalid() {
            var newDto = new ParentReferenceDto
            {
                ManyToOneReferenceChildDto = new ManyToOneReferenceChildDto()
            };

            insert_inserts_in_parent(newDto, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        [Ignore("Replace with test that checks no changes made. Consider validating diff to warn user if ref/special changes are made.")]
        public void update_with_reference_data_in_parent_and_child_is_invalid() {
            var oldDto = new ParentReferenceDto
            {
                ParentKey = 5462,
                ManyToOneReferenceChildDto = new ManyToOneReferenceChildDto()
            };

            var newDto = new ParentReferenceDto
            {
                ParentKey = 5462,
                ParentName = "Now that we've found love what are we gonna do with it?",
                ManyToOneReferenceChildDto = new ManyToOneReferenceChildDto()
            };

            update_updates_parent(oldDto, newDto, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void delete_with_reference_data_in_parent_and_child_is_invalid() {
            var oldDto = new ParentReferenceDto
            {
                ManyToOneReferenceChildDto = new ManyToOneReferenceChildDto()
            };

            delete_deletes_from_parent(oldDto, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_special_data_in_parent_and_reference_data_in_child_is_invalid() {
            var newDto = new ParentSpecialDto
            {
                ManyToOneReferenceChildDto = new ManyToOneReferenceChildDto()
            };

            insert_inserts_in_parent(newDto, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        [Ignore("Replace with test that checks no changes made. Consider validating diff to warn user if ref/special changes are made.")]
        public void update_with_special_data_in_parent_and_reference_data_in_child_is_invalid() {
            var oldDto = new ParentSpecialDto
            {
                ParentKey = 5462,
                ManyToOneReferenceChildDto = new ManyToOneReferenceChildDto()
            };

            var newDto = new ParentSpecialDto
            {
                ParentKey = 5462,
                ParentName = "Now that we've found love what are we gonna do with it?",
                ManyToOneReferenceChildDto = new ManyToOneReferenceChildDto()
            };

            update_updates_parent(oldDto, newDto, false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void delete_with_special_data_in_parent_and_reference_data_in_child_is_invalid() {
            var oldDto = new ParentSpecialDto
            {
                ManyToOneReferenceChildDto = new ManyToOneReferenceChildDto()
            };

            delete_deletes_from_parent(oldDto, false);
        }
    }
}
