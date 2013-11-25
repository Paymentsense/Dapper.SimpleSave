using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Dial
{
    
    [DataContract]
    public enum InboundQueueCallResolutionEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Lead")][EnumMember]Lead = 1,
       [Description("Transferred Call")][EnumMember]TransferredCall = 2,
       [Description("Non Sales Call")][EnumMember]NonSalesCall = 3,
       [Description("High Risk Call")][EnumMember]HighRiskCall = 4,
        
    }

    public class InboundQueueCallResolution
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long InboundQueueCallResolutionKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class InboundQueueCallResolutionCollection
    {
        private static List<InboundQueueCallResolution> _list; 
        public static List<InboundQueueCallResolution> InboundQueueCallResolutionList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<InboundQueueCallResolution>
                        {
                            							new InboundQueueCallResolution
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								InboundQueueCallResolutionKey=0
							},
							new InboundQueueCallResolution
							{
								EnumValue = 1,
								EnumName = "Lead",
								EnumDescription = "Lead",
								InboundQueueCallResolutionKey=1
							},
							new InboundQueueCallResolution
							{
								EnumValue = 2,
								EnumName = "TransferredCall",
								EnumDescription = "Transferred Call",
								InboundQueueCallResolutionKey=2
							},
							new InboundQueueCallResolution
							{
								EnumValue = 3,
								EnumName = "NonSalesCall",
								EnumDescription = "Non Sales Call",
								InboundQueueCallResolutionKey=3
							},
							new InboundQueueCallResolution
							{
								EnumValue = 4,
								EnumName = "HighRiskCall",
								EnumDescription = "High Risk Call",
								InboundQueueCallResolutionKey=4
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
