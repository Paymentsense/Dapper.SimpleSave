using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Usr
{
    [Flags]
    [DataContract]
    public enum StatusOptionFlagEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Manage Email")][EnumMember]ManageEmail = 1,
       [Description("Allow remote access")][EnumMember]AllowRemoteAccess = 2,
       [Description("Provisionign watch list")][EnumMember]ProvisioningWatchList = 4,
       [Description("")][EnumMember]RevolutionUser = 8,
       [Description("")][EnumMember]IsSelfTA = 16,
       [Description("")][EnumMember]CanImpersonate = 32,
        
    }

    public class StatusOptionFlag
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long OptionKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class StatusOptionFlagCollection
    {
        private static List<StatusOptionFlag> _list; 
        public static List<StatusOptionFlag> StatusOptionFlagList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<StatusOptionFlag>
                        {
                            							new StatusOptionFlag
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								OptionKey=0
							},
							new StatusOptionFlag
							{
								EnumValue = 1,
								EnumName = "ManageEmail",
								EnumDescription = "Manage Email",
								OptionKey=1
							},
							new StatusOptionFlag
							{
								EnumValue = 2,
								EnumName = "AllowRemoteAccess",
								EnumDescription = "Allow remote access",
								OptionKey=2
							},
							new StatusOptionFlag
							{
								EnumValue = 4,
								EnumName = "ProvisioningWatchList",
								EnumDescription = "Provisionign watch list",
								OptionKey=4
							},
							new StatusOptionFlag
							{
								EnumValue = 8,
								EnumName = "RevolutionUser",
								EnumDescription = "",
								OptionKey=8
							},
							new StatusOptionFlag
							{
								EnumValue = 16,
								EnumName = "IsSelfTA",
								EnumDescription = "",
								OptionKey=16
							},
							new StatusOptionFlag
							{
								EnumValue = 32,
								EnumName = "CanImpersonate",
								EnumDescription = "",
								OptionKey=32
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
