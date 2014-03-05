using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Comm
{
    
    [DataContract]
    public enum MessageDirectionEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Sent")][EnumMember]Sent = 1,
       [Description("Received")][EnumMember]Received = 2,
        
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
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								MessageDirectionKey = 0
							},
							new MessageDirection
							{
								EnumValue = 1,
								EnumName = "Sent",
								EnumDescription = "Sent",
								MessageDirectionKey = 1
							},
							new MessageDirection
							{
								EnumValue = 2,
								EnumName = "Received",
								EnumDescription = "Received",
								MessageDirectionKey = 2
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
