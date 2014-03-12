using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Comm
{
    
    [DataContract]
    public enum MessageEmailAddresstypeEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("From")][EnumMember]From = 1,
       [Description("To")][EnumMember]To = 2,
       [Description("CC")][EnumMember]CC = 3,
       [Description("BCC")][EnumMember]BCC = 4,
        
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
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								MessageEmailAddressTypeKey = 0
							},
							new MessageEmailAddresstype
							{
								EnumValue = 1,
								EnumName = "From",
								EnumDescription = "From",
								MessageEmailAddressTypeKey = 1
							},
							new MessageEmailAddresstype
							{
								EnumValue = 2,
								EnumName = "To",
								EnumDescription = "To",
								MessageEmailAddressTypeKey = 2
							},
							new MessageEmailAddresstype
							{
								EnumValue = 3,
								EnumName = "CC",
								EnumDescription = "CC",
								MessageEmailAddressTypeKey = 3
							},
							new MessageEmailAddresstype
							{
								EnumValue = 4,
								EnumName = "BCC",
								EnumDescription = "BCC",
								MessageEmailAddressTypeKey = 4
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
