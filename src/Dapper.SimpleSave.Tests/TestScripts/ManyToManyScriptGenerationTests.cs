using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.SimpleSave.Impl;
using Dapper.SimpleSave.Tests.RealisticDtos;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests.TestScripts
{
    [TestFixture]
    public class ManyToManyScriptGenerationTests : BaseTests
    {
        [Test]
        public void delete_link_by_removing_child_does_not_delete_child_row_in_database()
        {
            var user = new UserDto()
            {
                UserKey = 27,
                Username = "john.doe",
                FirstName = "John",
                LastName = "Doe"
            };

            var users = new List<UserDto>() { user };

            var oldObject = new TeleAppointerDto
            {
                UserKey = 555,
                Campaigns = new List<CampaignDto>()
                {
                    new CampaignDto()
                    {
                        CampaignKey = 1,
                        DaysSinceMerchantLastUpdated = 2,
                        Description = "First campaign",
                        Name = "First",
                        CurrentlyAssignedTeleAppointers = users
                    },
                    new CampaignDto()
                    {
                        CampaignKey = 2,
                        DaysSinceMerchantLastUpdated = 3,
                        Description = "Second campaign",
                        Name = "Second",
                        CurrentlyAssignedTeleAppointers = users
                    },
                    new CampaignDto()
                    {
                        CampaignKey = 3,
                        DaysSinceMerchantLastUpdated = 4,
                        Description = "Third campaign",
                        Name = "Third",
                        CurrentlyAssignedTeleAppointers = users
                    }
                }
            };

            var newObject = new TeleAppointerDto
            {
                UserKey = 555,
                Campaigns = new List<CampaignDto>()
                {
                    new CampaignDto()
                    {
                        CampaignKey = 4,
                        DaysSinceMerchantLastUpdated = 5,
                        Description = "Fourth campaign",
                        Name = "Fourth",
                        CurrentlyAssignedTeleAppointers = users
                    }
                }
            };

            var logger = new MockSimpleSaveLogger();
            SimpleSaveExtensions.Logger = logger;

            try
            {
                using (IDbConnection connection = new SqlConnection())
                {
                    connection.Update(oldObject, newObject);
                }
            }
            catch (InvalidOperationException)
            {
                //  Don't care
            }

            var scripts = logger.Scripts;
            Assert.AreEqual(1, scripts.Count, "Unexpected number of scripts.");

            scripts.AssertFragment(0, "DELETE FROM tele.TELE_APPOINTER_CAMPAIGN_LNK");
            scripts.AssertFragment(0, "INSERT INTO tele.TELE_APPOINTER_CAMPAIGN_LNK");
            scripts.AssertNoFragment(0, "DELETE FROM [tele].CAMPAIGN_MST");
            scripts.AssertNoFragment(0, "DELETE FROM [user].USER_MST");
        }
    }
}
