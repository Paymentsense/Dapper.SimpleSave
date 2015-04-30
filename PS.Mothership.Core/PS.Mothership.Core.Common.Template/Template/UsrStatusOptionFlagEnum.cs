using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Usr
{
    [Flags]
    [DataContract]
    public enum UsrStatusOptionFlagEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Manage Email")][EnumMember]ManageEmail = 1,
       [Description("Allow Remote Access")][EnumMember]AllowRemoteAccess = 2,
       [Description("Provisioning Watch List")][EnumMember]ProvisioningWatchList = 4,
       [Description("Revolution User")][EnumMember]RevolutionUser = 8,
       [Description("Is Self TA")][EnumMember]IsSelfTA = 16,
       [Description("Can Impersonate")][EnumMember]CanImpersonate = 32,
        
    }    
    
    public class UsrStatusOptionFlag
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int OptionKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class UsrStatusOptionFlagCollection
    {
        private static List<UsrStatusOptionFlag> _list; 
        public static List<UsrStatusOptionFlag> UsrStatusOptionFlagList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<UsrStatusOptionFlag>
                        {
                            new UsrStatusOptionFlag
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								OptionKey = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrStatusOptionFlag
							{
								EnumValue = 1,
								EnumName = "ManageEmail",
								EnumDescription = "Manage Email",
								OptionKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrStatusOptionFlag
							{
								EnumValue = 2,
								EnumName = "AllowRemoteAccess",
								EnumDescription = "Allow Remote Access",
								OptionKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrStatusOptionFlag
							{
								EnumValue = 4,
								EnumName = "ProvisioningWatchList",
								EnumDescription = "Provisioning Watch List",
								OptionKey = 4,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrStatusOptionFlag
							{
								EnumValue = 8,
								EnumName = "RevolutionUser",
								EnumDescription = "Revolution User",
								OptionKey = 8,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrStatusOptionFlag
							{
								EnumValue = 16,
								EnumName = "IsSelfTA",
								EnumDescription = "Is Self TA",
								OptionKey = 16,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrStatusOptionFlag
							{
								EnumValue = 32,
								EnumName = "CanImpersonate",
								EnumDescription = "Can Impersonate",
								OptionKey = 32,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
