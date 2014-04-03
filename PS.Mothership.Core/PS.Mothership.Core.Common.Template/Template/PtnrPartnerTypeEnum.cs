using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Ptnr
{
    
    [DataContract]
    public enum PtnrPartnerTypeEnum : long
    {
       [Description("")][EnumMember]None = 0,
        
    }    
    
    public class PtnrPartnerType
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long PartnerTypeKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class PtnrPartnerTypeCollection
    {
        private static List<PtnrPartnerType> _list; 
        public static List<PtnrPartnerType> PtnrPartnerTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<PtnrPartnerType>
                        {
                            new PtnrPartnerType
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "",
								PartnerTypeKey = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
