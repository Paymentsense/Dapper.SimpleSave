using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Opp
{
    
    [DataContract]
    public enum OppCommissionCategoryEnum : int
    {
       [Description("None")][EnumMember]None = 0,
        
    }    
    
    public class OppCommissionCategory
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int CommissionCategoryKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class OppCommissionCategoryCollection
    {
        private static List<OppCommissionCategory> _list; 
        public static List<OppCommissionCategory> OppCommissionCategoryList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<OppCommissionCategory>
                        {
                            new OppCommissionCategory
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								CommissionCategoryKey = 0,
								RecStatusKey = (GenRecStatusEnum)2
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
