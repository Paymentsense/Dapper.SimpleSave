using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Usr
{
    
    [DataContract]
    public enum UsrResourceTypeEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Main Menu Area View")][EnumMember]MainMenuAreaView = 1,
       [Description("Admin View")][EnumMember]AdminView = 2,
       [Description("Partial View")][EnumMember]PartialView = 3,
       [Description("Merchant View")][EnumMember]MerchantView = 8,
        
    }    
    
    public class UsrResourceType
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long ResourceTypeKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class UsrResourceTypeCollection
    {
        private static List<UsrResourceType> _list; 
        public static List<UsrResourceType> UsrResourceTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<UsrResourceType>
                        {
                            new UsrResourceType
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								ResourceTypeKey = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrResourceType
							{
								EnumValue = 1,
								EnumName = "MainMenuAreaView",
								EnumDescription = "Main Menu Area View",
								ResourceTypeKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrResourceType
							{
								EnumValue = 2,
								EnumName = "AdminView",
								EnumDescription = "Admin View",
								ResourceTypeKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrResourceType
							{
								EnumValue = 3,
								EnumName = "PartialView",
								EnumDescription = "Partial View",
								ResourceTypeKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrResourceType
							{
								EnumValue = 8,
								EnumName = "MerchantView",
								EnumDescription = "Merchant View",
								ResourceTypeKey = 8,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
