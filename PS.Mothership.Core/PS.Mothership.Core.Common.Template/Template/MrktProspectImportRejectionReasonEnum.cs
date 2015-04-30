using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Mrkt
{
    
    [DataContract]
    public enum MrktProspectImportRejectionReasonEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Invalid Data")][EnumMember]InvalidData = 1,
       [Description("Already Owned")][EnumMember]AlreadyOwned = 2,
       [Description("Merchant Live")][EnumMember]MerchantLive = 3,
       [Description("Special Campaign")][EnumMember]SpecialCampaign = 4,
        
    }    
    
    public class MrktProspectImportRejectionReason
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int ProspectImportRejectionReasonKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class MrktProspectImportRejectionReasonCollection
    {
        private static List<MrktProspectImportRejectionReason> _list; 
        public static List<MrktProspectImportRejectionReason> MrktProspectImportRejectionReasonList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<MrktProspectImportRejectionReason>
                        {
                            new MrktProspectImportRejectionReason
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								ProspectImportRejectionReasonKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new MrktProspectImportRejectionReason
							{
								EnumValue = 1,
								EnumName = "InvalidData",
								EnumDescription = "Invalid Data",
								ProspectImportRejectionReasonKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new MrktProspectImportRejectionReason
							{
								EnumValue = 2,
								EnumName = "AlreadyOwned",
								EnumDescription = "Already Owned",
								ProspectImportRejectionReasonKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new MrktProspectImportRejectionReason
							{
								EnumValue = 3,
								EnumName = "MerchantLive",
								EnumDescription = "Merchant Live",
								ProspectImportRejectionReasonKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new MrktProspectImportRejectionReason
							{
								EnumValue = 4,
								EnumName = "SpecialCampaign",
								EnumDescription = "Special Campaign",
								ProspectImportRejectionReasonKey = 4,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
