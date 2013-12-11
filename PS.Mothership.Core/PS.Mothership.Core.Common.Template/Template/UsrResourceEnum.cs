using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Usr
{
    
    [DataContract]
    public enum ResourceEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Modules")][EnumMember]Module = 1,
       [Description("Pages")][EnumMember]Page = 2,
        
    }

    public class Resource
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long ResourceKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class ResourceCollection
    {
        private static List<Resource> _list; 
        public static List<Resource> ResourceList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<Resource>
                        {
                            							new Resource
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								ResourceKey=0
							},
							new Resource
							{
								EnumValue = 1,
								EnumName = "Module",
								EnumDescription = "Modules",
								ResourceKey=1
							},
							new Resource
							{
								EnumValue = 2,
								EnumName = "Page",
								EnumDescription = "Pages",
								ResourceKey=2
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
