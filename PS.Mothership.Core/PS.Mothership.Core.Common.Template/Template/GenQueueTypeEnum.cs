using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenQueueTypeEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Web Lead")][EnumMember]WebLead = 1,
       [Description("Scheduled Callback")][EnumMember]ScheduledCallback = 2,
       [Description("PopupReminder")][EnumMember]PopupReminder = 3,
       [Description("SMSReminder")][EnumMember]SMSReminder = 4,
       [Description("TeleSales")][EnumMember]TeleSales = 5,
       [Description("NormalDistribution")][EnumMember]NormalDistribution = 6,
       [Description("CustomerService")][EnumMember]CustomerService = 7,
        
    }    
    
    public class GenQueueType
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int QueueTypeKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class GenQueueTypeCollection
    {
        private static List<GenQueueType> _list; 
        public static List<GenQueueType> GenQueueTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<GenQueueType>
                        {
                            new GenQueueType
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								QueueTypeKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenQueueType
							{
								EnumValue = 1,
								EnumName = "WebLead",
								EnumDescription = "Web Lead",
								QueueTypeKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenQueueType
							{
								EnumValue = 2,
								EnumName = "ScheduledCallback",
								EnumDescription = "Scheduled Callback",
								QueueTypeKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenQueueType
							{
								EnumValue = 3,
								EnumName = "PopupReminder",
								EnumDescription = "PopupReminder",
								QueueTypeKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenQueueType
							{
								EnumValue = 4,
								EnumName = "SMSReminder",
								EnumDescription = "SMSReminder",
								QueueTypeKey = 4,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenQueueType
							{
								EnumValue = 5,
								EnumName = "TeleSales",
								EnumDescription = "TeleSales",
								QueueTypeKey = 5,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenQueueType
							{
								EnumValue = 6,
								EnumName = "NormalDistribution",
								EnumDescription = "NormalDistribution",
								QueueTypeKey = 6,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenQueueType
							{
								EnumValue = 7,
								EnumName = "CustomerService",
								EnumDescription = "CustomerService",
								QueueTypeKey = 7,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
