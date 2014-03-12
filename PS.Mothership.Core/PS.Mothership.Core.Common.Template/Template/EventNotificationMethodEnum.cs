using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Event
{
    
    [DataContract]
    public enum NotificationMethodEnum : long
    {
       [Description("None")][EnumMember]None = 0,
        
    }

    public class NotificationMethod
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long NotificationMethodKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class NotificationMethodCollection
    {
        private static List<NotificationMethod> _list; 
        public static List<NotificationMethod> NotificationMethodList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<NotificationMethod>
                        {
                            new NotificationMethod
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								NotificationMethodKey = 0
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
