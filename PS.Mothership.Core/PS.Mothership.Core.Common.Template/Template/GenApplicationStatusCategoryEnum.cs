using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenApplicationStatusCategoryEnum : int
    {
       [Description("None")][EnumMember]None = 0,
        
    }    
    
    public class GenApplicationStatusCategory
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int ApplicationStatusCategoryKey {get;set;}
		public int ApplicationStatusGroupKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class GenApplicationStatusCategoryCollection
    {
        private static List<GenApplicationStatusCategory> _list; 
        public static List<GenApplicationStatusCategory> GenApplicationStatusCategoryList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<GenApplicationStatusCategory>
                        {
                            new GenApplicationStatusCategory
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								ApplicationStatusCategoryKey = 0,
								ApplicationStatusGroupKey = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
