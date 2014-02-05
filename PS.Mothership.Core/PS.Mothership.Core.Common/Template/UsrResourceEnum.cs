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
       [Description("Home")][EnumMember]Home = 1,
       [Description("Admin")][EnumMember]Admin = 2,
       [Description("Task")][EnumMember]Task = 3,
       [Description("User Management")][EnumMember]UserManagement = 4,
       [Description("Role Management")][EnumMember]RoleManagement = 5,
       [Description("Group Management")][EnumMember]GroupManagement = 6,
       [Description("Dialler Client")][EnumMember]Dialler = 7,
        
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
		public string ContainerName {get;set;}
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
								ContainerName = "",
								ResourceTypeKey = 0
							},
							new Resource
							{
								EnumValue = 1,
								EnumName = "Home",
								EnumDescription = "Home",
								ResourceKey = 1,
								ActionName = "Index",
								ControllerName = "Home",
								Area = "",
								ContainerName = "",
								ResourceTypeKey = 1
							},
							new Resource
							{
								EnumValue = 2,
								EnumName = "Admin",
								EnumDescription = "Admin",
								ResourceKey = 2,
								ActionName = "Index",
								ControllerName = "Admin",
								Area = "Admin",
								ContainerName = "",
								ResourceTypeKey = 1
							},
							new Resource
							{
								EnumValue = 3,
								EnumName = "Task",
								EnumDescription = "Task",
								ResourceKey = 3,
								ActionName = "Index",
								ControllerName = "Task",
								Area = "",
								ContainerName = "",
								ResourceTypeKey = 1
							},
							new Resource
							{
								EnumValue = 4,
								EnumName = "UserManagement",
								EnumDescription = "User Management",
								ResourceKey = 4,
								ActionName = "Index",
								ControllerName = "UserManagement",
								Area = "Admin",
								ContainerName = "User Administration",
								ResourceTypeKey = 2
							},
							new Resource
							{
								EnumValue = 5,
								EnumName = "RoleManagement",
								EnumDescription = "Role Management",
								ResourceKey = 5,
								ActionName = "Index",
								ControllerName = "RoleManagement",
								Area = "Admin",
								ContainerName = "User Administration",
								ResourceTypeKey = 2
							},
							new Resource
							{
								EnumValue = 6,
								EnumName = "GroupManagement",
								EnumDescription = "Group Management",
								ResourceKey = 6,
								ActionName = "Index",
								ControllerName = "GroupManagement",
								Area = "Admin",
								ContainerName = "User Administration",
								ResourceTypeKey = 2
							},
							new Resource
							{
								EnumValue = 7,
								EnumName = "Dialler",
								EnumDescription = "Dialler Client",
								ResourceKey = 7,
								ActionName = "_AdminRightSubMenu",
								ControllerName = "Dialler",
								Area = "",
								ContainerName = "",
								ResourceTypeKey = 3
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
