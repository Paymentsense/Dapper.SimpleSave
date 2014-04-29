using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenAddressTypesEnum : long
    {
       [Description("None")][EnumMember]None = 0,
        
    }    
    
    public class GenAddressTypes
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long AddressTypeKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class GenAddressTypesCollection
    {
        private static List<GenAddressTypes> _list; 
        public static List<GenAddressTypes> GenAddressTypesList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<GenAddressTypes>
                        {
                            new GenAddressTypes
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								AddressTypeKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
