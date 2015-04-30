using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Mrkt
{
    
    [DataContract]
    public enum MrktCampaignCallResolutionEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Lead")][EnumMember]Lead = 1,
       [Description("Call Transferred")][EnumMember]CallTransferred = 2,
       [Description("Non-Lead")][EnumMember]NonLead = 3,
       [Description("Already Owned")][EnumMember]AlreadyOwned = 4,
       [Description("High Risk")][EnumMember]HighRisk = 5,
        
    }    
    
    public class MrktCampaignCallResolution
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int CampaignCallResolutionKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class MrktCampaignCallResolutionCollection
    {
        private static List<MrktCampaignCallResolution> _list; 
        public static List<MrktCampaignCallResolution> MrktCampaignCallResolutionList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<MrktCampaignCallResolution>
                        {
                            new MrktCampaignCallResolution
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								CampaignCallResolutionKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new MrktCampaignCallResolution
							{
								EnumValue = 1,
								EnumName = "Lead",
								EnumDescription = "Lead",
								CampaignCallResolutionKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new MrktCampaignCallResolution
							{
								EnumValue = 2,
								EnumName = "CallTransferred",
								EnumDescription = "Call Transferred",
								CampaignCallResolutionKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new MrktCampaignCallResolution
							{
								EnumValue = 3,
								EnumName = "NonLead",
								EnumDescription = "Non-Lead",
								CampaignCallResolutionKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new MrktCampaignCallResolution
							{
								EnumValue = 4,
								EnumName = "AlreadyOwned",
								EnumDescription = "Already Owned",
								CampaignCallResolutionKey = 4,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new MrktCampaignCallResolution
							{
								EnumValue = 5,
								EnumName = "HighRisk",
								EnumDescription = "High Risk",
								CampaignCallResolutionKey = 5,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
