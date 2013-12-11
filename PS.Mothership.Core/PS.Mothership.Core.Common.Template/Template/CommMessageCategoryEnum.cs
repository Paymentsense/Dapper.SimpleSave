using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Comm
{
    
    [DataContract]
    public enum MessageCategoryEnum : long
    {
       [Description("")][EnumMember]Blank = 0,
        
    }

    public class MessageCategory
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long MessageCategoryKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class MessageCategoryCollection
    {
        private static List<MessageCategory> _list; 
        public static List<MessageCategory> MessageCategoryList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<MessageCategory>
                        {
                            							new MessageCategory
							{
								EnumValue = 0,
								EnumName = "Blank",
								EnumDescription = "",
								MessageCategoryKey=0
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
