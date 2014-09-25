using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenOpportunityStatusEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Offer Made")][EnumMember]OfferMade = 1,
       [Description("On Application")][EnumMember]OnApp = 2,
       [Description("DOCS Out")][EnumMember]DocsOut = 3,
       [Description("Docs In")][EnumMember]DocsIn = 4,
       [Description("Docs In Error")][EnumMember]DocsInError = 5,
       [Description("To Bank")][EnumMember]ToBank = 6,
       [Description("Credit Approved")][EnumMember]CreditApproved = 7,
       [Description("Declined")][EnumMember]Declined = 8,
       [Description("Live")][EnumMember]Live = 9,
       [Description("Cancelled Cool Off")][EnumMember]CancelledCoolOff = 10,
       [Description("Cancelled")][EnumMember]Cancelled = 11,
       [Description("Dead")][EnumMember]Dead = 12,
        
    }    
    
    public class GenOpportunityStatus
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int OpportunityStatusKey {get;set;}
		public int OpportunityStatusCategoryKey {get;set;}
		public int ApplicationStatusCategoryKey {get;set;}
		public int WobbleDays {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class GenOpportunityStatusCollection
    {
        private static List<GenOpportunityStatus> _list; 
        public static List<GenOpportunityStatus> GenOpportunityStatusList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<GenOpportunityStatus>
                        {
                            new GenOpportunityStatus
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								OpportunityStatusKey = 0,
								OpportunityStatusCategoryKey = 0,
								ApplicationStatusCategoryKey = 0,
								WobbleDays = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenOpportunityStatus
							{
								EnumValue = 1,
								EnumName = "OfferMade",
								EnumDescription = "Offer Made",
								OpportunityStatusKey = 1,
								OpportunityStatusCategoryKey = 0,
								ApplicationStatusCategoryKey = 0,
								WobbleDays = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenOpportunityStatus
							{
								EnumValue = 2,
								EnumName = "OnApp",
								EnumDescription = "On Application",
								OpportunityStatusKey = 2,
								OpportunityStatusCategoryKey = 0,
								ApplicationStatusCategoryKey = 0,
								WobbleDays = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenOpportunityStatus
							{
								EnumValue = 3,
								EnumName = "DocsOut",
								EnumDescription = "DOCS Out",
								OpportunityStatusKey = 3,
								OpportunityStatusCategoryKey = 0,
								ApplicationStatusCategoryKey = 0,
								WobbleDays = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenOpportunityStatus
							{
								EnumValue = 4,
								EnumName = "DocsIn",
								EnumDescription = "Docs In",
								OpportunityStatusKey = 4,
								OpportunityStatusCategoryKey = 0,
								ApplicationStatusCategoryKey = 0,
								WobbleDays = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenOpportunityStatus
							{
								EnumValue = 5,
								EnumName = "DocsInError",
								EnumDescription = "Docs In Error",
								OpportunityStatusKey = 5,
								OpportunityStatusCategoryKey = 0,
								ApplicationStatusCategoryKey = 0,
								WobbleDays = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenOpportunityStatus
							{
								EnumValue = 6,
								EnumName = "ToBank",
								EnumDescription = "To Bank",
								OpportunityStatusKey = 6,
								OpportunityStatusCategoryKey = 0,
								ApplicationStatusCategoryKey = 0,
								WobbleDays = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenOpportunityStatus
							{
								EnumValue = 7,
								EnumName = "CreditApproved",
								EnumDescription = "Credit Approved",
								OpportunityStatusKey = 7,
								OpportunityStatusCategoryKey = 0,
								ApplicationStatusCategoryKey = 0,
								WobbleDays = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenOpportunityStatus
							{
								EnumValue = 8,
								EnumName = "Declined",
								EnumDescription = "Declined",
								OpportunityStatusKey = 8,
								OpportunityStatusCategoryKey = 0,
								ApplicationStatusCategoryKey = 0,
								WobbleDays = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenOpportunityStatus
							{
								EnumValue = 9,
								EnumName = "Live",
								EnumDescription = "Live",
								OpportunityStatusKey = 9,
								OpportunityStatusCategoryKey = 0,
								ApplicationStatusCategoryKey = 0,
								WobbleDays = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenOpportunityStatus
							{
								EnumValue = 10,
								EnumName = "CancelledCoolOff",
								EnumDescription = "Cancelled Cool Off",
								OpportunityStatusKey = 10,
								OpportunityStatusCategoryKey = 0,
								ApplicationStatusCategoryKey = 0,
								WobbleDays = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenOpportunityStatus
							{
								EnumValue = 11,
								EnumName = "Cancelled",
								EnumDescription = "Cancelled",
								OpportunityStatusKey = 11,
								OpportunityStatusCategoryKey = 0,
								ApplicationStatusCategoryKey = 0,
								WobbleDays = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenOpportunityStatus
							{
								EnumValue = 12,
								EnumName = "Dead",
								EnumDescription = "Dead",
								OpportunityStatusKey = 12,
								OpportunityStatusCategoryKey = 0,
								ApplicationStatusCategoryKey = 0,
								WobbleDays = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
