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
    public class SoftDeleteScriptGenerationTests : BaseTests
    {
        [Test]
        public void soft_delete_only_updates_parent_type()
        {
            var dto = new ParentDto
            {
                ParentKey = 1,
                OneToManyChildDto = new[]
                {
                    new OneToManyChildDto
                    {
                        ChildKey = 2
                    }
                }
            };

            var cache = new DtoMetadataCache();
            var builder = new TransactionBuilder(cache);
            var scripts = builder.BuildUpdateScripts(dto, null, true);

            Assert.AreEqual(1, scripts.Count, "Unexpected number of scripts.");

            var script = scripts[0];
            var sql = script.Buffer.ToString();

            Assert.IsTrue(sql.Contains("UPDATE dbo.[Parent]"), "No update on parent.");

            Assert.AreEqual(1, Regex.Matches(sql, "UPDATE").Count, "Unexpected number of UPDATEs.");
            Assert.AreEqual(0, Regex.Matches(sql, "INSERT").Count, "Should be no INSERTs.");
            Assert.AreEqual(0, Regex.Matches(sql, "DELETE").Count, "Should be no DELETEs.");
            Assert.AreEqual(0, Regex.Matches(sql, "SELECT").Count, "Should be no SELECTs.");
        }
    }
}
