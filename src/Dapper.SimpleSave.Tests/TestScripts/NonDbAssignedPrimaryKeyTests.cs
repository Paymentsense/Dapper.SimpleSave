using System;
using System.Data.SqlClient;
using Dapper.SimpleSave.Tests.RealisticDtos;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests.TestScripts
{
    [TestFixture]
    public class NonDbAssignedPrimaryKeyTests : BaseTests
    {
        [Test]
        public void user_assigned_primary_key_is_included_in_insert()
        {
            var dto = new AuthorisationFee
            {
                FieldItemKey = 4096,
                Value = 1000,
                Revenue = 100,
                Cost = 1500,
                CalculatorVersionKey = 23,
                Name = "Dr Doolittle"
            };

            var logger = CreateMockLogger();
            try
            {
                using (var connection = new SqlConnection())
                {
                    connection.Create(dto);
                }
            }
            catch (InvalidOperationException ioe)
            {
                Assert.IsTrue(ioe.Message.Contains(
                    "Invalid operation. The connection is closed."),
                    string.Format("Right type of exception, wrong message: {0}\r\n{1}", ioe.Message, ioe.StackTrace));
            }

            var scripts = logger.Scripts;
            Assert.AreEqual(1, scripts.Count, "Unexpected number of scripts.");

            var sql = scripts[0].Buffer.ToString();
            Assert.IsTrue(sql.Contains("FieldItemKey"), "Should insert into PK column.");
            Assert.IsFalse(sql.Contains("SELECT SCOPE_IDENTITY();"), "Should not return PK value.");
        }
    }
}
