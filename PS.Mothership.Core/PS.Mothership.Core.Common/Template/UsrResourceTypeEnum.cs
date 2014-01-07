using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Usr
{
    
    [DataContract]
    public enum ResourceTypeEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Main Menu Area View")][EnumMember]MainMenuAreaView = 1,
       [Description("Admin View")][EnumMember]AdminView = 2,
       [Description("Partial View")][EnumMember]PartialView = 3,
        
    }

    public class ResourceType
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long ResourceTypeKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class ResourceTypeCollection
    {
        private static List<ResourceType> _list; 
        public static List<ResourceType> ResourceTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<ResourceType>
                        {
                            new ResourceType
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								ResourceTypeKey = 0
							},
							new ResourceType
							{
								EnumValue = 1,
								EnumName = "MainMenuAreaView",
								EnumDescription = "Main Menu Area View",
								ResourceTypeKey = 1
							},
							new ResourceType
							{
								EnumValue = 2,
								EnumName = "AdminView",
								EnumDescription = "Admin View",
								ResourceTypeKey = 2
							},
							new ResourceType
							{
								EnumValue = 3,
								EnumName = "PartialView",
								EnumDescription = "Partial View",
								ResourceTypeKey = 3
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
