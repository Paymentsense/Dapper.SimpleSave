using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Opp
{
    
    [DataContract]
    public enum OppStatusEnum : long
    {
       [Description("None")][EnumMember]None = 0,
        
    }    
    
    public class OppStatus
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long OpportunityStatusKey {get;set;}
		public bool IsActive {get;set;}
		public int WobblyHours {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class OppStatusCollection
    {
        private static List<OppStatus> _list; 
        public static List<OppStatus> OppStatusList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<OppStatus>
                        {
                            new OppStatus
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								OpportunityStatusKey = 0,
								IsActive = false,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)2
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
