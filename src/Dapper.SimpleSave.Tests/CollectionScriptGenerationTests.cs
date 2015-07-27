using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dapper.SimpleSave.Impl;
using Dapper.SimpleSave.Tests.Dto;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests
{
    [TestFixture]
    public class CollectionScriptGenerationTests : BaseTests
    {
        [Test]
        public void collection_insert_generates_insert_for_all()
        {
            var dtos = new List<ParentDto>() {new ParentDto {ParentKey = 1}, new ParentDto {ParentKey = 2}};

            var cache = new DtoMetadataCache();
            var builder = new TransactionBuilder(cache);
            var scripts = builder.BuildUpdateScripts(new List<ParentDto>(), dtos);

            Assert.AreEqual(2, scripts.Count, "Unexpected number of scripts.");

            foreach (var script in scripts)
            {
                var sql = script.Buffer.ToString();

                Assert.IsTrue(sql.Contains("INSERT dbo.[Parent]"), "No insert on parent.");

                Assert.AreEqual(1, Regex.Matches(sql, "INSERT").Count, "Unexpected number of INSERTs.");
                Assert.AreEqual(0, Regex.Matches(sql, "UPDATE").Count, "Should be no UPDATEs.");
                Assert.AreEqual(0, Regex.Matches(sql, "DELETE").Count, "Should be no DELETEs.");
                Assert.AreEqual(0, Regex.Matches(sql, "SELECT").Count, "Should be no SELECTs.");
            }
        }

        [Test]
        public void collection_update_generates_update_for_all()
        {
            var oldDtos = new List<ParentDto>() {new ParentDto { ParentKey = 1, IsActive = false }, new ParentDto { ParentKey = 2, IsActive = true } };
            var newDtos = new List<ParentDto>() {new ParentDto { ParentKey = 1, IsActive = true}, new ParentDto { ParentKey = 2 , IsActive = false} };

            var cache = new DtoMetadataCache();
            var builder = new TransactionBuilder(cache);
            var scripts = builder.BuildUpdateScripts(oldDtos, newDtos);

            Assert.AreEqual(2, scripts.Count, "Unexpected number of scripts.");

            foreach (var script in scripts)
            {
                var sql = script.Buffer.ToString();

                Assert.IsTrue(sql.Contains("UPDATE dbo.[Parent]"), "No update on parent.");

                Assert.AreEqual(1, Regex.Matches(sql, "UPDATE").Count, "Unexpected number of UPDATEs.");
                Assert.AreEqual(0, Regex.Matches(sql, "INSERT").Count, "Should be no INSERTs.");
                Assert.AreEqual(0, Regex.Matches(sql, "DELETE").Count, "Should be no DELETEs.");
                Assert.AreEqual(0, Regex.Matches(sql, "SELECT").Count, "Should be no SELECTs.");
            }
        }
    }
}
