using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.App
{
    
    [DataContract]
    public enum AppPremisesTypeEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Restaurant")][EnumMember]Restaurant = 1,
       [Description("Retail Outlet")][EnumMember]RetailOutlet = 2,
       [Description("Hotel")][EnumMember]Hotel = 3,
       [Description("Office")][EnumMember]Office = 4,
       [Description("Residential")][EnumMember]Residential = 5,
       [Description("Industrial Unit")][EnumMember]IndustrialUnit = 6,
       [Description("Fixed Stand/Stall")][EnumMember]FixedStandStall = 7,
        
    }    
    
    public class AppPremisesType
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int PremisesTypeKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class AppPremisesTypeCollection
    {
        private static List<AppPremisesType> _list; 
        public static List<AppPremisesType> AppPremisesTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<AppPremisesType>
                        {
                            new AppPremisesType
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								PremisesTypeKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new AppPremisesType
							{
								EnumValue = 1,
								EnumName = "Restaurant",
								EnumDescription = "Restaurant",
								PremisesTypeKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppPremisesType
							{
								EnumValue = 2,
								EnumName = "RetailOutlet",
								EnumDescription = "Retail Outlet",
								PremisesTypeKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppPremisesType
							{
								EnumValue = 3,
								EnumName = "Hotel",
								EnumDescription = "Hotel",
								PremisesTypeKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppPremisesType
							{
								EnumValue = 4,
								EnumName = "Office",
								EnumDescription = "Office",
								PremisesTypeKey = 4,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppPremisesType
							{
								EnumValue = 5,
								EnumName = "Residential",
								EnumDescription = "Residential",
								PremisesTypeKey = 5,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppPremisesType
							{
								EnumValue = 6,
								EnumName = "IndustrialUnit",
								EnumDescription = "Industrial Unit",
								PremisesTypeKey = 6,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppPremisesType
							{
								EnumValue = 7,
								EnumName = "FixedStandStall",
								EnumDescription = "Fixed Stand/Stall",
								PremisesTypeKey = 7,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
