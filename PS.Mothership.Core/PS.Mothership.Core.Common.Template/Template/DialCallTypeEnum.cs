using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Dial
{
    
    [DataContract]
    public enum CallTypeEnum : long
    {
       [Description("Unknown")][EnumMember]Unknown = 0,
       [Description("Inbound DDI Call")][EnumMember]InboundDDICall = 1,
       [Description("Inbound Non Campaign Call")][EnumMember]InboundNonCampaignCall = 2,
       [Description("Inbound Campaign Call")][EnumMember]InboundCampaignCall = 3,
       [Description("Inbound Internal Call")][EnumMember]InboundInternalCall = 4,
       [Description("Outbound Manual Call")][EnumMember]OutboundManualCall = 5,
       [Description("Outbound Internal Call")][EnumMember]OutboundInternalCall = 6,
       [Description("Outbound Campaign Call")][EnumMember]OutboundCampaignCall = 7,
       [Description("Monitor Call")][EnumMember]MonitorCall = 8,
       [Description("Conference or Transfer Consult Call")][EnumMember]ConferenceOrTransferConsultCall = 9,
       [Description("Unresolved Outbound Campaign Call")][EnumMember]UnresolvedOutboundCampaignCall = 10,
       [Description("Service Agent Call")][EnumMember]ServiceAgentCall = 11,
       [Description("Unresolved Inbound Campaign Call")][EnumMember]UnresolvedInboundCampaignCall = 12,
        
    }

    public class CallType
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long CallTypeKey {get;set;}
		public RecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class CallTypeCollection
    {
        private static List<CallType> _list; 
        public static List<CallType> CallTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<CallType>
                        {
                            new CallType
							{
								EnumValue = 0,
								EnumName = "Unknown",
								EnumDescription = "Unknown",
								CallTypeKey = 0,
								RecStatusKey = (RecStatusEnum)1
							},
							new CallType
							{
								EnumValue = 1,
								EnumName = "InboundDDICall",
								EnumDescription = "Inbound DDI Call",
								CallTypeKey = 1,
								RecStatusKey = (RecStatusEnum)1
							},
							new CallType
							{
								EnumValue = 2,
								EnumName = "InboundNonCampaignCall",
								EnumDescription = "Inbound Non Campaign Call",
								CallTypeKey = 2,
								RecStatusKey = (RecStatusEnum)1
							},
							new CallType
							{
								EnumValue = 3,
								EnumName = "InboundCampaignCall",
								EnumDescription = "Inbound Campaign Call",
								CallTypeKey = 3,
								RecStatusKey = (RecStatusEnum)1
							},
							new CallType
							{
								EnumValue = 4,
								EnumName = "InboundInternalCall",
								EnumDescription = "Inbound Internal Call",
								CallTypeKey = 4,
								RecStatusKey = (RecStatusEnum)1
							},
							new CallType
							{
								EnumValue = 5,
								EnumName = "OutboundManualCall",
								EnumDescription = "Outbound Manual Call",
								CallTypeKey = 5,
								RecStatusKey = (RecStatusEnum)1
							},
							new CallType
							{
								EnumValue = 6,
								EnumName = "OutboundInternalCall",
								EnumDescription = "Outbound Internal Call",
								CallTypeKey = 6,
								RecStatusKey = (RecStatusEnum)1
							},
							new CallType
							{
								EnumValue = 7,
								EnumName = "OutboundCampaignCall",
								EnumDescription = "Outbound Campaign Call",
								CallTypeKey = 7,
								RecStatusKey = (RecStatusEnum)1
							},
							new CallType
							{
								EnumValue = 8,
								EnumName = "MonitorCall",
								EnumDescription = "Monitor Call",
								CallTypeKey = 8,
								RecStatusKey = (RecStatusEnum)1
							},
							new CallType
							{
								EnumValue = 9,
								EnumName = "ConferenceOrTransferConsultCall",
								EnumDescription = "Conference or Transfer Consult Call",
								CallTypeKey = 9,
								RecStatusKey = (RecStatusEnum)1
							},
							new CallType
							{
								EnumValue = 10,
								EnumName = "UnresolvedOutboundCampaignCall",
								EnumDescription = "Unresolved Outbound Campaign Call",
								CallTypeKey = 10,
								RecStatusKey = (RecStatusEnum)1
							},
							new CallType
							{
								EnumValue = 11,
								EnumName = "ServiceAgentCall",
								EnumDescription = "Service Agent Call",
								CallTypeKey = 11,
								RecStatusKey = (RecStatusEnum)1
							},
							new CallType
							{
								EnumValue = 12,
								EnumName = "UnresolvedInboundCampaignCall",
								EnumDescription = "Unresolved Inbound Campaign Call",
								CallTypeKey = 12,
								RecStatusKey = (RecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
