using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Ptnr
{
    
    [DataContract]
    public enum PtnrPartnerStatusEnum : long
    {
       [Description("")][EnumMember]None = 0,
        
    }    
    
    public class PtnrPartnerStatus
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long PartnerStatusKey {get;set;}
		public long IsActive {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class PtnrPartnerStatusCollection
    {
        private static List<PtnrPartnerStatus> _list; 
        public static List<PtnrPartnerStatus> PtnrPartnerStatusList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<PtnrPartnerStatus>
                        {
                            new PtnrPartnerStatus
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "",
								PartnerStatusKey = 0,
								IsActive = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
