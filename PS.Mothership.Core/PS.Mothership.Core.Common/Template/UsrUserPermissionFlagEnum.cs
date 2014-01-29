using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Usr
{
    [Flags]
    [DataContract]
    public enum UserPermissionFlagEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("View Permission")][EnumMember]View = 1,
       [Description("Add Permission")][EnumMember]Add = 2,
       [Description("Edit Permission")][EnumMember]Edit = 4,
       [Description("Delete Permission")][EnumMember]Delete = 8,
        
    }

    public class UserPermissionFlag
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long PermissionKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class UserPermissionFlagCollection
    {
        private static List<UserPermissionFlag> _list; 
        public static List<UserPermissionFlag> UserPermissionFlagList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<UserPermissionFlag>
                        {
                            new UserPermissionFlag
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								PermissionKey = 0
							},
							new UserPermissionFlag
							{
								EnumValue = 1,
								EnumName = "View",
								EnumDescription = "View Permission",
								PermissionKey = 1
							},
							new UserPermissionFlag
							{
								EnumValue = 2,
								EnumName = "Add",
								EnumDescription = "Add Permission",
								PermissionKey = 2
							},
							new UserPermissionFlag
							{
								EnumValue = 4,
								EnumName = "Edit",
								EnumDescription = "Edit Permission",
								PermissionKey = 4
							},
							new UserPermissionFlag
							{
								EnumValue = 8,
								EnumName = "Delete",
								EnumDescription = "Delete Permission",
								PermissionKey = 8
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
