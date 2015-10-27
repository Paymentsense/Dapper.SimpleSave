using System;
using Dapper.SimpleSave.Tests.Dto;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests.TestScripts
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

        [Test]
        public void insert_child_with_existing_parent_sets_parent_pk_as_fk_value_on_child()
        {
            var oldDto = new ParentDto
            {
                ParentKey = 1,
                OneToManyChildDto = new[]
                {
                    new OneToManyChildDto
                    {
                        ChildKey = 2,
                        ParentDtoKey = 1
                    }
                }
            };

            var scripts = Generate(
                oldDto,
                new ParentDto
                {
                    ParentKey = 1,
                    OneToManyChildDto = new []
                    {
                        new OneToManyChildDto
                        {
                            ChildKey = 2,
                            ParentDtoKey = 1
                        },
                        new OneToManyChildDto
                        {
                            ChildKey = 3,
                            ParentDtoKey = 1
                        }
                    }
                },
                1);

            scripts.AssertFragment(0, "INSERT INTO dbo.OneToManyChild");

            Assert.AreEqual(
                1,
                ((Func<object>) scripts[0].Parameters["p7"].Item2)(),
                "Invalid FK value in child - should be same as parent key.");
        }
    }
}
