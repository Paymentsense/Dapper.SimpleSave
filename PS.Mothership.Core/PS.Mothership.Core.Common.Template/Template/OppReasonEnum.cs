using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Opp
{
    
    [DataContract]
    public enum OppReasonEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Timed Out")][EnumMember]TimeOut = 1,
        
    }    
    
    public class OppReason
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int ReasonKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class OppReasonCollection
    {
        private static List<OppReason> _list; 
        public static List<OppReason> OppReasonList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<OppReason>
                        {
                            new OppReason
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								ReasonKey = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new OppReason
							{
								EnumValue = 1,
								EnumName = "TimeOut",
								EnumDescription = "Timed Out",
								ReasonKey = 1,
								RecStatusKey = (GenRecStatusEnum)2
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
