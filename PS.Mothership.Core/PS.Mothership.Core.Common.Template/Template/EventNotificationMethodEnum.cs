using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Event
{
    
    [DataContract]
    public enum EventNotificationMethodEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Pop Up")][EnumMember]Popup = 1,
       [Description("NotificationBar")][EnumMember]NotificationBar = 2,
       [Description("Scheduled Callback")][EnumMember]ScheduledCallback = 3,
       [Description("SMS")][EnumMember]SMS = 4,
        
    }    
    
    public class EventNotificationMethod
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int NotificationMethodKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class EventNotificationMethodCollection
    {
        private static List<EventNotificationMethod> _list; 
        public static List<EventNotificationMethod> EventNotificationMethodList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<EventNotificationMethod>
                        {
                            new EventNotificationMethod
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								NotificationMethodKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new EventNotificationMethod
							{
								EnumValue = 1,
								EnumName = "Popup",
								EnumDescription = "Pop Up",
								NotificationMethodKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventNotificationMethod
							{
								EnumValue = 2,
								EnumName = "NotificationBar",
								EnumDescription = "NotificationBar",
								NotificationMethodKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventNotificationMethod
							{
								EnumValue = 3,
								EnumName = "ScheduledCallback",
								EnumDescription = "Scheduled Callback",
								NotificationMethodKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventNotificationMethod
							{
								EnumValue = 4,
								EnumName = "SMS",
								EnumDescription = "SMS",
								NotificationMethodKey = 4,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
