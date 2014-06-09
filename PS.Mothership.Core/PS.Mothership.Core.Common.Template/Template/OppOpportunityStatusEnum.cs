using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Opp
{
    
    [DataContract]
    public enum OppOpportunityStatusEnum : long
    {
       [Description("None")][EnumMember]None = 0,
        
    }    
    
    public class OppOpportunityStatus
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long OpportunityStatusKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class OppOpportunityStatusCollection
    {
        private static List<OppOpportunityStatus> _list; 
        public static List<OppOpportunityStatus> OppOpportunityStatusList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<OppOpportunityStatus>
                        {
                            new OppOpportunityStatus
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								OpportunityStatusKey = 0,
								RecStatusKey = (GenRecStatusEnum)2
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
