using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Dial
{
    
    [DataContract]
    public enum SipAccountTypeEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Normal")][EnumMember]Normal = 1,
       [Description("Service Agent")][EnumMember]ServiceAgent = 2,
       [Description("Queue")][EnumMember]Queue = 3,
        
    }

    public class SipAccountType
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long SipAccountTypeKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class SipAccountTypeCollection
    {
        private static List<SipAccountType> _list; 
        public static List<SipAccountType> SipAccountTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<SipAccountType>
                        {
                            new SipAccountType
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								SipAccountTypeKey = 0
							},
							new SipAccountType
							{
								EnumValue = 1,
								EnumName = "Normal",
								EnumDescription = "Normal",
								SipAccountTypeKey = 1
							},
							new SipAccountType
							{
								EnumValue = 2,
								EnumName = "ServiceAgent",
								EnumDescription = "Service Agent",
								SipAccountTypeKey = 2
							},
							new SipAccountType
							{
								EnumValue = 3,
								EnumName = "Queue",
								EnumDescription = "Queue",
								SipAccountTypeKey = 3
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
