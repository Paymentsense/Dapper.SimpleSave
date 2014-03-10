using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Cust
{
    
    [DataContract]
    public enum BusinessLegalTypeEnum : long
    {
       [Description("None")][EnumMember]None = 0,
        
    }

    public class BusinessLegalType
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long BusinessLegalTypeKey {get;set;}
		public bool IsLimitedCompany {get;set;}
		public RecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class BusinessLegalTypeCollection
    {
        private static List<BusinessLegalType> _list; 
        public static List<BusinessLegalType> BusinessLegalTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<BusinessLegalType>
                        {
                            new BusinessLegalType
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								BusinessLegalTypeKey = 0,
								IsLimitedCompany = false,
								RecStatusKey = (RecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
