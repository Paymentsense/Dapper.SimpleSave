using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Event
{
    
    [DataContract]
    public enum TypeEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("SMS Scheduled")][EnumMember]SMSScheduled = 1,
       [Description("SMS Sent")][EnumMember]SMSSent = 2,
       [Description("SMS Received")][EnumMember]SMSReceived = 3,
       [Description("Email Scheduled")][EnumMember]EmailScheduled = 6,
       [Description("Email Sent")][EnumMember]EmailSent = 7,
       [Description("Email Received")][EnumMember]EmailReceived = 8,
       [Description("SMS Send Failed")][EnumMember]SMSSendFailed = 4,
       [Description("EmailSendFailed")][EnumMember]EmailSendFailed = 9,
       [Description("SMS Delivered")][EnumMember]SMSDelivered = 5,
        
    }

    public class Type
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long EventTypeKey {get;set;}
		public long EventCategoryKey {get;set;}
		public RecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class TypeCollection
    {
        private static List<Type> _list; 
        public static List<Type> TypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<Type>
                        {
                            new Type
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								EventTypeKey = 0,
								EventCategoryKey = 0,
								RecStatusKey = (RecStatusEnum)0
							},
							new Type
							{
								EnumValue = 1,
								EnumName = "SMSScheduled",
								EnumDescription = "SMS Scheduled",
								EventTypeKey = 1,
								EventCategoryKey = 1,
								RecStatusKey = (RecStatusEnum)1
							},
							new Type
							{
								EnumValue = 2,
								EnumName = "SMSSent",
								EnumDescription = "SMS Sent",
								EventTypeKey = 2,
								EventCategoryKey = 1,
								RecStatusKey = (RecStatusEnum)1
							},
							new Type
							{
								EnumValue = 3,
								EnumName = "SMSReceived",
								EnumDescription = "SMS Received",
								EventTypeKey = 3,
								EventCategoryKey = 1,
								RecStatusKey = (RecStatusEnum)1
							},
							new Type
							{
								EnumValue = 6,
								EnumName = "EmailScheduled",
								EnumDescription = "Email Scheduled",
								EventTypeKey = 6,
								EventCategoryKey = 1,
								RecStatusKey = (RecStatusEnum)1
							},
							new Type
							{
								EnumValue = 7,
								EnumName = "EmailSent",
								EnumDescription = "Email Sent",
								EventTypeKey = 7,
								EventCategoryKey = 1,
								RecStatusKey = (RecStatusEnum)1
							},
							new Type
							{
								EnumValue = 8,
								EnumName = "EmailReceived",
								EnumDescription = "Email Received",
								EventTypeKey = 8,
								EventCategoryKey = 1,
								RecStatusKey = (RecStatusEnum)1
							},
							new Type
							{
								EnumValue = 4,
								EnumName = "SMSSendFailed",
								EnumDescription = "SMS Send Failed",
								EventTypeKey = 4,
								EventCategoryKey = 1,
								RecStatusKey = (RecStatusEnum)1
							},
							new Type
							{
								EnumValue = 9,
								EnumName = "EmailSendFailed",
								EnumDescription = "EmailSendFailed",
								EventTypeKey = 9,
								EventCategoryKey = 1,
								RecStatusKey = (RecStatusEnum)1
							},
							new Type
							{
								EnumValue = 5,
								EnumName = "SMSDelivered",
								EnumDescription = "SMS Delivered",
								EventTypeKey = 5,
								EventCategoryKey = 1,
								RecStatusKey = (RecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
