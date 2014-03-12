using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Comm
{
    
    [DataContract]
    public enum MessageTypeEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("SMS")][EnumMember]SMS = 1,
       [Description("Email")][EnumMember]Email = 2,
        
    }

    public class MessageType
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long MessageTypeKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class MessageTypeCollection
    {
        private static List<MessageType> _list; 
        public static List<MessageType> MessageTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<MessageType>
                        {
                            new MessageType
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								MessageTypeKey = 0
							},
							new MessageType
							{
								EnumValue = 1,
								EnumName = "SMS",
								EnumDescription = "SMS",
								MessageTypeKey = 1
							},
							new MessageType
							{
								EnumValue = 2,
								EnumName = "Email",
								EnumDescription = "Email",
								MessageTypeKey = 2
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
