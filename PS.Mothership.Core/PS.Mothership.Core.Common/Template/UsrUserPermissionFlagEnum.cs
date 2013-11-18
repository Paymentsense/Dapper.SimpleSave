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
       [Description("Add Resources")][EnumMember]Add = 1,
       [Description("Read Resources")][EnumMember]Read = 2,
       [Description("Delete Resources")][EnumMember]Delete = 4,
        
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
								PermissionKey=0
							},
							new UserPermissionFlag
							{
								EnumValue = 1,
								EnumName = "Add",
								EnumDescription = "Add Resources",
								PermissionKey=1
							},
							new UserPermissionFlag
							{
								EnumValue = 2,
								EnumName = "Read",
								EnumDescription = "Read Resources",
								PermissionKey=2
							},
							new UserPermissionFlag
							{
								EnumValue = 4,
								EnumName = "Delete",
								EnumDescription = "Delete Resources",
								PermissionKey=4
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
