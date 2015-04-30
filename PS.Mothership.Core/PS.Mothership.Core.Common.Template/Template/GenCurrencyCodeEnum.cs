using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenCurrencyCodeEnum : int
    {
       [Description("Blank")][EnumMember]Blank = 0,
       [Description("BritishSterling")][EnumMember]GBP = 1,
       [Description("Euro")][EnumMember]EUR = 2,
       [Description("USDollar")][EnumMember]USD = 3,
        
    }    
    
    public class GenCurrencyCode
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int CurrencyCodeKey {get;set;}
		public int IWLSCurrencyCode {get;set;}
		public int CurrencyBaseFraction {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
		public string Unit {get;set;}
		public string SubUnit {get;set;}
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
								RecStatusKey = (GenRecStatusEnum)0,
								Unit = "",
								SubUnit = ""
							},
							new GenCurrencyCode
							{
								EnumValue = 1,
								EnumName = "GBP",
								EnumDescription = "BritishSterling",
								CurrencyCodeKey = 1,
								IWLSCurrencyCode = 0,
								CurrencyBaseFraction = 0,
								RecStatusKey = (GenRecStatusEnum)1,
								Unit = "£",
								SubUnit = "p"
							},
							new GenCurrencyCode
							{
								EnumValue = 2,
								EnumName = "EUR",
								EnumDescription = "Euro",
								CurrencyCodeKey = 2,
								IWLSCurrencyCode = 0,
								CurrencyBaseFraction = 0,
								RecStatusKey = (GenRecStatusEnum)1,
								Unit = "€",
								SubUnit = "c"
							},
							new GenCurrencyCode
							{
								EnumValue = 3,
								EnumName = "USD",
								EnumDescription = "USDollar",
								CurrencyCodeKey = 3,
								IWLSCurrencyCode = 0,
								CurrencyBaseFraction = 0,
								RecStatusKey = (GenRecStatusEnum)1,
								Unit = "$",
								SubUnit = "¢"
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
