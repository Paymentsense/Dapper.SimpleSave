using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenBusinessLegalTypeEnum : int
    {
       [Description("")][EnumMember]None = 0,
       [Description("Private Limited Company")][EnumMember]PrivateLimitedCompany = 1,
       [Description("Public Limited Company")][EnumMember]PublicLimitedCompany = 2,
       [Description("Partnership")][EnumMember]Partnership = 3,
       [Description("Trust")][EnumMember]Trust = 4,
       [Description("Limited Liability Partnership")][EnumMember]LimitedLiabilityPartnership = 5,
       [Description("Sole Trader")][EnumMember]SoleTrader = 6,
        
    }    
    
    public class GenBusinessLegalType
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int BusinessLegalTypeKey {get;set;}
		public bool IsLimitedCompany {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class GenBusinessLegalTypeCollection
    {
        private static List<GenBusinessLegalType> _list; 
        public static List<GenBusinessLegalType> GenBusinessLegalTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<GenBusinessLegalType>
                        {
                            new GenBusinessLegalType
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "",
								BusinessLegalTypeKey = 0,
								IsLimitedCompany = false,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenBusinessLegalType
							{
								EnumValue = 1,
								EnumName = "PrivateLimitedCompany",
								EnumDescription = "Private Limited Company",
								BusinessLegalTypeKey = 1,
								IsLimitedCompany = true,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenBusinessLegalType
							{
								EnumValue = 2,
								EnumName = "PublicLimitedCompany",
								EnumDescription = "Public Limited Company",
								BusinessLegalTypeKey = 2,
								IsLimitedCompany = true,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenBusinessLegalType
							{
								EnumValue = 3,
								EnumName = "Partnership",
								EnumDescription = "Partnership",
								BusinessLegalTypeKey = 3,
								IsLimitedCompany = false,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenBusinessLegalType
							{
								EnumValue = 4,
								EnumName = "Trust",
								EnumDescription = "Trust",
								BusinessLegalTypeKey = 4,
								IsLimitedCompany = false,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenBusinessLegalType
							{
								EnumValue = 5,
								EnumName = "LimitedLiabilityPartnership",
								EnumDescription = "Limited Liability Partnership",
								BusinessLegalTypeKey = 5,
								IsLimitedCompany = true,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenBusinessLegalType
							{
								EnumValue = 6,
								EnumName = "SoleTrader",
								EnumDescription = "Sole Trader",
								BusinessLegalTypeKey = 6,
								IsLimitedCompany = false,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
