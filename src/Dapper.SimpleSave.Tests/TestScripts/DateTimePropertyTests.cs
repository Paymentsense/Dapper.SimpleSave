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
        }

        void SimpleSaveExtensions_DifferenceProcessed(object sender, DifferenceEventArgs e)
        {
            e.FurtherChangesMade();
        }
    }
}
