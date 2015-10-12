using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.SimpleSave.Tests.RealisticDtos;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests
{
    [TestFixture]
    public class NestedObjectScriptGenerationTests : BaseTests
    {
        private ApplicationDetailsDto CreateTestApplication()
        {
            var merchantGuid = Guid.NewGuid();
            var application = new ApplicationDetailsDto
            {
                ApplicationReference = "Throwback Thursday",
                LegalInfo = new LegalInfoDto
                {
                    MerchantLegalInfo = new MerchantLegalInfoDto
                    {
                        MerchantGuid = merchantGuid,
                        RegisteredName = "Doctor Sleep Ltd",
                    },
                    BacsName = "Playlistadelic",
                    CurrentOverdraftLimit = 2000000,
                },
                Locations = new List<LocationDto>()
                {
                    new LocationDto()
                    {
                        BusinessName = "Throwback Thursday Will Kick Your Butt Ltd",
                        Opportunities = new List<OpportunityDto>()
                        {
                            new OpportunityDto()
                            {
                                AcquirerLocationMID = "Hello"
                            }
                        },
                        LocationReference = "Our Pimpin' HQ",
                    }
                }
            };

            return application;
        }

        [Test]
        public void insert_application_with_nested_children_inserts_children()
        {
            var application = CreateTestApplication();
            var logger = new MockSimpleSaveLogger();
            SimpleSaveExtensions.Logger = logger;

            try
            {
                using (IDbConnection connection = new SqlConnection())
                {
                    connection.Create(application);
                }
            }
            catch (InvalidOperationException)
            {
                //  Don't care
            }

            var scripts = logger.Scripts;
            Assert.AreEqual(4, scripts.Count, "Unexpected number of scripts.");

            Assert.IsTrue(scripts[0].Buffer.ToString().Contains("INSERT INTO [app].[APPLICATION_MST]"));
            Assert.IsTrue(scripts[1].Buffer.ToString().Contains("INSERT INTO [app].[LEGAL_INFO_MST]"));
            Assert.IsTrue(scripts[2].Buffer.ToString().Contains("INSERT INTO [app].[LOCATION_MST]"));
            Assert.IsTrue(scripts[3].Buffer.ToString().Contains("INSERT INTO [opp].[OPPORTUNITY_MST]"));
        }
    }
}
