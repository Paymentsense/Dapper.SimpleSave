using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.App
{
    
    [DataContract]
    public enum AppFirstDataApplicationStatusEnum : long
    {
       [Description("Account failed in the Validation Handler")][EnumMember]AccountfailedintheValidationHandler = 0,
       [Description("Pending internal validation in VAPP")][EnumMember]PendinginternalvalidationinVAPP = 1,
       [Description("Account Boarding In Progress")][EnumMember]AccountBoardingInProgress = 2,
       [Description("Account Boarding In Progress1")][EnumMember]AccountBoardingInProgress1 = 3,
       [Description("Merchant data successfully updated")][EnumMember]Merchantdatasuccessfullyupdated = 100,
       [Description("Order Sent to HP")][EnumMember]OrderSenttoHP = 110,
       [Description("Internal")][EnumMember]Internal = 111,
       [Description("Order Sent To Vendor./Credit Approved and Terminal Id(s) received from vendor.")][EnumMember]OrderSentToVendor = 120,
       [Description("Order Sent to HP1")][EnumMember]OrderSenttoHP1 = 350,
       [Description("Received Update HP")][EnumMember]ReceivedUpdateHP = 356,
       [Description("Ord Confmd")][EnumMember]OrdConfmd = 358,
       [Description("Send of Merchant data to mainframe failed")][EnumMember]SendofMerchantdatatomainframefailed = 505,
       [Description("Merchant data imported sucessfully into MA")][EnumMember]MerchantdataimportedsucessfullyintoMA = 510,
       [Description("Merchant data sent to MAI")][EnumMember]MerchantdatasenttoMAI = 515,
       [Description("RSP30 Executed Successfully")][EnumMember]RSP30ExecutedSuccessfully = 700,
       [Description("General MAI Error")][EnumMember]GeneralMAIError = 710,
       [Description("Duplicate Merchant Record")][EnumMember]DuplicateMerchantRecord = 714,
       [Description("RSP30 Execution failed")][EnumMember]RSP30Executionfailed = 716,
       [Description("RSP 30 SE Update successful")][EnumMember]RSP30SEUpdatesuccessful = 750,
       [Description("Credit Officer ID")][EnumMember]CreditOfficerID = 762,
       [Description("Emerald 2.0 Account Approved for Production")][EnumMember]Emerald20AccountApprovedforProduction = 763,
       [Description("Emerald 2.0 Account Approved for Production1")][EnumMember]Emerald20AccountApprovedforProduction1 = 765,
       [Description("Referred to Credit Help Desk")][EnumMember]ReferredtoCreditHelpDesk = 766,
       [Description("Referred to Credit Officer for Full Review")][EnumMember]ReferredtoCreditOfficerforFullReview = 767,
       [Description("Account Declined by Credit Officer")][EnumMember]AccountDeclinedbyCreditOfficer = 768,
        
    }    
    
    public class AppFirstDataApplicationStatus
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long FirstDataStatusKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
		public bool IsFinal {get;set;}
		public long ApplicationStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class AppFirstDataApplicationStatusCollection
    {
        private static List<AppFirstDataApplicationStatus> _list; 
        public static List<AppFirstDataApplicationStatus> AppFirstDataApplicationStatusList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<AppFirstDataApplicationStatus>
                        {
                            new AppFirstDataApplicationStatus
							{
								EnumValue = 0,
								EnumName = "AccountfailedintheValidationHandler",
								EnumDescription = "Account failed in the Validation Handler",
								FirstDataStatusKey = 0,
								RecStatusKey = (GenRecStatusEnum)1,
								IsFinal = false,
								ApplicationStatusKey = 90
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 1,
								EnumName = "PendinginternalvalidationinVAPP",
								EnumDescription = "Pending internal validation in VAPP",
								FirstDataStatusKey = 1,
								RecStatusKey = (GenRecStatusEnum)1,
								IsFinal = false,
								ApplicationStatusKey = 70
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 2,
								EnumName = "AccountBoardingInProgress",
								EnumDescription = "Account Boarding In Progress",
								FirstDataStatusKey = 2,
								RecStatusKey = (GenRecStatusEnum)1,
								IsFinal = false,
								ApplicationStatusKey = 80
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 3,
								EnumName = "AccountBoardingInProgress1",
								EnumDescription = "Account Boarding In Progress1",
								FirstDataStatusKey = 3,
								RecStatusKey = (GenRecStatusEnum)1,
								IsFinal = false,
								ApplicationStatusKey = 80
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 100,
								EnumName = "Merchantdatasuccessfullyupdated",
								EnumDescription = "Merchant data successfully updated",
								FirstDataStatusKey = 100,
								RecStatusKey = (GenRecStatusEnum)1,
								IsFinal = false,
								ApplicationStatusKey = 0
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 110,
								EnumName = "OrderSenttoHP",
								EnumDescription = "Order Sent to HP",
								FirstDataStatusKey = 110,
								RecStatusKey = (GenRecStatusEnum)1,
								IsFinal = false,
								ApplicationStatusKey = 0
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 111,
								EnumName = "Internal",
								EnumDescription = "Internal",
								FirstDataStatusKey = 111,
								RecStatusKey = (GenRecStatusEnum)1,
								IsFinal = false,
								ApplicationStatusKey = 0
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 120,
								EnumName = "OrderSentToVendor",
								EnumDescription = "Order Sent To Vendor./Credit Approved and Terminal Id(s) received from vendor.",
								FirstDataStatusKey = 120,
								RecStatusKey = (GenRecStatusEnum)1,
								IsFinal = false,
								ApplicationStatusKey = 0
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 350,
								EnumName = "OrderSenttoHP1",
								EnumDescription = "Order Sent to HP1",
								FirstDataStatusKey = 350,
								RecStatusKey = (GenRecStatusEnum)1,
								IsFinal = false,
								ApplicationStatusKey = 0
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 356,
								EnumName = "ReceivedUpdateHP",
								EnumDescription = "Received Update HP",
								FirstDataStatusKey = 356,
								RecStatusKey = (GenRecStatusEnum)1,
								IsFinal = false,
								ApplicationStatusKey = 0
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 358,
								EnumName = "OrdConfmd",
								EnumDescription = "Ord Confmd",
								FirstDataStatusKey = 358,
								RecStatusKey = (GenRecStatusEnum)1,
								IsFinal = false,
								ApplicationStatusKey = 0
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 505,
								EnumName = "SendofMerchantdatatomainframefailed",
								EnumDescription = "Send of Merchant data to mainframe failed",
								FirstDataStatusKey = 505,
								RecStatusKey = (GenRecStatusEnum)1,
								IsFinal = false,
								ApplicationStatusKey = 0
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 510,
								EnumName = "MerchantdataimportedsucessfullyintoMA",
								EnumDescription = "Merchant data imported sucessfully into MA",
								FirstDataStatusKey = 510,
								RecStatusKey = (GenRecStatusEnum)1,
								IsFinal = false,
								ApplicationStatusKey = 0
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 515,
								EnumName = "MerchantdatasenttoMAI",
								EnumDescription = "Merchant data sent to MAI",
								FirstDataStatusKey = 515,
								RecStatusKey = (GenRecStatusEnum)1,
								IsFinal = false,
								ApplicationStatusKey = 0
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 700,
								EnumName = "RSP30ExecutedSuccessfully",
								EnumDescription = "RSP30 Executed Successfully",
								FirstDataStatusKey = 700,
								RecStatusKey = (GenRecStatusEnum)1,
								IsFinal = false,
								ApplicationStatusKey = 0
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 710,
								EnumName = "GeneralMAIError",
								EnumDescription = "General MAI Error",
								FirstDataStatusKey = 710,
								RecStatusKey = (GenRecStatusEnum)1,
								IsFinal = false,
								ApplicationStatusKey = 0
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 714,
								EnumName = "DuplicateMerchantRecord",
								EnumDescription = "Duplicate Merchant Record",
								FirstDataStatusKey = 714,
								RecStatusKey = (GenRecStatusEnum)1,
								IsFinal = false,
								ApplicationStatusKey = 0
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 716,
								EnumName = "RSP30Executionfailed",
								EnumDescription = "RSP30 Execution failed",
								FirstDataStatusKey = 716,
								RecStatusKey = (GenRecStatusEnum)1,
								IsFinal = false,
								ApplicationStatusKey = 0
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 750,
								EnumName = "RSP30SEUpdatesuccessful",
								EnumDescription = "RSP 30 SE Update successful",
								FirstDataStatusKey = 750,
								RecStatusKey = (GenRecStatusEnum)1,
								IsFinal = false,
								ApplicationStatusKey = 0
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 762,
								EnumName = "CreditOfficerID",
								EnumDescription = "Credit Officer ID",
								FirstDataStatusKey = 762,
								RecStatusKey = (GenRecStatusEnum)1,
								IsFinal = false,
								ApplicationStatusKey = 0
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 763,
								EnumName = "Emerald20AccountApprovedforProduction",
								EnumDescription = "Emerald 2.0 Account Approved for Production",
								FirstDataStatusKey = 763,
								RecStatusKey = (GenRecStatusEnum)1,
								IsFinal = false,
								ApplicationStatusKey = 0
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 765,
								EnumName = "Emerald20AccountApprovedforProduction1",
								EnumDescription = "Emerald 2.0 Account Approved for Production1",
								FirstDataStatusKey = 765,
								RecStatusKey = (GenRecStatusEnum)1,
								IsFinal = false,
								ApplicationStatusKey = 0
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 766,
								EnumName = "ReferredtoCreditHelpDesk",
								EnumDescription = "Referred to Credit Help Desk",
								FirstDataStatusKey = 766,
								RecStatusKey = (GenRecStatusEnum)1,
								IsFinal = false,
								ApplicationStatusKey = 0
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 767,
								EnumName = "ReferredtoCreditOfficerforFullReview",
								EnumDescription = "Referred to Credit Officer for Full Review",
								FirstDataStatusKey = 767,
								RecStatusKey = (GenRecStatusEnum)1,
								IsFinal = false,
								ApplicationStatusKey = 0
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 768,
								EnumName = "AccountDeclinedbyCreditOfficer",
								EnumDescription = "Account Declined by Credit Officer",
								FirstDataStatusKey = 768,
								RecStatusKey = (GenRecStatusEnum)1,
								IsFinal = false,
								ApplicationStatusKey = 0
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
