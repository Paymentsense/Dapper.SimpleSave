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
       [Description("Private Limited Company")][EnumMember]PrivateLimitedCompany = 1,
       [Description("Public Limited Company")][EnumMember]PublicLimitedCompany = 2,
       [Description("Partnership")][EnumMember]Partnership = 3,
       [Description("Trust")][EnumMember]Trust = 4,
       [Description("Limited Liability Partnership")][EnumMember]LimitedLiabilityPartnership = 5,
       [Description("Sole Trader")][EnumMember]SoleTrader = 6,
        
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
							new CustBusinessLegalType
							{
								EnumValue = 1,
								EnumName = "PrivateLimitedCompany",
								EnumDescription = "Private Limited Company",
								BusinessLegalTypeKey = 1,
								IsLimitedCompany = true,
								RecStatusKey = (GenRecStatusEnum)2
							},
							new CustBusinessLegalType
							{
								EnumValue = 2,
								EnumName = "PublicLimitedCompany",
								EnumDescription = "Public Limited Company",
								BusinessLegalTypeKey = 2,
								IsLimitedCompany = true,
								RecStatusKey = (GenRecStatusEnum)2
							},
							new CustBusinessLegalType
							{
								EnumValue = 3,
								EnumName = "Partnership",
								EnumDescription = "Partnership",
								BusinessLegalTypeKey = 3,
								IsLimitedCompany = false,
								RecStatusKey = (GenRecStatusEnum)2
							},
							new CustBusinessLegalType
							{
								EnumValue = 4,
								EnumName = "Trust",
								EnumDescription = "Trust",
								BusinessLegalTypeKey = 4,
								IsLimitedCompany = false,
								RecStatusKey = (GenRecStatusEnum)2
							},
							new CustBusinessLegalType
							{
								EnumValue = 5,
								EnumName = "LimitedLiabilityPartnership",
								EnumDescription = "Limited Liability Partnership",
								BusinessLegalTypeKey = 5,
								IsLimitedCompany = true,
								RecStatusKey = (GenRecStatusEnum)2
							},
							new CustBusinessLegalType
							{
								EnumValue = 6,
								EnumName = "SoleTrader",
								EnumDescription = "Sole Trader",
								BusinessLegalTypeKey = 6,
								IsLimitedCompany = false,
								RecStatusKey = (GenRecStatusEnum)2
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
