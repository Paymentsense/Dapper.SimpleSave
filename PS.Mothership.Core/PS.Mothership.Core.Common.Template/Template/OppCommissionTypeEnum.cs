using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Opp
{
    
    [DataContract]
    public enum OppCommissionTypeEnum : int
    {
       [Description("None")][EnumMember]None = 0,
        
    }    
    
    public class OppCommissionType
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int CommissionTypeKey {get;set;}
		public int CommissionCategoryKey {get;set;}
		public bool IsRecalced {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class OppCommissionTypeCollection
    {
        private static List<OppCommissionType> _list; 
        public static List<OppCommissionType> OppCommissionTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<OppCommissionType>
                        {
                            new OppCommissionType
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								CommissionTypeKey = 0,
								CommissionCategoryKey = 0,
								IsRecalced = false,
								RecStatusKey = (GenRecStatusEnum)2
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
