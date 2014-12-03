using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenBusinessCategoryEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Retail")][EnumMember]Retail = 1,
       [Description("Restaurant")][EnumMember]Restaurant = 2,
       [Description("Internet")][EnumMember]Internet = 3,
       [Description("MOTO")][EnumMember]MOTO = 4,
       [Description("Hotel")][EnumMember]Hotel = 5,
        
    }    
    
    public class GenBusinessCategory
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int BusinessCategoryKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class GenBusinessCategoryCollection
    {
        private static List<GenBusinessCategory> _list; 
        public static List<GenBusinessCategory> GenBusinessCategoryList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<GenBusinessCategory>
                        {
                            new GenBusinessCategory
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								BusinessCategoryKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenBusinessCategory
							{
								EnumValue = 1,
								EnumName = "Retail",
								EnumDescription = "Retail",
								BusinessCategoryKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenBusinessCategory
							{
								EnumValue = 2,
								EnumName = "Restaurant",
								EnumDescription = "Restaurant",
								BusinessCategoryKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenBusinessCategory
							{
								EnumValue = 3,
								EnumName = "Internet",
								EnumDescription = "Internet",
								BusinessCategoryKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenBusinessCategory
							{
								EnumValue = 4,
								EnumName = "MOTO",
								EnumDescription = "MOTO",
								BusinessCategoryKey = 4,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenBusinessCategory
							{
								EnumValue = 5,
								EnumName = "Hotel",
								EnumDescription = "Hotel",
								BusinessCategoryKey = 5,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
