using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Comm
{
    
    [DataContract]
    public enum MessageDirectionEnum : long
    {
       [Description("")][EnumMember]Blank = 1,
       [Description("")][EnumMember]Sent = 2,
       [Description("")][EnumMember]Received = 3,
        
    }

    public class MessageDirection
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long MessageDirectionKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class MessageDirectionCollection
    {
        private static List<MessageDirection> _list; 
        public static List<MessageDirection> MessageDirectionList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<MessageDirection>
                        {
                            new MessageDirection
							{
								EnumValue = 1,
								EnumName = "Blank",
								EnumDescription = "",
								MessageDirectionKey = 1
							},
							new MessageDirection
							{
								EnumValue = 2,
								EnumName = "Sent",
								EnumDescription = "",
								MessageDirectionKey = 2
							},
							new MessageDirection
							{
								EnumValue = 3,
								EnumName = "Received",
								EnumDescription = "",
								MessageDirectionKey = 3
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
