using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Opp
{
    
    [DataContract]
    public enum OppEquipmentCategoryEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Desktop")][EnumMember]Desktop = 1,
       [Description("Portable")][EnumMember]Portable = 2,
       [Description("Mobile")][EnumMember]Mobile = 3,
        
    }    
    
    public class OppEquipmentCategory
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int EquipmentCategoryKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class OppEquipmentCategoryCollection
    {
        private static List<OppEquipmentCategory> _list; 
        public static List<OppEquipmentCategory> OppEquipmentCategoryList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<OppEquipmentCategory>
                        {
                            new OppEquipmentCategory
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								EquipmentCategoryKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new OppEquipmentCategory
							{
								EnumValue = 1,
								EnumName = "Desktop",
								EnumDescription = "Desktop",
								EquipmentCategoryKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new OppEquipmentCategory
							{
								EnumValue = 2,
								EnumName = "Portable",
								EnumDescription = "Portable",
								EquipmentCategoryKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new OppEquipmentCategory
							{
								EnumValue = 3,
								EnumName = "Mobile",
								EnumDescription = "Mobile",
								EquipmentCategoryKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
