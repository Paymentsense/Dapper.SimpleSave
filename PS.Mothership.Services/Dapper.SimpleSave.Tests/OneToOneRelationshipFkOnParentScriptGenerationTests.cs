using Dapper.SimpleSave.Tests.Dto;
using Dapper.SimpleSave.Tests.GuidDtos;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests
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
    }
}
