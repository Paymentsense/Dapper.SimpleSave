using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Comm
{
    
    [DataContract]
    public enum CommMessageStatusEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Scheduled")][EnumMember]Scheduled = 1,
       [Description("Successful")][EnumMember]Successful = 2,
       [Description("Failed")][EnumMember]Failed = 3,
        
    }    
    
    public class CommMessageStatus
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long MessageStatusKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class CommMessageStatusCollection
    {
        private static List<CommMessageStatus> _list; 
        public static List<CommMessageStatus> CommMessageStatusList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<CommMessageStatus>
                        {
                            new CommMessageStatus
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								MessageStatusKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new CommMessageStatus
							{
								EnumValue = 1,
								EnumName = "Scheduled",
								EnumDescription = "Scheduled",
								MessageStatusKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new CommMessageStatus
							{
								EnumValue = 2,
								EnumName = "Successful",
								EnumDescription = "Successful",
								MessageStatusKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new CommMessageStatus
							{
								EnumValue = 3,
								EnumName = "Failed",
								EnumDescription = "Failed",
								MessageStatusKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
