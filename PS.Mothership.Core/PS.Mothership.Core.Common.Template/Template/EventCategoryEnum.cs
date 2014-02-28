using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Event
{
    
    [DataContract]
    public enum CategoryEnum : long
    {
       [Description("")][EnumMember]Blank = 0,
       [Description("")][EnumMember]SMS = 1,
       [Description("")][EnumMember]Email = 2,
        
    }

    public class Category
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long EventCategoryKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class CategoryCollection
    {
        private static List<Category> _list; 
        public static List<Category> CategoryList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<Category>
                        {
                            new Category
							{
								EnumValue = 0,
								EnumName = "Blank",
								EnumDescription = "",
								EventCategoryKey = 0
							},
							new Category
							{
								EnumValue = 1,
								EnumName = "SMS",
								EnumDescription = "",
								EventCategoryKey = 1
							},
							new Category
							{
								EnumValue = 2,
								EnumName = "Email",
								EnumDescription = "",
								EventCategoryKey = 2
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
