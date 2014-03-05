using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Event
{
    
    [DataContract]
    public enum TypeEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("SMS")][EnumMember]SMS = 1,
       [Description("Email")][EnumMember]Email = 2,
        
    }

    public class Type
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long EventTypeKey {get;set;}
		public long EventCategoryKey {get;set;}
		public bool ReferenceGUIDRequired {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class TypeCollection
    {
        private static List<Type> _list; 
        public static List<Type> TypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<Type>
                        {
                            new Type
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								EventTypeKey = 0,
								EventCategoryKey = 0,
								ReferenceGUIDRequired = false
							},
							new Type
							{
								EnumValue = 1,
								EnumName = "SMS",
								EnumDescription = "SMS",
								EventTypeKey = 1,
								EventCategoryKey = 1,
								ReferenceGUIDRequired = false
							},
							new Type
							{
								EnumValue = 2,
								EnumName = "Email",
								EnumDescription = "Email",
								EventTypeKey = 2,
								EventCategoryKey = 2,
								ReferenceGUIDRequired = false
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
