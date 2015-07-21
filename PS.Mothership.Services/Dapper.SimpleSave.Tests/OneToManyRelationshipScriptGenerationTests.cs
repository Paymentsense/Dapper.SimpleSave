using Dapper.SimpleSave.Tests.Dto;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests
{
    [TestFixture]
    public class OneToManyRelationshipScriptGenerationTests : BaseScriptGenerationTests
    {
        [Test]
        public void insert_with_no_reference_data_inserts_in_parent_and_child()
        {
            var scripts = Generate(
                null,
                new ParentDto
                {
                    OneToManyChildDto = new [] {new OneToManyChildDto()}
                },
                2);

            scripts.AssertFragment(0, "INSERT INTO dbo.[Parent]");
            scripts.AssertFragment(1, "INSERT INTO dbo.OneToManyChild");
        }
    }
}
