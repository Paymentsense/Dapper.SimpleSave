using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Event
{
    
    [DataContract]
    public enum NotificationMethodEnum : long
    {
       [Description("Blank")][EnumMember]Blank = 1,
       [Description("Nothing")][EnumMember]Nothing = 2,
        
    }

    public class NotificationMethod
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long NotificationMethodKey {get;set;}
		public RecStatusEnum RecStatusKey {get;set;}
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
								EnumValue = 1,
								EnumName = "Blank",
								EnumDescription = "Blank",
								NotificationMethodKey = 1,
								RecStatusKey = (RecStatusEnum)1
							},
							new NotificationMethod
							{
								EnumValue = 2,
								EnumName = "Nothing",
								EnumDescription = "Nothing",
								NotificationMethodKey = 2,
								RecStatusKey = (RecStatusEnum)2
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
