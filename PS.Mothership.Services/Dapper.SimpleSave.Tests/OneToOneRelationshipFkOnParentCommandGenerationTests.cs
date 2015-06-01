using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests {

    [TestFixture]
    public class OneToOneRelationshipFkOnParentCommandGenerationTests
    {
        [Test]
        public void insert_with_fk_on_parent_no_reference_data_inserts_rows_in_child_and_parent()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
        [ExpectedException(typeof(NotSupportedException))]
        public void insert_with_fk_on_parent_and_reference_data_in_parent_is_not_supported()
        {
            throw new NotImplementedException();
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
        [ExpectedException(typeof(NotSupportedException))]
        public void insert_with_fk_on_parent_and_special_data_in_parent_is_not_supported()
        {
            throw new NotImplementedException();
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
        [ExpectedException(typeof(NotSupportedException))]
        public void insert_with_fk_on_parent_and_reference_data_in_both_parent_and_child_is_not_supported()
        {
            throw new NotImplementedException();
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
