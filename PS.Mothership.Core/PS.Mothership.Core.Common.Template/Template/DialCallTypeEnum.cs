using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Dial
{
    
    [DataContract]
    public enum DialCallTypeEnum : long
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
    
    public class DialCallType
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long CallTypeKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class DialCallTypeCollection
    {
        private static List<DialCallType> _list; 
        public static List<DialCallType> DialCallTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<DialCallType>
                        {
                            new DialCallType
							{
								EnumValue = 0,
								EnumName = "Unknown",
								EnumDescription = "Unknown",
								CallTypeKey = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialCallType
							{
								EnumValue = 1,
								EnumName = "InboundDDICall",
								EnumDescription = "Inbound DDI Call",
								CallTypeKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialCallType
							{
								EnumValue = 2,
								EnumName = "InboundNonCampaignCall",
								EnumDescription = "Inbound Non Campaign Call",
								CallTypeKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialCallType
							{
								EnumValue = 3,
								EnumName = "InboundCampaignCall",
								EnumDescription = "Inbound Campaign Call",
								CallTypeKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialCallType
							{
								EnumValue = 4,
								EnumName = "InboundInternalCall",
								EnumDescription = "Inbound Internal Call",
								CallTypeKey = 4,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialCallType
							{
								EnumValue = 5,
								EnumName = "OutboundManualCall",
								EnumDescription = "Outbound Manual Call",
								CallTypeKey = 5,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialCallType
							{
								EnumValue = 6,
								EnumName = "OutboundInternalCall",
								EnumDescription = "Outbound Internal Call",
								CallTypeKey = 6,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialCallType
							{
								EnumValue = 7,
								EnumName = "OutboundCampaignCall",
								EnumDescription = "Outbound Campaign Call",
								CallTypeKey = 7,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialCallType
							{
								EnumValue = 8,
								EnumName = "MonitorCall",
								EnumDescription = "Monitor Call",
								CallTypeKey = 8,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialCallType
							{
								EnumValue = 9,
								EnumName = "ConferenceOrTransferConsultCall",
								EnumDescription = "Conference or Transfer Consult Call",
								CallTypeKey = 9,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialCallType
							{
								EnumValue = 10,
								EnumName = "UnresolvedOutboundCampaignCall",
								EnumDescription = "Unresolved Outbound Campaign Call",
								CallTypeKey = 10,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialCallType
							{
								EnumValue = 11,
								EnumName = "ServiceAgentCall",
								EnumDescription = "Service Agent Call",
								CallTypeKey = 11,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialCallType
							{
								EnumValue = 12,
								EnumName = "UnresolvedInboundCampaignCall",
								EnumDescription = "Unresolved Inbound Campaign Call",
								CallTypeKey = 12,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
