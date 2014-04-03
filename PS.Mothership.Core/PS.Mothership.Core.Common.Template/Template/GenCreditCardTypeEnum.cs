using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenCreditCardTypeEnum : long
    {
       [Description("None")][EnumMember]None = 0,
        
    }    
    
    public class GenCreditCardType
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long CreditCardTypeKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class GenCreditCardTypeCollection
    {
        private static List<GenCreditCardType> _list; 
        public static List<GenCreditCardType> GenCreditCardTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<GenCreditCardType>
                        {
                            new GenCreditCardType
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								CreditCardTypeKey = 0,
								RecStatusKey = (GenRecStatusEnum)2
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
