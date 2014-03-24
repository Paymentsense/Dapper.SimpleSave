using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Usr
{
    [Flags]
    [DataContract]
    public enum UsrUserPermissionFlagEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("View Permission")][EnumMember]View = 1,
       [Description("Add Permission")][EnumMember]Add = 2,
       [Description("Edit Permission")][EnumMember]Edit = 4,
       [Description("Delete Permission")][EnumMember]Delete = 8,
        
    }    
    
    public class UsrUserPermissionFlag
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long PermissionKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class UsrUserPermissionFlagCollection
    {
        private static List<UsrUserPermissionFlag> _list; 
        public static List<UsrUserPermissionFlag> UsrUserPermissionFlagList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<UsrUserPermissionFlag>
                        {
                            new UsrUserPermissionFlag
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								PermissionKey = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrUserPermissionFlag
							{
								EnumValue = 1,
								EnumName = "View",
								EnumDescription = "View Permission",
								PermissionKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrUserPermissionFlag
							{
								EnumValue = 2,
								EnumName = "Add",
								EnumDescription = "Add Permission",
								PermissionKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrUserPermissionFlag
							{
								EnumValue = 4,
								EnumName = "Edit",
								EnumDescription = "Edit Permission",
								PermissionKey = 4,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrUserPermissionFlag
							{
								EnumValue = 8,
								EnumName = "Delete",
								EnumDescription = "Delete Permission",
								PermissionKey = 8,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
