using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Event
{
    
    [DataContract]
    public enum CategoryEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("General")][EnumMember]General = 1,
        
    }

    public class Category
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long EventCategoryKey {get;set;}
		public RecStatusEnum RecStatusKey {get;set;}
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
								EnumName = "None",
								EnumDescription = "None",
								EventCategoryKey = 0,
								RecStatusKey = (RecStatusEnum)0
							},
							new Category
							{
								EnumValue = 1,
								EnumName = "General",
								EnumDescription = "General",
								EventCategoryKey = 1,
								RecStatusKey = (RecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
