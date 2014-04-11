using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Comm
{
    
    [DataContract]
    public enum CommMessageTypeEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("SMS")][EnumMember]SMS = 1,
       [Description("Email")][EnumMember]Email = 2,
        
    }    
    
    public class CommMessageType
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long MessageTypeKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class CommMessageTypeCollection
    {
        private static List<CommMessageType> _list; 
        public static List<CommMessageType> CommMessageTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<CommMessageType>
                        {
                            new CommMessageType
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								MessageTypeKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new CommMessageType
							{
								EnumValue = 1,
								EnumName = "SMS",
								EnumDescription = "SMS",
								MessageTypeKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new CommMessageType
							{
								EnumValue = 2,
								EnumName = "Email",
								EnumDescription = "Email",
								MessageTypeKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
