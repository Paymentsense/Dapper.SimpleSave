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

        private void insert_inserts_in_parent<T>(T parentDto)
        {
            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, default(T), parentDto, 2, 1, 1, 0, 0, 1, 1, 0, 0);
            var list = new List<BaseCommand>(commands);

            var command = list [0] as InsertCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(T)).TableName,
                command.Operation.ValueMetadata.TableName,
                "Expected parent table name.");
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
            throw new NotImplementedException();
        }

        [Test]
        public void delete_with_no_reference_data_deletes_from_parent() {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        [Test]
        public void delete_with_reference_data_in_child_deletes_from_parent() {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        [Test]
        public void delete_with_special_data_in_child_deletes_from_parent() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_reference_data_in_parent_is_invalid() {
            var newDto = new ParentReferenceDto
            {
                ManyToOneChildDto = new ManyToOneChildDto()
            };

            insert_inserts_in_parent(newDto);
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void update_with_reference_data_in_parent_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void delete_with_reference_data_in_parent_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_reference_data_in_parent_and_child_is_invalid() {
            var newDto = new ParentReferenceDto
            {
                ManyToOneReferenceChildDto = new ManyToOneReferenceChildDto()
            };

            insert_inserts_in_parent(newDto);
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void update_with_reference_data_in_parent_and_child_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void delete_with_reference_data_in_parent_and_child_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_special_data_in_parent_and_reference_data_in_child_is_invalid() {
            var newDto = new ParentSpecialDto
            {
                ManyToOneReferenceChildDto = new ManyToOneReferenceChildDto()
            };

            insert_inserts_in_parent(newDto);
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void update_with_special_data_in_parent_and_reference_data_in_child_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void delete_with_special_data_in_parent_and_reference_data_in_child_is_not_supported() {
            throw new NotImplementedException();
        }
    }
}
