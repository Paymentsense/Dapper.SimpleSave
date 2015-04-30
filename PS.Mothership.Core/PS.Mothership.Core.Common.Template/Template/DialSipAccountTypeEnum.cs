using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Dial
{
    
    [DataContract]
    public enum DialSipAccountTypeEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Normal")][EnumMember]Normal = 1,
       [Description("Service Agent")][EnumMember]ServiceAgent = 2,
       [Description("Queue")][EnumMember]Queue = 3,
        
    }    
    
    public class DialSipAccountType
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int SipAccountTypeKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class DialSipAccountTypeCollection
    {
        private static List<DialSipAccountType> _list; 
        public static List<DialSipAccountType> DialSipAccountTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<DialSipAccountType>
                        {
                            new DialSipAccountType
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								SipAccountTypeKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new DialSipAccountType
							{
								EnumValue = 1,
								EnumName = "Normal",
								EnumDescription = "Normal",
								SipAccountTypeKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialSipAccountType
							{
								EnumValue = 2,
								EnumName = "ServiceAgent",
								EnumDescription = "Service Agent",
								SipAccountTypeKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialSipAccountType
							{
								EnumValue = 3,
								EnumName = "Queue",
								EnumDescription = "Queue",
								SipAccountTypeKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
