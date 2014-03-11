using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Cust
{
    
    [DataContract]
    public enum CustBusinessLegalTypeEnum : long
    {
       [Description("None")][EnumMember]None = 0,
        
    }    
    
    public class CustBusinessLegalType
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long BusinessLegalTypeKey {get;set;}
		public bool IsLimitedCompany {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class CustBusinessLegalTypeCollection
    {
        private static List<CustBusinessLegalType> _list; 
        public static List<CustBusinessLegalType> CustBusinessLegalTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<CustBusinessLegalType>
                        {
                            new CustBusinessLegalType
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								BusinessLegalTypeKey = 0,
								IsLimitedCompany = false,
								RecStatusKey = (GenRecStatusEnum)0
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
