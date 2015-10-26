using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper.SimpleSave.Impl;
using Dapper.SimpleSave.Tests.RealisticDtos;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests.TestScripts
{
    [TestFixture]
    public class NestedObjectScriptGenerationTests : BaseTests
    {
        private readonly Guid merchantGuid = Guid.NewGuid();
        private readonly Guid applicationGuid = Guid.NewGuid();
        private readonly Guid locationGuid = Guid.NewGuid();
        private readonly Guid opportunityGuid = Guid.NewGuid();
        private readonly Guid offerGuid = Guid.NewGuid();

        private ApplicationDetailsDto CreateTestApplication()
        {
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

        [Test]
        public void insert_offer_with_gateway_offer_should_only_insert_offer()
        {
            var offer = new OfferDto
            {
                GatewayOffer = new GatewayOfferDto
                {
                    IsBilledYearly = true,
                    PeriodicCharge = 100
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
                    connection.Create(offer);
                }
            }
            catch (InvalidOperationException)
            {
                //  Don't care
            }

            var scripts = logger.Scripts;
            Assert.AreEqual(1, scripts.Count, "Unexpected number of scripts.");

            var sql = scripts[0].Buffer.ToString();

            Assert.IsTrue(
                sql.Contains("INSERT INTO [opp].[OFFER_TRN]"),
                "Should insert into OFFER_TRN.");

            Assert.IsFalse(
                sql.Contains("[opp].[GATEWAY_OFFER_TRN]"),
                "Should not insert into GATEWAY_OFFER_TRN");
        }

        private AcquiringOfferTrnDao CreateAcquiringOfferTrnDao()
        {
            var dao = new AcquiringOfferTrnDao
            {
                AcquiringOfferKey = 1,
                TypeOfTransaction = new TypeOfTransactionLutDao()
                {
                    FieldItemKey = 2,
                    FieldItem = new FieldItemLutDao()
                    {
                        FieldItemKey = 2,
                        Name = "ECOM",
                        Description = "ECOM"
                    },
                    TypeOfTransactionEnumKey = OppTypeOfTransactionEnum.ECOM
                }
            };
            return dao;
        }

        [Test]
        public void diff_shows_differences_between_nested_objects()
        {
            var dao1 = CreateAcquiringOfferTrnDao();
            var dao2 = CreateAcquiringOfferTrnDao();
            dao2.TypeOfTransaction = new TypeOfTransactionLutDao()
            {
                FieldItemKey = 0,
                FieldItem = new FieldItemLutDao()
                {
                    FieldItemKey = 0,
                },
                TypeOfTransactionEnumKey = OppTypeOfTransactionEnum.None
            };

            var differ = new Differ(new DtoMetadataCache());
            var diffs = differ.Diff(dao1, dao2);

            Assert.IsTrue(diffs.Count > 0, "Should have found some differences.");
        }

        private ApplicationDetailsDto CreateApplicationForUpdateWithOffer()
        {
            var application = CreateTestApplication();
            application.ApplicationGuid = applicationGuid;
            application.Locations[0].LocationGuid = locationGuid;
            application.Locations[0].Opportunities[0].OpportunityGuid = opportunityGuid;
            application.Locations[0].Opportunities[0].CurrentOffer = new OfferDto
            {
                OfferGuid = offerGuid,
                OfferReference = "The sun will come out tomorrow"
            };
            return application;
        }

        private ApplicationDetailsDto CreateApplicationForUpdateWithAcquiringOffer()
        {
            var application = CreateApplicationForUpdateWithOffer();
            application.Locations[0].Opportunities[0].CurrentOffer.AcquiringOffer = CreateAcquiringOfferTrnDao();
            return application;
        }

        [Test]
        public void diff_does_not_drill_past_simple_save_ignore_where_differences_beneath()
        {
            var dao1 = CreateApplicationForUpdateWithAcquiringOffer();
            var dao2 = CreateApplicationForUpdateWithAcquiringOffer();

            dao2.Locations[0].Opportunities[0].CurrentOffer.AcquiringOffer.TypeOfTransaction = new TypeOfTransactionLutDao()
            {
                FieldItemKey = 0,
                FieldItem = new FieldItemLutDao()
                {
                    FieldItemKey = 0,
                },
                TypeOfTransactionEnumKey = OppTypeOfTransactionEnum.None
            };

            var differ = new Differ(new DtoMetadataCache());
            var diffs = differ.Diff(dao1, dao2);

            Assert.AreEqual(0, diffs.Count, "Should not have found any differences.");
        }
    }
}
