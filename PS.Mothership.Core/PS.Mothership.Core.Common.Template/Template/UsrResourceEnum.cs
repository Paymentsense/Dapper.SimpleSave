using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Usr
{
    
    [DataContract]
    public enum UsrResourceEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Home")][EnumMember]Home = 1,
       [Description("Admin")][EnumMember]Admin = 2,
       [Description("User Management")][EnumMember]UserManagement = 4,
       [Description("Role Management")][EnumMember]RoleManagement = 5,
       [Description("Group Management")][EnumMember]GroupManagement = 6,
       [Description("Dialler Client")][EnumMember]Dialler = 7,
       [Description("Merchant")][EnumMember]Merchant = 8,
       [Description("Schedule Management")][EnumMember]ScheduleManagement = 9,
       [Description("Search")][EnumMember]MerchantSearch = 10,
       [Description("Application")][EnumMember]Application = 11,
        
    }    
    
    public class UsrResource
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int ResourceKey {get;set;}
		public string ActionName {get;set;}
		public string ControllerName {get;set;}
		public string Area {get;set;}
		public string ContainerName {get;set;}
		public int ResourceTypeKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class UsrResourceCollection
    {
        private static List<UsrResource> _list; 
        public static List<UsrResource> UsrResourceList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<UsrResource>
                        {
                            new UsrResource
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								ResourceKey = 0,
								ActionName = "",
								ControllerName = "",
								Area = "",
								ContainerName = "",
								ResourceTypeKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new UsrResource
							{
								EnumValue = 1,
								EnumName = "Home",
								EnumDescription = "Home",
								ResourceKey = 1,
								ActionName = "Index",
								ControllerName = "Home",
								Area = "",
								ContainerName = "",
								ResourceTypeKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrResource
							{
								EnumValue = 2,
								EnumName = "Admin",
								EnumDescription = "Admin",
								ResourceKey = 2,
								ActionName = "Index",
								ControllerName = "Admin",
								Area = "Admin",
								ContainerName = "",
								ResourceTypeKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrResource
							{
								EnumValue = 4,
								EnumName = "UserManagement",
								EnumDescription = "User Management",
								ResourceKey = 4,
								ActionName = "Index",
								ControllerName = "UserManagement",
								Area = "Admin",
								ContainerName = "User Administration",
								ResourceTypeKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrResource
							{
								EnumValue = 5,
								EnumName = "RoleManagement",
								EnumDescription = "Role Management",
								ResourceKey = 5,
								ActionName = "Index",
								ControllerName = "RoleManagement",
								Area = "Admin",
								ContainerName = "User Administration",
								ResourceTypeKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrResource
							{
								EnumValue = 6,
								EnumName = "GroupManagement",
								EnumDescription = "Group Management",
								ResourceKey = 6,
								ActionName = "Index",
								ControllerName = "GroupManagement",
								Area = "Admin",
								ContainerName = "User Administration",
								ResourceTypeKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrResource
							{
								EnumValue = 7,
								EnumName = "Dialler",
								EnumDescription = "Dialler Client",
								ResourceKey = 7,
								ActionName = "_AdminRightSubMenu",
								ControllerName = "Dialler",
								Area = "",
								ContainerName = "",
								ResourceTypeKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrResource
							{
								EnumValue = 8,
								EnumName = "Merchant",
								EnumDescription = "Merchant",
								ResourceKey = 8,
								ActionName = "Index",
								ControllerName = "Merchant",
								Area = "Merchant",
								ContainerName = "",
								ResourceTypeKey = 1,
								RecStatusKey = (GenRecStatusEnum)2
							},
							new UsrResource
							{
								EnumValue = 9,
								EnumName = "ScheduleManagement",
								EnumDescription = "Schedule Management",
								ResourceKey = 9,
								ActionName = "Index",
								ControllerName = "ScheduleManagement",
								Area = "Admin",
								ContainerName = "Schedule Management",
								ResourceTypeKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrResource
							{
								EnumValue = 10,
								EnumName = "MerchantSearch",
								EnumDescription = "Search",
								ResourceKey = 10,
								ActionName = "Search",
								ControllerName = "Merchant",
								Area = "Merchant",
								ContainerName = "Merchant Management",
								ResourceTypeKey = 8,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrResource
							{
								EnumValue = 11,
								EnumName = "Application",
								EnumDescription = "Application",
								ResourceKey = 11,
								ActionName = "Index",
								ControllerName = "Application",
								Area = "Application",
								ContainerName = "",
								ResourceTypeKey = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
