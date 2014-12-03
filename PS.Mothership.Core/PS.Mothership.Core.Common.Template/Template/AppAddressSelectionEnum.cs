using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.App
{
    
    [DataContract]
    public enum AppAddressSelectionEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Trading")][EnumMember]Trading = 1,
       [Description("Registered")][EnumMember]Registered = 2,
       [Description("Other")][EnumMember]Other = 3,
        
    }    
    
    public class AppAddressSelection
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int AddressSelectionKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class AppAddressSelectionCollection
    {
        private static List<AppAddressSelection> _list; 
        public static List<AppAddressSelection> AppAddressSelectionList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<AppAddressSelection>
                        {
                            new AppAddressSelection
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								AddressSelectionKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new AppAddressSelection
							{
								EnumValue = 1,
								EnumName = "Trading",
								EnumDescription = "Trading",
								AddressSelectionKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppAddressSelection
							{
								EnumValue = 2,
								EnumName = "Registered",
								EnumDescription = "Registered",
								AddressSelectionKey = 2,
								RecStatusKey = (GenRecStatusEnum)2
							},
							new AppAddressSelection
							{
								EnumValue = 3,
								EnumName = "Other",
								EnumDescription = "Other",
								AddressSelectionKey = 3,
								RecStatusKey = (GenRecStatusEnum)3
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
