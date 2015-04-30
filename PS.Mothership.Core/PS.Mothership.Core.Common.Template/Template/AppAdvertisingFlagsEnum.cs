using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.App
{
    [Flags]
    [DataContract]
    public enum AppAdvertisingFlagsEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Brochure/Mail")][EnumMember]BrochureMailAdvertising = 1,
       [Description("Catalog")][EnumMember]CatalogAdvertising = 2,
       [Description("Internet")][EnumMember]InternetAdvertising = 4,
       [Description("Newspaper/Journal")][EnumMember]NewspaperJournalAdvertising = 8,
       [Description("Phone")][EnumMember]PhoneAdvertising = 16,
       [Description("TV/Radio")][EnumMember]TvRadioAdvertising = 32,
        
    }    
    
    public class AppAdvertisingFlags
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int AdvertisingFlagKey {get;set;}
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
								RecStatusKey = (GenRecStatusEnum)0
							},
							new AppAdvertisingFlags
							{
								EnumValue = 1,
								EnumName = "BrochureMailAdvertising",
								EnumDescription = "Brochure/Mail",
								AdvertisingFlagKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppAdvertisingFlags
							{
								EnumValue = 2,
								EnumName = "CatalogAdvertising",
								EnumDescription = "Catalog",
								AdvertisingFlagKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppAdvertisingFlags
							{
								EnumValue = 4,
								EnumName = "InternetAdvertising",
								EnumDescription = "Internet",
								AdvertisingFlagKey = 4,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppAdvertisingFlags
							{
								EnumValue = 8,
								EnumName = "NewspaperJournalAdvertising",
								EnumDescription = "Newspaper/Journal",
								AdvertisingFlagKey = 8,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppAdvertisingFlags
							{
								EnumValue = 16,
								EnumName = "PhoneAdvertising",
								EnumDescription = "Phone",
								AdvertisingFlagKey = 16,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppAdvertisingFlags
							{
								EnumValue = 32,
								EnumName = "TvRadioAdvertising",
								EnumDescription = "TV/Radio",
								AdvertisingFlagKey = 32,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
