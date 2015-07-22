using System;
using Dapper.SimpleSave.Tests.GuidDtos;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests
{
    [TestFixture]
    public class GuidOneToManyRelationshipScriptGenerationTests : BaseScriptGenerationTests
    {
        [Test]
        public void insert_with_no_reference_data_inserts_in_parent_and_child()
        {
            var scripts = Generate(
                null,
                new GuidParentDto
                {
                    ParentKey = Guid.NewGuid(),
                    OneToManyChildDto = new [] {new GuidOneToManyChildDto
                    {
                        ChildKey = Guid.NewGuid()
                    }}
                },
                2);

            scripts.AssertFragment(0, "INSERT INTO dbo.[GuidParent]");
            scripts.AssertFragment(1, "INSERT INTO dbo.GuidOneToManyChild");
        }
    }
}
