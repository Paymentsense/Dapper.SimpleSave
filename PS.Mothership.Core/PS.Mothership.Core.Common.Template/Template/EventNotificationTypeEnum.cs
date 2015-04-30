using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Event
{
    
    [DataContract]
    public enum EventNotificationTypeEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Task")][EnumMember]Task = 1,
       [Description("Scheduled Callback")][EnumMember]ScheduledCallback = 2,
       [Description("Rescheduled Callback")][EnumMember]RescheduledCallback = 3,
       [Description("AutoRescheduled Callback")][EnumMember]AutoRescheduledCallback = 4,
        
    }    
    
    public class EventNotificationType
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int NotificationTypeKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class EventNotificationTypeCollection
    {
        private static List<EventNotificationType> _list; 
        public static List<EventNotificationType> EventNotificationTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<EventNotificationType>
                        {
                            new EventNotificationType
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								NotificationTypeKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new EventNotificationType
							{
								EnumValue = 1,
								EnumName = "Task",
								EnumDescription = "Task",
								NotificationTypeKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventNotificationType
							{
								EnumValue = 2,
								EnumName = "ScheduledCallback",
								EnumDescription = "Scheduled Callback",
								NotificationTypeKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventNotificationType
							{
								EnumValue = 3,
								EnumName = "RescheduledCallback",
								EnumDescription = "Rescheduled Callback",
								NotificationTypeKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventNotificationType
							{
								EnumValue = 4,
								EnumName = "AutoRescheduledCallback",
								EnumDescription = "AutoRescheduled Callback",
								NotificationTypeKey = 4,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
