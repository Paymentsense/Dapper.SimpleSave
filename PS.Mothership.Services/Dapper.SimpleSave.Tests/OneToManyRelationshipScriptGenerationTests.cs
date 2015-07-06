using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.SimpleSave.Impl;
using Dapper.SimpleSave.Tests.Dto;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests
{
    [TestFixture]
    public class OneToManyRelationshipScriptGenerationTests
    {
        [Test]
        public void insert_with_no_reference_data_inserts_in_parent_and_child()
        {
            var newDto = new ParentDto {
                OneToManyChildDto = new [] {new OneToManyChildDto()}
            };

            var cache = new DtoMetadataCache();
            var builder = new TransactionBuilder(cache);
            var scripts = builder.BuildUpdateScripts(null, newDto);
            
            Assert.AreEqual(
                2,
                scripts.Count,
                "Unexpected number of scripts.");

            Assert.IsTrue(
                scripts[0].Buffer.ToString().Contains("INSERT INTO dbo.[Parent]"),
                "Should INSERT into parent table.");

            Assert.IsTrue(
                scripts[1].Buffer.ToString().Contains("INSERT INTO dbo.OneToManyChild"),
                "Should INSERT into child table.");
        }
    }
}
