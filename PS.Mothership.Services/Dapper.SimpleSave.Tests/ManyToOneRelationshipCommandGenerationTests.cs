using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests {

    [TestFixture]
    public class ManyToOneRelationshipCommandGenerationTests {

        [Test]
        public void insert_with_no_reference_data_inserts_in_parent()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
        [ExpectedException(typeof(NotSupportedException))]
        public void insert_with_reference_data_in_parent_is_not_supported() {
            throw new NotImplementedException();
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
        [ExpectedException(typeof(NotSupportedException))]
        public void insert_with_reference_data_in_parent_and_child_is_not_supported() {
            throw new NotImplementedException();
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
        [ExpectedException(typeof(NotSupportedException))]
        public void insert_with_special_data_in_parent_and_reference_data_in_child_is_not_supported() {
            throw new NotImplementedException();
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
