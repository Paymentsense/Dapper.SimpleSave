using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Comm
{
    
    [DataContract]
    public enum MessageResultEnum : long
    {
       [Description("")][EnumMember]Blank = 1,
       [Description("")][EnumMember]Successful = 2,
       [Description("")][EnumMember]Failed = 3,
        
    }

    public class MessageResult
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long MessageResultKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class MessageResultCollection
    {
        private static List<MessageResult> _list; 
        public static List<MessageResult> MessageResultList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<MessageResult>
                        {
                            new MessageResult
							{
								EnumValue = 1,
								EnumName = "Blank",
								EnumDescription = "",
								MessageResultKey = 1
							},
							new MessageResult
							{
								EnumValue = 2,
								EnumName = "Successful",
								EnumDescription = "",
								MessageResultKey = 2
							},
							new MessageResult
							{
								EnumValue = 3,
								EnumName = "Failed",
								EnumDescription = "",
								MessageResultKey = 3
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
