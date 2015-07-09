using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.SimpleSave.Impl;
using Dapper.SimpleSave.Tests.GuidDtos;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests
{
    [TestFixture]
    public class GuidOneToManyRelationshipScriptGenerationTests
    {
        [Test]
        public void insert_with_no_reference_data_inserts_in_parent_and_child()
        {
            var newDto = new GuidParentDto {
                ParentKey = Guid.NewGuid(),
                OneToManyChildDto = new [] {new GuidOneToManyChildDto
                {
                    ChildKey = Guid.NewGuid()
                }}
            };

            var cache = new DtoMetadataCache();
            var builder = new TransactionBuilder(cache);
            var scripts = builder.BuildUpdateScripts(null, newDto);
            
            Assert.AreEqual(
                2,
                scripts.Count,
                "Unexpected number of scripts.");

            Assert.IsTrue(
                scripts[0].Buffer.ToString().Contains("INSERT INTO dbo.[GuidParent]"),
                "Should INSERT into parent table.");

            Assert.IsTrue(
                scripts[1].Buffer.ToString().Contains("INSERT INTO dbo.GuidOneToManyChild"),
                "Should INSERT into child table.");
        }
    }
}
