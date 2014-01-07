using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Comm
{
    
    [DataContract]
    public enum MessageStatusEnum : long
    {
       [Description("")][EnumMember]Unpublished = 1,
        
    }

    public class MessageStatus
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long MessageStatusKey {get;set;}
		public bool IsUseable {get;set;}
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
								EnumValue = 1,
								EnumName = "Unpublished",
								EnumDescription = "",
								MessageStatusKey = 1,
								IsUseable = false
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
