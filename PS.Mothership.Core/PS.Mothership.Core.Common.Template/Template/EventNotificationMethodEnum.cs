using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Event
{
    
    [DataContract]
    public enum EventNotificationMethodEnum : long
    {
       [Description("None")][EnumMember]None = 0,
        
    }    
    
    public class EventNotificationMethod
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long NotificationMethodKey {get;set;}
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
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
