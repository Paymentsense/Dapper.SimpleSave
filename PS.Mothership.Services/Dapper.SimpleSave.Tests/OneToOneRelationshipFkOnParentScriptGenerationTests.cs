using Dapper.SimpleSave.Impl;
using Dapper.SimpleSave.Tests.Dto;
using Dapper.SimpleSave.Tests.GuidDtos;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests
{

    [TestFixture]
    public class OneToOneRelationshipFkOnParentScriptGenerationTests
    {
        [Test]
        public void insert_with_fk_on_parent_no_reference_data_inserts_rows_in_child_and_parent()
        {
            var newDto = new ParentDto
            {
                OneToOneChildDtoNoFk = new OneToOneChildDtoNoFk()
            };

            var cache = new DtoMetadataCache();
            var builder = new TransactionBuilder(cache);
            var scripts = builder.BuildUpdateScripts(null, newDto);
            
            Assert.AreEqual(
                2,
                scripts.Count,
                "Unexpected number of scripts.");

            Assert.IsTrue(
                scripts[0].Buffer.ToString().Contains("INSERT INTO dbo.OneToOneChildNoFk"),
                "Should INSERT into child table.");

            Assert.IsTrue(
                scripts[1].Buffer.ToString().Contains("INSERT INTO dbo.[Parent]"),
                "Should INSERT into parent table.");
        }

        [Test]
        public void insert_with_fk_on_parent_no_reference_data_inserts_rows_in_child_and_parent_with_guid_pks()
        {
            var newDto = new GuidParentDto
            {
                OneToOneChildDtoNoFk = new GuidOneToOneChildDtoNoFk()
            };

            var cache = new DtoMetadataCache();
            var builder = new TransactionBuilder(cache);
            var scripts = builder.BuildUpdateScripts(null, newDto);
            
            Assert.AreEqual(
                2,
                scripts.Count,
                "Unexpected number of scripts.");

            Assert.IsTrue(
                scripts[0].Buffer.ToString().Contains("INSERT INTO dbo.GuidOneToOneChildNoFk"),
                "Should INSERT into child table.");

            Assert.IsTrue(
                scripts[1].Buffer.ToString().Contains("INSERT INTO dbo.[GuidParent]"),
                "Should INSERT into parent table.");
        }
    }
}
