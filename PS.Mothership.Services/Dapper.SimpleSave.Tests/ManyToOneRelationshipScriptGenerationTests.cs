using Dapper.SimpleSave.Tests.Dto;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests
{

    [TestFixture]
    class ManyToOneRelationshipScriptGenerationTests : BaseScriptGenerationTests
    {
        [Test]
        public void insert_child_row_updates_parent_with_empty_value_to_start()
        {
            var scripts = Generate(
                new ParentDto
                {
                    ParentKey = 1
                },
                new ParentDto
                {
                    ParentKey = 1,
                    ManyToOneChildDto = new ManyToOneChildDto
                    {
                        ChildKey = 2
                    }
                },
                1);

            scripts.AssertFragment(0, @"UPDATE dbo.[Parent]
SET [ManyToOneChildDto]");
        }

        [Test]
        public void insert_child_row_updates_parent_with_non_empty_value_to_start()
        {
            var scripts = Generate(
                new ParentDto
                {
                    ParentKey = 1,
                    ManyToOneChildDto = new ManyToOneChildDto
                    {
                        ChildKey = 2
                    }
                },
                new ParentDto
                {
                    ParentKey = 1,
                    ManyToOneChildDto = new ManyToOneChildDto
                    {
                        ChildKey = 3
                    }
                },
                1);

            scripts.AssertFragment(0, @"UPDATE dbo.[Parent]
SET [ManyToOneChildDto]");
        }

        [Test]
        public void delete_child_row_updates_parent()
        {
            var scripts = Generate(
                new ParentDto
                {
                    ParentKey = 1,
                    ManyToOneChildDto = new ManyToOneChildDto
                    {
                        ChildKey = 2
                    }
                },
                new ParentDto
                {
                    ParentKey = 1
                },
                1);

            scripts.AssertFragment(0, @"UPDATE dbo.[Parent]
SET [ManyToOneChildDto]");
        }
    }
}
