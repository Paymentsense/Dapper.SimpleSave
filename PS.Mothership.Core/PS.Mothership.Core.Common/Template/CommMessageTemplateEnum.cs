using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Comm
{
    
    [DataContract]
    public enum MessageTemplateEnum : long
    {
       [Description("")][EnumMember]Blank = 1,
        
    }

    public class MessageTemplate
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long MessageTemplateKey {get;set;}
		public string FileName {get;set;}
		public int UpdateDate {get;set;}
		public int UpdateSessionGUID {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class MessageTemplateCollection
    {
        private static List<MessageTemplate> _list; 
        public static List<MessageTemplate> MessageTemplateList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<MessageTemplate>
                        {
                            new MessageTemplate
							{
								EnumValue = 1,
								EnumName = "Blank",
								EnumDescription = "",
								MessageTemplateKey = 1,
								FileName = "Blank",
								UpdateDate = 01/01/1900 00:00:00 -05:00,
								UpdateSessionGUID = 00000000-0000-0000-0000-000000000000
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
