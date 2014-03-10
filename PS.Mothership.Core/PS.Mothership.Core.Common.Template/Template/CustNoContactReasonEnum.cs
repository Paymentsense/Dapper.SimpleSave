using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Cust
{
    
    [DataContract]
    public enum NoContactReasonEnum : long
    {
       [Description("None")][EnumMember]None = 0,
        
    }

    public class NoContactReason
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long ReasonKey {get;set;}
		public bool IsForEmail {get;set;}
		public bool IsForPhone {get;set;}
		public RecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class NoContactReasonCollection
    {
        private static List<NoContactReason> _list; 
        public static List<NoContactReason> NoContactReasonList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<NoContactReason>
                        {
                            new NoContactReason
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								ReasonKey = 0,
								IsForEmail = false,
								IsForPhone = false,
								RecStatusKey = (RecStatusEnum)3
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
