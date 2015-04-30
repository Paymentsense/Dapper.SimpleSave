using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenApplicationStageCategoryEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Started")][EnumMember]Started = 1,
       [Description("Validated")][EnumMember]Validated = 2,
       [Description("Printed")][EnumMember]Printed = 3,
       [Description("Docs Out")][EnumMember]DocsOut = 4,
       [Description("Cancelled")][EnumMember]Cancelled = 5,
       [Description("Docs In")][EnumMember]DocsIn = 6,
       [Description("Provisioning Cancelled")][EnumMember]ProvisioningCancelled = 7,
       [Description("Pre Check")][EnumMember]PreCheck = 8,
       [Description("Error To QA")][EnumMember]ErrorToQA = 9,
       [Description("E-Sig Pending")][EnumMember]ESigPending = 10,
       [Description("Prep Q Low")][EnumMember]PrepQLow = 11,
       [Description("Prep Q High")][EnumMember]PrepQHigh = 12,
       [Description("Error From Investigations")][EnumMember]ErrorFromInvestigations = 13,
       [Description("Error From Underwriting")][EnumMember]ErrorFromUnderwriting = 14,
       [Description("Resubmit Low")][EnumMember]ResubmitLow = 15,
       [Description("Resubmit High")][EnumMember]ResubmitHigh = 16,
       [Description("Submit Error")][EnumMember]SubmitError = 17,
       [Description("Credit Declined")][EnumMember]CreditDeclined = 18,
       [Description("Bank Abandonded")][EnumMember]BankAbandonded = 19,
       [Description("In QC New")][EnumMember]InQCNew = 20,
       [Description("In QC Re-Sub")][EnumMember]InQCReSub = 21,
       [Description("QC Partial")][EnumMember]QCPartial = 22,
       [Description("Clean")][EnumMember]Clean = 23,
       [Description("Error Nudge")][EnumMember]ErrorNudge = 24,
       [Description("Error To Seller")][EnumMember]ErrorToSeller = 25,
       [Description("Error Quickie")][EnumMember]ErrorQuickie = 26,
       [Description("Old Error To Seller")][EnumMember]OldErrorToSeller = 27,
       [Description("To Bank")][EnumMember]ToBank = 28,
       [Description("Docs Sent To Bank")][EnumMember]DocsSentToBank = 29,
       [Description("Abandonded")][EnumMember]Abandonded = 30,
       [Description("V-App Submit")][EnumMember]VAppSubmit = 31,
       [Description("In Process")][EnumMember]InProcess = 32,
       [Description("Application Error")][EnumMember]ApplicationError = 33,
       [Description("XML Ready")][EnumMember]XMLReady = 34,
       [Description("AIB To Bank")][EnumMember]AIBToBank = 35,
       [Description("AIB Approved")][EnumMember]AIBApproved = 36,
       [Description("AIB Declined")][EnumMember]AIBDeclined = 37,
       [Description("XML Submit")][EnumMember]XMLSubmit = 38,
       [Description("Error")][EnumMember]Error = 39,
       [Description("Accept")][EnumMember]Accept = 40,
       [Description("Pending Validation")][EnumMember]PendingValidation = 41,
       [Description("Reject")][EnumMember]Reject = 42,
       [Description("Boarding")][EnumMember]Boarding = 43,
       [Description("To Credit")][EnumMember]ToCredit = 44,
       [Description("Credit Pending")][EnumMember]CreditPending = 45,
       [Description("Credit Error Queue")][EnumMember]CreditErrorQueue = 46,
       [Description("Auto Approve Pending")][EnumMember]AutoApprovePending = 47,
       [Description("Resubmit - To Investigations")][EnumMember]ResubmitToInvestigations = 48,
       [Description("Resubmit - To Underwriting")][EnumMember]ResubmitToUnderwriting = 49,
       [Description("Investigations To Underwriting")][EnumMember]InvestigationsToUnderwriting = 50,
       [Description("Credit Approved")][EnumMember]CreditApproved = 51,
       [Description("Approved Subject To")][EnumMember]ApprovedSubjectTo = 52,
       [Description("Declined Dead")][EnumMember]DeclinedDead = 53,
       [Description("Application Cancelled")][EnumMember]ApplicationCancelled = 54,
       [Description("To Vendor")][EnumMember]ToVendor = 55,
       [Description("To Spire")][EnumMember]ToSpire = 56,
       [Description("Bank Archived")][EnumMember]BankArchived = 57,
       [Description("TermID Recd")][EnumMember]TermIDRecd = 58,
       [Description("Live")][EnumMember]Live = 59,
       [Description("Dead-Post Live")][EnumMember]DeadPostLive = 60,
        
    }    
    
    public class GenApplicationStageCategory
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int ApplicationStageCategoryKey {get;set;}
		public int ApplicationStageGroupKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class GenApplicationStageCategoryCollection
    {
        private static List<GenApplicationStageCategory> _list; 
        public static List<GenApplicationStageCategory> GenApplicationStageCategoryList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<GenApplicationStageCategory>
                        {
                            new GenApplicationStageCategory
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								ApplicationStageCategoryKey = 0,
								ApplicationStageGroupKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 1,
								EnumName = "Started",
								EnumDescription = "Started",
								ApplicationStageCategoryKey = 1,
								ApplicationStageGroupKey = 1,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 2,
								EnumName = "Validated",
								EnumDescription = "Validated",
								ApplicationStageCategoryKey = 2,
								ApplicationStageGroupKey = 1,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 3,
								EnumName = "Printed",
								EnumDescription = "Printed",
								ApplicationStageCategoryKey = 3,
								ApplicationStageGroupKey = 1,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 4,
								EnumName = "DocsOut",
								EnumDescription = "Docs Out",
								ApplicationStageCategoryKey = 4,
								ApplicationStageGroupKey = 3,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 5,
								EnumName = "Cancelled",
								EnumDescription = "Cancelled",
								ApplicationStageCategoryKey = 5,
								ApplicationStageGroupKey = 10,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 6,
								EnumName = "DocsIn",
								EnumDescription = "Docs In",
								ApplicationStageCategoryKey = 6,
								ApplicationStageGroupKey = 4,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 7,
								EnumName = "ProvisioningCancelled",
								EnumDescription = "Provisioning Cancelled",
								ApplicationStageCategoryKey = 7,
								ApplicationStageGroupKey = 10,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 8,
								EnumName = "PreCheck",
								EnumDescription = "Pre Check",
								ApplicationStageCategoryKey = 8,
								ApplicationStageGroupKey = 4,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 9,
								EnumName = "ErrorToQA",
								EnumDescription = "Error To QA",
								ApplicationStageCategoryKey = 9,
								ApplicationStageGroupKey = 4,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 10,
								EnumName = "ESigPending",
								EnumDescription = "E-Sig Pending",
								ApplicationStageCategoryKey = 10,
								ApplicationStageGroupKey = 4,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 11,
								EnumName = "PrepQLow",
								EnumDescription = "Prep Q Low",
								ApplicationStageCategoryKey = 11,
								ApplicationStageGroupKey = 4,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 12,
								EnumName = "PrepQHigh",
								EnumDescription = "Prep Q High",
								ApplicationStageCategoryKey = 12,
								ApplicationStageGroupKey = 4,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 13,
								EnumName = "ErrorFromInvestigations",
								EnumDescription = "Error From Investigations",
								ApplicationStageCategoryKey = 13,
								ApplicationStageGroupKey = 4,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 14,
								EnumName = "ErrorFromUnderwriting",
								EnumDescription = "Error From Underwriting",
								ApplicationStageCategoryKey = 14,
								ApplicationStageGroupKey = 4,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 15,
								EnumName = "ResubmitLow",
								EnumDescription = "Resubmit Low",
								ApplicationStageCategoryKey = 15,
								ApplicationStageGroupKey = 4,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 16,
								EnumName = "ResubmitHigh",
								EnumDescription = "Resubmit High",
								ApplicationStageCategoryKey = 16,
								ApplicationStageGroupKey = 4,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 17,
								EnumName = "SubmitError",
								EnumDescription = "Submit Error",
								ApplicationStageCategoryKey = 17,
								ApplicationStageGroupKey = 4,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 18,
								EnumName = "CreditDeclined",
								EnumDescription = "Credit Declined",
								ApplicationStageCategoryKey = 18,
								ApplicationStageGroupKey = 4,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 19,
								EnumName = "BankAbandonded",
								EnumDescription = "Bank Abandonded",
								ApplicationStageCategoryKey = 19,
								ApplicationStageGroupKey = 10,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 20,
								EnumName = "InQCNew",
								EnumDescription = "In QC New",
								ApplicationStageCategoryKey = 20,
								ApplicationStageGroupKey = 4,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 21,
								EnumName = "InQCReSub",
								EnumDescription = "In QC Re-Sub",
								ApplicationStageCategoryKey = 21,
								ApplicationStageGroupKey = 4,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 22,
								EnumName = "QCPartial",
								EnumDescription = "QC Partial",
								ApplicationStageCategoryKey = 22,
								ApplicationStageGroupKey = 4,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 23,
								EnumName = "Clean",
								EnumDescription = "Clean",
								ApplicationStageCategoryKey = 23,
								ApplicationStageGroupKey = 4,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 24,
								EnumName = "ErrorNudge",
								EnumDescription = "Error Nudge",
								ApplicationStageCategoryKey = 24,
								ApplicationStageGroupKey = 4,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 25,
								EnumName = "ErrorToSeller",
								EnumDescription = "Error To Seller",
								ApplicationStageCategoryKey = 25,
								ApplicationStageGroupKey = 4,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 26,
								EnumName = "ErrorQuickie",
								EnumDescription = "Error Quickie",
								ApplicationStageCategoryKey = 26,
								ApplicationStageGroupKey = 4,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 27,
								EnumName = "OldErrorToSeller",
								EnumDescription = "Old Error To Seller",
								ApplicationStageCategoryKey = 27,
								ApplicationStageGroupKey = 4,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 28,
								EnumName = "ToBank",
								EnumDescription = "To Bank",
								ApplicationStageCategoryKey = 28,
								ApplicationStageGroupKey = 6,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 29,
								EnumName = "DocsSentToBank",
								EnumDescription = "Docs Sent To Bank",
								ApplicationStageCategoryKey = 29,
								ApplicationStageGroupKey = 6,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 30,
								EnumName = "Abandonded",
								EnumDescription = "Abandonded",
								ApplicationStageCategoryKey = 30,
								ApplicationStageGroupKey = 10,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 31,
								EnumName = "VAppSubmit",
								EnumDescription = "V-App Submit",
								ApplicationStageCategoryKey = 31,
								ApplicationStageGroupKey = 6,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 32,
								EnumName = "InProcess",
								EnumDescription = "In Process",
								ApplicationStageCategoryKey = 32,
								ApplicationStageGroupKey = 6,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 33,
								EnumName = "ApplicationError",
								EnumDescription = "Application Error",
								ApplicationStageCategoryKey = 33,
								ApplicationStageGroupKey = 6,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 34,
								EnumName = "XMLReady",
								EnumDescription = "XML Ready",
								ApplicationStageCategoryKey = 34,
								ApplicationStageGroupKey = 5,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 35,
								EnumName = "AIBToBank",
								EnumDescription = "AIB To Bank",
								ApplicationStageCategoryKey = 35,
								ApplicationStageGroupKey = 6,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 36,
								EnumName = "AIBApproved",
								EnumDescription = "AIB Approved",
								ApplicationStageCategoryKey = 36,
								ApplicationStageGroupKey = 8,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 37,
								EnumName = "AIBDeclined",
								EnumDescription = "AIB Declined",
								ApplicationStageCategoryKey = 37,
								ApplicationStageGroupKey = 10,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 38,
								EnumName = "XMLSubmit",
								EnumDescription = "XML Submit",
								ApplicationStageCategoryKey = 38,
								ApplicationStageGroupKey = 6,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 39,
								EnumName = "Error",
								EnumDescription = "Error",
								ApplicationStageCategoryKey = 39,
								ApplicationStageGroupKey = 2,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 40,
								EnumName = "Accept",
								EnumDescription = "Accept",
								ApplicationStageCategoryKey = 40,
								ApplicationStageGroupKey = 6,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 41,
								EnumName = "PendingValidation",
								EnumDescription = "Pending Validation",
								ApplicationStageCategoryKey = 41,
								ApplicationStageGroupKey = 6,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 42,
								EnumName = "Reject",
								EnumDescription = "Reject",
								ApplicationStageCategoryKey = 42,
								ApplicationStageGroupKey = 2,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 43,
								EnumName = "Boarding",
								EnumDescription = "Boarding",
								ApplicationStageCategoryKey = 43,
								ApplicationStageGroupKey = 6,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 44,
								EnumName = "ToCredit",
								EnumDescription = "To Credit",
								ApplicationStageCategoryKey = 44,
								ApplicationStageGroupKey = 7,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 45,
								EnumName = "CreditPending",
								EnumDescription = "Credit Pending",
								ApplicationStageCategoryKey = 45,
								ApplicationStageGroupKey = 7,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 46,
								EnumName = "CreditErrorQueue",
								EnumDescription = "Credit Error Queue",
								ApplicationStageCategoryKey = 46,
								ApplicationStageGroupKey = 10,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 47,
								EnumName = "AutoApprovePending",
								EnumDescription = "Auto Approve Pending",
								ApplicationStageCategoryKey = 47,
								ApplicationStageGroupKey = 7,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 48,
								EnumName = "ResubmitToInvestigations",
								EnumDescription = "Resubmit - To Investigations",
								ApplicationStageCategoryKey = 48,
								ApplicationStageGroupKey = 7,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 49,
								EnumName = "ResubmitToUnderwriting",
								EnumDescription = "Resubmit - To Underwriting",
								ApplicationStageCategoryKey = 49,
								ApplicationStageGroupKey = 7,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 50,
								EnumName = "InvestigationsToUnderwriting",
								EnumDescription = "Investigations To Underwriting",
								ApplicationStageCategoryKey = 50,
								ApplicationStageGroupKey = 7,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 51,
								EnumName = "CreditApproved",
								EnumDescription = "Credit Approved",
								ApplicationStageCategoryKey = 51,
								ApplicationStageGroupKey = 8,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 52,
								EnumName = "ApprovedSubjectTo",
								EnumDescription = "Approved Subject To",
								ApplicationStageCategoryKey = 52,
								ApplicationStageGroupKey = 8,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 53,
								EnumName = "DeclinedDead",
								EnumDescription = "Declined Dead",
								ApplicationStageCategoryKey = 53,
								ApplicationStageGroupKey = 10,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 54,
								EnumName = "ApplicationCancelled",
								EnumDescription = "Application Cancelled",
								ApplicationStageCategoryKey = 54,
								ApplicationStageGroupKey = 10,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 55,
								EnumName = "ToVendor",
								EnumDescription = "To Vendor",
								ApplicationStageCategoryKey = 55,
								ApplicationStageGroupKey = 7,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 56,
								EnumName = "ToSpire",
								EnumDescription = "To Spire",
								ApplicationStageCategoryKey = 56,
								ApplicationStageGroupKey = 7,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 57,
								EnumName = "BankArchived",
								EnumDescription = "Bank Archived",
								ApplicationStageCategoryKey = 57,
								ApplicationStageGroupKey = 10,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 58,
								EnumName = "TermIDRecd",
								EnumDescription = "TermID Recd",
								ApplicationStageCategoryKey = 58,
								ApplicationStageGroupKey = 7,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 59,
								EnumName = "Live",
								EnumDescription = "Live",
								ApplicationStageCategoryKey = 59,
								ApplicationStageGroupKey = 9,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageCategory
							{
								EnumValue = 60,
								EnumName = "DeadPostLive",
								EnumDescription = "Dead-Post Live",
								ApplicationStageCategoryKey = 60,
								ApplicationStageGroupKey = 10,
								RecStatusKey = (GenRecStatusEnum)0
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
