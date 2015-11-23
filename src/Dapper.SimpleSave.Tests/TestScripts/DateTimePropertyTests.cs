using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.SimpleSave.Tests.RealisticDtos;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests.TestScripts
{
    [TestFixture]
    public class DateTimePropertyTests : BaseTests
    {
        [Test]
        public void changes_to_date_time_only_appear_once()
        {
            var dto1 = new DateTimePropertiesDto
            {
                DateTimePropertiesKey = 1,
                DateTimeProperty = DateTime.Now,
                DateTimeOffsetProperty = DateTimeOffset.Now.AddHours(1)
            };

            var dto2 = new DateTimePropertiesDto
            {
                DateTimePropertiesKey = 1,
                DateTimeProperty = dto1.DateTimeProperty.GetValueOrDefault().AddHours(3),
                DateTimeOffsetProperty = dto1.DateTimeOffsetProperty.GetValueOrDefault().AddHours(3)
            };

            check_changes_only_appear_once(dto1, dto2);
        }

        private void check_changes_only_appear_once(DateTimePropertiesDto dto1, DateTimePropertiesDto dto2)
        {
            var logger = new MockSimpleSaveLogger();
            SimpleSaveExtensions.Logger = logger;
            SimpleSaveExtensions.DifferenceProcessed += SimpleSaveExtensions_DifferenceProcessed;

            try
            {
                using (IDbConnection connection = new SqlConnection())
                {
                    connection.Update(dto1, dto2);
                }
            }
            catch (InvalidOperationException)
            {
                //  Don't care
            }

            var scripts = logger.Scripts;
            Assert.AreEqual(1, scripts.Count, "Unexpected number of scripts.");
            var sql = scripts[0].Buffer.ToString();
            Assert.AreEqual(sql.IndexOf("[DateTimeProperty]"), sql.LastIndexOf("[DateTimeProperty]"), "Should only be one occurence of [DateTimeProperty].");
            Assert.AreEqual(sql.IndexOf("[DateTimeOffsetProperty]"), sql.LastIndexOf("[DateTimeOffsetProperty]"), "Should only be one occurence of [DateTimeOffsetProperty].");
        }

        void SimpleSaveExtensions_DifferenceProcessed(object sender, DifferenceEventArgs e)
        {
            var diff = e.Difference;
            var obj = diff.NewOwner as DateTimePropertiesDto;
            if (obj != null)
            {
                obj.DateTimeOffsetProperty = DateTimeOffset.Now.AddHours(10);
            }
            
            e.FurtherChangesMade();
        }
    }
}
