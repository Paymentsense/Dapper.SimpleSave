using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Dial
{
    
    [DataContract]
    public enum CallTypeEnum : long
    {
       [Description("Unknown")][EnumMember]Unknown = 0,
       [Description("Inbound DDI")][EnumMember]InboundDDI = 1,
       [Description("Inbound Non Campaign")][EnumMember]InboundNonCampaign = 2,
       [Description("Inbound Campaign")][EnumMember]InboundCampaign = 3,
       [Description("Inbound Internal")][EnumMember]InboundInternal = 4,
       [Description("Outbound Manual Dial")][EnumMember]OutboundManualDial = 5,
       [Description("Outbound Internal")][EnumMember]OutboundInternal = 6,
       [Description("Outbound Queue Call")][EnumMember]OutboundQueueCall = 7,
       [Description("Monitor Call")][EnumMember]MonitorCall = 8,
       [Description("Conference or Transfer Consult Call")][EnumMember]ConferenceOrTransferConsultCall = 9,
       [Description("Unresolved Outbound Queue Call")][EnumMember]UnresolvedOutboundQueueCall = 10,
       [Description("Service Agent Call")][EnumMember]ServiceAgentCall = 11,
        
    }

    public class CallType
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long CallTypeKey {get;set;}
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
								CallTypeKey=0
							},
							new CallType
							{
								EnumValue = 1,
								EnumName = "InboundDDI",
								EnumDescription = "Inbound DDI",
								CallTypeKey=1
							},
							new CallType
							{
								EnumValue = 2,
								EnumName = "InboundNonCampaign",
								EnumDescription = "Inbound Non Campaign",
								CallTypeKey=2
							},
							new CallType
							{
								EnumValue = 3,
								EnumName = "InboundCampaign",
								EnumDescription = "Inbound Campaign",
								CallTypeKey=3
							},
							new CallType
							{
								EnumValue = 4,
								EnumName = "InboundInternal",
								EnumDescription = "Inbound Internal",
								CallTypeKey=4
							},
							new CallType
							{
								EnumValue = 5,
								EnumName = "OutboundManualDial",
								EnumDescription = "Outbound Manual Dial",
								CallTypeKey=5
							},
							new CallType
							{
								EnumValue = 6,
								EnumName = "OutboundInternal",
								EnumDescription = "Outbound Internal",
								CallTypeKey=6
							},
							new CallType
							{
								EnumValue = 7,
								EnumName = "OutboundQueueCall",
								EnumDescription = "Outbound Queue Call",
								CallTypeKey=7
							},
							new CallType
							{
								EnumValue = 8,
								EnumName = "MonitorCall",
								EnumDescription = "Monitor Call",
								CallTypeKey=8
							},
							new CallType
							{
								EnumValue = 9,
								EnumName = "ConferenceOrTransferConsultCall",
								EnumDescription = "Conference or Transfer Consult Call",
								CallTypeKey=9
							},
							new CallType
							{
								EnumValue = 10,
								EnumName = "UnresolvedOutboundQueueCall",
								EnumDescription = "Unresolved Outbound Queue Call",
								CallTypeKey=10
							},
							new CallType
							{
								EnumValue = 11,
								EnumName = "ServiceAgentCall",
								EnumDescription = "Service Agent Call",
								CallTypeKey=11
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
