using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Comm
{
    
    [DataContract]
    public enum MessageEmailAddresstypeEnum : long
    {
       [Description("")][EnumMember]Blank = 1,
       [Description("")][EnumMember]From = 2,
       [Description("")][EnumMember]To = 3,
       [Description("")][EnumMember]CC = 4,
       [Description("")][EnumMember]BCC = 5,
        
    }

    public class MessageEmailAddresstype
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long MessageEmailAddressTypeKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class MessageEmailAddresstypeCollection
    {
        private static List<MessageEmailAddresstype> _list; 
        public static List<MessageEmailAddresstype> MessageEmailAddresstypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<MessageEmailAddresstype>
                        {
                            new MessageEmailAddresstype
							{
								EnumValue = 1,
								EnumName = "Blank",
								EnumDescription = "",
								MessageEmailAddressTypeKey = 1
							},
							new MessageEmailAddresstype
							{
								EnumValue = 2,
								EnumName = "From",
								EnumDescription = "",
								MessageEmailAddressTypeKey = 2
							},
							new MessageEmailAddresstype
							{
								EnumValue = 3,
								EnumName = "To",
								EnumDescription = "",
								MessageEmailAddressTypeKey = 3
							},
							new MessageEmailAddresstype
							{
								EnumValue = 4,
								EnumName = "CC",
								EnumDescription = "",
								MessageEmailAddressTypeKey = 4
							},
							new MessageEmailAddresstype
							{
								EnumValue = 5,
								EnumName = "BCC",
								EnumDescription = "",
								MessageEmailAddressTypeKey = 5
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
