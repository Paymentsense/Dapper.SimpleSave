using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenCurrencyCodeEnum : long
    {
       [Description("Blank")][EnumMember]Blank = 0,
       [Description("BritishSterling")][EnumMember]BritishSterling = 1,
       [Description("Euro")][EnumMember]Euro = 2,
       [Description("USDollar")][EnumMember]USDollar = 3,
        
    }    
    
    public class GenCurrencyCode
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long CurrencyCodeKey {get;set;}
		public int IWLSCurrencyCode {get;set;}
		public int CurrencyBaseFraction {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class GenCurrencyCodeCollection
    {
        private static List<GenCurrencyCode> _list; 
        public static List<GenCurrencyCode> GenCurrencyCodeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<GenCurrencyCode>
                        {
                            new GenCurrencyCode
							{
								EnumValue = 0,
								EnumName = "Blank",
								EnumDescription = "Blank",
								CurrencyCodeKey = 0,
								IWLSCurrencyCode = 0,
								CurrencyBaseFraction = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenCurrencyCode
							{
								EnumValue = 1,
								EnumName = "BritishSterling",
								EnumDescription = "BritishSterling",
								CurrencyCodeKey = 1,
								IWLSCurrencyCode = 0,
								CurrencyBaseFraction = 0,
								RecStatusKey = (GenRecStatusEnum)2
							},
							new GenCurrencyCode
							{
								EnumValue = 2,
								EnumName = "Euro",
								EnumDescription = "Euro",
								CurrencyCodeKey = 2,
								IWLSCurrencyCode = 0,
								CurrencyBaseFraction = 0,
								RecStatusKey = (GenRecStatusEnum)2
							},
							new GenCurrencyCode
							{
								EnumValue = 3,
								EnumName = "USDollar",
								EnumDescription = "USDollar",
								CurrencyCodeKey = 3,
								IWLSCurrencyCode = 0,
								CurrencyBaseFraction = 0,
								RecStatusKey = (GenRecStatusEnum)2
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
