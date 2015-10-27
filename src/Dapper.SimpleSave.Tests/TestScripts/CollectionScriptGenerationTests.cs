using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Dapper.SimpleSave.Tests.Dto;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests.TestScripts
{
    [TestFixture]
    public class CollectionScriptGenerationTests : BaseTests
    {
        [Test]
        public void collection_insert_with_pks_generates_insert_for_all_with_update_contingencies()
        {
            var dtos = new List<ParentDto>() {new ParentDto {ParentKey = 1}, new ParentDto {ParentKey = 2}};

            var logger = new MockSimpleSaveLogger();
            SimpleSaveExtensions.Logger = logger;

            try
            {
                using (IDbConnection connection = new SqlConnection())  //  TODO: localdb connection
                {
                    connection.CreateAll((IEnumerable<ParentDto>) dtos);
                }
            }
            catch (InvalidOperationException)
            {
                //  Because we haven't opened the connection (deliberately - we don't care; we just want to inspect the scripts)
            }

            var scripts = logger.Scripts;
            Assert.AreEqual(2, scripts.Count, "Unexpected number of scripts.");

            foreach (var script in scripts)
            {
                var sql = script.Buffer.ToString();

                Assert.IsTrue(sql.Contains("INSERT INTO dbo.[Parent]"), "No insert on parent.");

                Assert.AreEqual(1, Regex.Matches(sql, "INSERT").Count, "Unexpected number of INSERTs.");
                Assert.AreEqual(1, Regex.Matches(sql, "UPDATE").Count, "Should be one UPDATE.");
                Assert.AreEqual(0, Regex.Matches(sql, "DELETE").Count, "Should be no DELETEs.");
                Assert.AreEqual(3, Regex.Matches(sql, "SELECT").Count, "Should be three SELECTs - one to check for existence of row, and two for returning PK value of INSERTED/UPDATED row.");
            }
        }

        [Test]
        public void collection_update_generates_update_for_all()
        {
            var updates = new List<Tuple<ParentDto, ParentDto>>()
            {
                Tuple.Create(new ParentDto { ParentKey = 1, IsActive = false }, new ParentDto { ParentKey = 1, IsActive = true}),
                Tuple.Create(new ParentDto { ParentKey = 2, IsActive = true }, new ParentDto { ParentKey = 2 , IsActive = false})
            };
            
            var logger = new MockSimpleSaveLogger();
            SimpleSaveExtensions.Logger = logger;

            try
            {
                using (IDbConnection connection = new SqlConnection())
                {
                    connection.UpdateAll(updates);
                }
            }
            catch (InvalidOperationException)
            {
                //  Because we haven't opened the connection (deliberately - we don't care; we just want to inspect the scripts)
            }

            var scripts = logger.Scripts;

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
