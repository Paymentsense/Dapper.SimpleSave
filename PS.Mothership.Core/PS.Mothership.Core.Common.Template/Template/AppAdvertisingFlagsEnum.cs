using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.App
{
    [Flags]
    [DataContract]
    public enum AppAdvertisingFlagsEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("BrochureMailAdvertising")][EnumMember]BrochureMailAdvertising = 1,
       [Description("CatalogAdvertising")][EnumMember]CatalogAdvertising = 2,
       [Description("InternetAdvertising")][EnumMember]InternetAdvertising = 3,
       [Description("NewspaperJournalAdvertising")][EnumMember]NewspaperJournalAdvertising = 4,
       [Description("PhoneAdvertising")][EnumMember]PhoneAdvertising = 5,
       [Description("TvRadioAdvertising")][EnumMember]TvRadioAdvertising = 6,
        
    }    
    
    public class AppAdvertisingFlags
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long AdvertisingFlagKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class AppAdvertisingFlagsCollection
    {
        private static List<AppAdvertisingFlags> _list; 
        public static List<AppAdvertisingFlags> AppAdvertisingFlagsList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<AppAdvertisingFlags>
                        {
                            new AppAdvertisingFlags
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								AdvertisingFlagKey = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppAdvertisingFlags
							{
								EnumValue = 1,
								EnumName = "BrochureMailAdvertising",
								EnumDescription = "BrochureMailAdvertising",
								AdvertisingFlagKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppAdvertisingFlags
							{
								EnumValue = 2,
								EnumName = "CatalogAdvertising",
								EnumDescription = "CatalogAdvertising",
								AdvertisingFlagKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppAdvertisingFlags
							{
								EnumValue = 3,
								EnumName = "InternetAdvertising",
								EnumDescription = "InternetAdvertising",
								AdvertisingFlagKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppAdvertisingFlags
							{
								EnumValue = 4,
								EnumName = "NewspaperJournalAdvertising",
								EnumDescription = "NewspaperJournalAdvertising",
								AdvertisingFlagKey = 4,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppAdvertisingFlags
							{
								EnumValue = 5,
								EnumName = "PhoneAdvertising",
								EnumDescription = "PhoneAdvertising",
								AdvertisingFlagKey = 5,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppAdvertisingFlags
							{
								EnumValue = 6,
								EnumName = "TvRadioAdvertising",
								EnumDescription = "TvRadioAdvertising",
								AdvertisingFlagKey = 6,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
