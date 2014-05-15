using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Opp
{
    
    [DataContract]
    public enum OppEquipmentCategoryEnum : long
    {
       [Description("")][EnumMember]None = 0,
        
    }    
    
    public class OppEquipmentCategory
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long EquipmentCategoryKey {get;set;}
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
								EnumDescription = "",
								EquipmentCategoryKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
