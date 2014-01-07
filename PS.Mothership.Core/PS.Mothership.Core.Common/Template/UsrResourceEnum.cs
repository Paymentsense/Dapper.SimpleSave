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
       [Description("Home Page")][EnumMember]Home = 1,
       [Description("Admin Page")][EnumMember]Admin = 2,
       [Description("Task Page")][EnumMember]Task = 3,
        
    }

    public class Resource
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long ResourceKey {get;set;}
		public string ActionName {get;set;}
		public string ControllerName {get;set;}
		public string Area {get;set;}
		public long ResourceTypeKey {get;set;}
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
								ResourceKey = 0,
								ActionName = "",
								ControllerName = "",
								Area = "",
								ResourceTypeKey = 0
							},
							new Resource
							{
								EnumValue = 1,
								EnumName = "Home",
								EnumDescription = "Home Page",
								ResourceKey = 1,
								ActionName = "Index",
								ControllerName = "Home",
								Area = "",
								ResourceTypeKey = 1
							},
							new Resource
							{
								EnumValue = 2,
								EnumName = "Admin",
								EnumDescription = "Admin Page",
								ResourceKey = 2,
								ActionName = "Index",
								ControllerName = "Admin",
								Area = "Admin",
								ResourceTypeKey = 1
							},
							new Resource
							{
								EnumValue = 3,
								EnumName = "Task",
								EnumDescription = "Task Page",
								ResourceKey = 3,
								ActionName = "Index",
								ControllerName = "Task",
								Area = "",
								ResourceTypeKey = 1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
