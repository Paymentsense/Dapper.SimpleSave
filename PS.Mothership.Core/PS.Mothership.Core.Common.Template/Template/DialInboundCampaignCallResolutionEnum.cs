using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Dial
{
    
    [DataContract]
    public enum InboundCampaignCallResolutionEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Lead")][EnumMember]Lead = 1,
       [Description("Transferred Call")][EnumMember]TransferredCall = 2,
       [Description("Non Sales Call")][EnumMember]NonSalesCall = 3,
       [Description("High Risk Call")][EnumMember]HighRiskCall = 4,
        
    }

    public class InboundCampaignCallResolution
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long InboundCampaignCallResolutionKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class InboundCampaignCallResolutionCollection
    {
        private static List<InboundCampaignCallResolution> _list; 
        public static List<InboundCampaignCallResolution> InboundCampaignCallResolutionList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<InboundCampaignCallResolution>
                        {
                            new InboundCampaignCallResolution
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								InboundCampaignCallResolutionKey = 0
							},
							new InboundCampaignCallResolution
							{
								EnumValue = 1,
								EnumName = "Lead",
								EnumDescription = "Lead",
								InboundCampaignCallResolutionKey = 1
							},
							new InboundCampaignCallResolution
							{
								EnumValue = 2,
								EnumName = "TransferredCall",
								EnumDescription = "Transferred Call",
								InboundCampaignCallResolutionKey = 2
							},
							new InboundCampaignCallResolution
							{
								EnumValue = 3,
								EnumName = "NonSalesCall",
								EnumDescription = "Non Sales Call",
								InboundCampaignCallResolutionKey = 3
							},
							new InboundCampaignCallResolution
							{
								EnumValue = 4,
								EnumName = "HighRiskCall",
								EnumDescription = "High Risk Call",
								InboundCampaignCallResolutionKey = 4
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
