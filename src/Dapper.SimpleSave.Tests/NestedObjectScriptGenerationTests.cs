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
                        TradingAddress = new FullAddressDto()   //  We want this one blank.
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
            Assert.AreEqual(5, scripts.Count, "Unexpected number of scripts.");

            Assert.IsTrue(scripts[0].Buffer.ToString().Contains("INSERT INTO [app].[APPLICATION_MST]"));
            Assert.IsTrue(scripts[1].Buffer.ToString().Contains("INSERT INTO [app].[LEGAL_INFO_MST]"));
            //  Address has to go in first or it can't be referenced, which is where the problem lies
            Assert.IsTrue(scripts[2].Buffer.ToString().Contains("INSERT INTO [gen].[ADDRESS_MST]"));
            Assert.IsTrue(scripts[3].Buffer.ToString().Contains("INSERT INTO [app].[LOCATION_MST]"));
            Assert.IsTrue(scripts[4].Buffer.ToString().Contains("INSERT INTO [opp].[OPPORTUNITY_MST]"));
        }

        [Test]
        public void delete_offer_deletes_equipment_offer_descendents()
        {
            var offerGuid = Guid.NewGuid();
            var equipmentOfferGuid = Guid.NewGuid();
            var offer = new OfferDto
            {
                OfferGuid = offerGuid,
                Equipment = new List<EquipmentOfferTrnDao>
                {
                    new EquipmentOfferTrnDao
                    {
                        EquipmentOfferGuid = equipmentOfferGuid,
                        OfferGuid = offerGuid,
                        EquipmentOptions = new List<EquipmentOptionTrnDao>
                        {
                            new EquipmentOptionTrnDao
                            {
                                EquipmentOptionTrnGuid = Guid.NewGuid(),
                                EquipmentOfferGuid = equipmentOfferGuid,
                                Quantity = 23
                            }
                        }
                    }
                },
                OfferReference = "Test offer",
                OpportunityGuid = Guid.NewGuid()
            };

            var logger = new MockSimpleSaveLogger();
            SimpleSaveExtensions.Logger = logger;
            
            try
            {
                using (IDbConnection connection = new SqlConnection())
                {
                    connection.Delete(offer);
                }
            }
            catch (InvalidOperationException)
            {
                //  Don't care
            }

            var scripts = logger.Scripts;
            Assert.AreEqual(1, scripts.Count, "Unexpected number of scripts.");

            var sql = scripts[0].Buffer.ToString();

            var deleteFromEquipmentOptionIndex = sql.IndexOf("DELETE FROM [opp].[EQUIPMENT_OPTION_TRN]");
            Assert.IsTrue(deleteFromEquipmentOptionIndex >= 0, "No delete from [opp].[EQUIPMENT_OPTION_TRN]");

            var deleteFromEquipmentOfferIndex = sql.IndexOf("DELETE FROM [opp].[EQUIPMENT_OFFER_TRN]");
            Assert.IsTrue(deleteFromEquipmentOfferIndex >= 0, "No delete from [opp].[EQUIPMENT_OFFER_TRN]");

            var deleteFromOfferIndex = sql.IndexOf("DELETE FROM [opp].[OFFER_TRN]");
            Assert.IsTrue(deleteFromOfferIndex >= 0, "No delete from [opp].[OFFER_TRN]");

            Assert.IsTrue(
                deleteFromEquipmentOptionIndex < deleteFromEquipmentOfferIndex,
                "Delete from [opp].[EQUIPMENT_OPTION_TRN] should appear before delete from [opp].[EQUIPMENT_OFFER_TRN]");

            Assert.IsTrue(
                deleteFromEquipmentOfferIndex < deleteFromOfferIndex,
                "Delete from [opp].[EQUIPMENT_OFFER_TRN] should appear before delete from [opp].[OFFER_TRN]");
        }
    }
}
