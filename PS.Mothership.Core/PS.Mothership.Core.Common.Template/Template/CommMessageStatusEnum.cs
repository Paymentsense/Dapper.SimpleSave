using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Comm
{
    
    [DataContract]
    public enum MessageStatusEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Scheduled")][EnumMember]Scheduled = 1,
       [Description("Successful")][EnumMember]Successful = 2,
       [Description("Failed")][EnumMember]Failed = 3,
        
    }

    public class MessageStatus
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long MessageStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class MessageStatusCollection
    {
        private static List<MessageStatus> _list; 
        public static List<MessageStatus> MessageStatusList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<MessageStatus>
                        {
                            new MessageStatus
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								MessageStatusKey = 0
							},
							new MessageStatus
							{
								EnumValue = 1,
								EnumName = "Scheduled",
								EnumDescription = "Scheduled",
								MessageStatusKey = 1
							},
							new MessageStatus
							{
								EnumValue = 2,
								EnumName = "Successful",
								EnumDescription = "Successful",
								MessageStatusKey = 2
							},
							new MessageStatus
							{
								EnumValue = 3,
								EnumName = "Failed",
								EnumDescription = "Failed",
								MessageStatusKey = 3
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
