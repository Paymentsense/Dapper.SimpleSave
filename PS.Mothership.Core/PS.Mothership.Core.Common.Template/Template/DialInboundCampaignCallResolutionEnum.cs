using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Dial
{
    
    [DataContract]
    public enum DialInboundCampaignCallResolutionEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Lead")][EnumMember]Lead = 1,
       [Description("Transferred Call")][EnumMember]TransferredCall = 2,
       [Description("Non Sales Call")][EnumMember]NonSalesCall = 3,
       [Description("High Risk Call")][EnumMember]HighRiskCall = 4,
        
    }    
    
    public class DialInboundCampaignCallResolution
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long InboundCampaignCallResolutionKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class DialInboundCampaignCallResolutionCollection
    {
        private static List<DialInboundCampaignCallResolution> _list; 
        public static List<DialInboundCampaignCallResolution> DialInboundCampaignCallResolutionList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<DialInboundCampaignCallResolution>
                        {
                            new DialInboundCampaignCallResolution
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								InboundCampaignCallResolutionKey = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialInboundCampaignCallResolution
							{
								EnumValue = 1,
								EnumName = "Lead",
								EnumDescription = "Lead",
								InboundCampaignCallResolutionKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialInboundCampaignCallResolution
							{
								EnumValue = 2,
								EnumName = "TransferredCall",
								EnumDescription = "Transferred Call",
								InboundCampaignCallResolutionKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialInboundCampaignCallResolution
							{
								EnumValue = 3,
								EnumName = "NonSalesCall",
								EnumDescription = "Non Sales Call",
								InboundCampaignCallResolutionKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialInboundCampaignCallResolution
							{
								EnumValue = 4,
								EnumName = "HighRiskCall",
								EnumDescription = "High Risk Call",
								InboundCampaignCallResolutionKey = 4,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
