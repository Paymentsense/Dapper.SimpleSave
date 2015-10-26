using System;
using System.Collections.Generic;
using Dapper.SimpleSave.Impl;
using Dapper.SimpleSave.Tests.Dto;
using Dapper.SimpleSave.Tests.GuidDtos;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests.TestScripts
{

    [TestFixture]
    public class OneToOneRelationshipFkOnParentScriptGenerationTests : BaseScriptGenerationTests
    {
        [Test]
        public void insert_with_fk_on_parent_no_reference_data_inserts_rows_in_child_and_parent()
        {
            var scripts = Generate(
                null,
                new ParentDto
                {
                    OneToOneChildDtoNoFk = new OneToOneChildDtoNoFk()
                },
                2);

            scripts.AssertFragment(0, "INSERT INTO dbo.OneToOneChildNoFk");
            scripts.AssertFragment(1, "INSERT INTO dbo.[Parent]");
        }

        [Test]
        public void delete_with_fk_on_parent_no_reference_data_deletes_rows_in_parent_and_child()
        {
            var scripts = Generate(
                new ParentDto
                {
                    ParentKey = 1,
                    OneToOneChildDtoNoFk = new OneToOneChildDtoNoFk
                    {
                        ChildKey = 2
                    }
                },
                null,
                1);

            AssertOnDeletes(
                scripts,
                "DELETE FROM dbo.[Parent]",
                "DELETE FROM dbo.OneToOneChildNoFk");
        }

        [Test]
        public void insert_with_fk_on_parent_no_reference_data_inserts_rows_in_child_and_parent_with_guid_pks()
        {
            var scripts = Generate(
                null,
                new GuidParentDto
                {
                    OneToOneChildDtoNoFk = new GuidOneToOneChildDtoNoFk()
                },
                2);

            scripts.AssertFragment(0, "INSERT INTO dbo.GuidOneToOneChildNoFk");
            scripts.AssertFragment(1, "INSERT INTO dbo.[GuidParent]");
        }

        [Test]
        public void delete_with_fk_on_parent_no_reference_data_deletes_rows_in_parent_and_child_with_guid_pks()
        {
            var scripts = Generate(
                new GuidParentDto
                {
                    ParentKey = Guid.NewGuid(),
                    OneToOneChildDtoNoFk = new GuidOneToOneChildDtoNoFk
                    {
                        ChildKey = Guid.NewGuid()
                    }
                },
                null,
                1);

            AssertOnDeletes(
                scripts,
                "DELETE FROM dbo.[GuidParent]",
                "DELETE FROM dbo.GuidOneToOneChildNoFk");
        }

        private static void AssertOnDeletes(IList<Script> scripts, string parentDeleteSqlFragment, string childDeleteSqlFragment)
        {
            var parentIndex = scripts.AssertFragment(0, parentDeleteSqlFragment);
            var childIndex = scripts.AssertFragment(0, childDeleteSqlFragment);

            Assert.IsTrue(
                parentIndex < childIndex,
                string.Format("Parent should be DELETEd before child in script: {0}", scripts[0].Buffer));
        }

        [Test]
        public void insert_child_with_fk_on_parent_and_existing_parent_inserts_child_and_updates_parent()
        {
            var scripts = Generate(
                new ParentDto
                {
                    ParentKey = 1,
                },
                new ParentDto
                {
                    ParentKey = 1,
                    OneToOneChildDtoNoFk = new OneToOneChildDtoNoFk
                    {
                        ChildKey = 2
                    }
                },
                2);

            scripts.AssertFragment(0, "INSERT INTO dbo.OneToOneChildNoFk");
            scripts.AssertFragment(1, @"UPDATE dbo.[Parent]
SET [OneToOneChildDtoNoFk]");
        }

        [Test]
        public void delete_child_with_fk_on_parent_and_deletes_child_and_updates_parent()
        {
            var scripts = Generate(
                new ParentDto
                {
                    ParentKey = 1,
                    OneToOneChildDtoNoFk = new OneToOneChildDtoNoFk
                    {
                        ChildKey = 2
                    }
                },
                new ParentDto
                {
                    ParentKey = 1,
                },
                1);

            var updateIndex = scripts.AssertFragment(0, @"UPDATE dbo.[Parent]
SET [OneToOneChildDtoNoFk]");
            var deleteIndex = scripts.AssertFragment(0, "DELETE FROM dbo.OneToOneChildNoFk");

            Assert.IsTrue(
                updateIndex < deleteIndex,
                string.Format("UPDATE should appear before DELETE in script: {0}", scripts[0].Buffer));
        }

        [Test]
        public void insert_reference_child_with_fk_on_parent_and_existing_parent_inserts_child_and_updates_parent()
        {
            var scripts = Generate(
                new ParentDto
                {
                    ParentKey = 1,
                },
                new ParentDto
                {
                    ParentKey = 1,
                    OneToOneReferenceChildDtoNoFk = new OneToOneReferenceChildDtoNoFk
                    {
                        ChildKey = 2
                    }
                },
                1);

            scripts.AssertFragment(0, @"UPDATE dbo.[Parent]
SET [OneToOneReferenceChildDtoNoFk]");
        }
    }
}
