using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenPhoneNumberTypeEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Main Line")][EnumMember]MainLine = 1,
       [Description("Mobile")][EnumMember]Mobile = 2,
       [Description("Fax")][EnumMember]Fax = 3,
        
    }    
    
    public class GenPhoneNumberType
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int PhoneNumberTypeKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class GenPhoneNumberTypeCollection
    {
        private static List<GenPhoneNumberType> _list; 
        public static List<GenPhoneNumberType> GenPhoneNumberTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<GenPhoneNumberType>
                        {
                            new GenPhoneNumberType
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								PhoneNumberTypeKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenPhoneNumberType
							{
								EnumValue = 1,
								EnumName = "MainLine",
								EnumDescription = "Main Line",
								PhoneNumberTypeKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenPhoneNumberType
							{
								EnumValue = 2,
								EnumName = "Mobile",
								EnumDescription = "Mobile",
								PhoneNumberTypeKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenPhoneNumberType
							{
								EnumValue = 3,
								EnumName = "Fax",
								EnumDescription = "Fax",
								PhoneNumberTypeKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
