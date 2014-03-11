using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Cust
{
    
    [DataContract]
    public enum CustNoContactReasonEnum : long
    {
       [Description("None")][EnumMember]None = 0,
        
    }    
    
    public class CustNoContactReason
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long ReasonKey {get;set;}
		public bool IsForEmail {get;set;}
		public bool IsForPhone {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class CustNoContactReasonCollection
    {
        private static List<CustNoContactReason> _list; 
        public static List<CustNoContactReason> CustNoContactReasonList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<CustNoContactReason>
                        {
                            new CustNoContactReason
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								ReasonKey = 0,
								IsForEmail = false,
								IsForPhone = false,
								RecStatusKey = (GenRecStatusEnum)0
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
