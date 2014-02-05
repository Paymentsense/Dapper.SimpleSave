using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Comm
{
    
    [DataContract]
    public enum MessageServiceStatusEnum : long
    {
       [Description("")][EnumMember]Normal = 1,
       [Description("")][EnumMember]Unstable = 2,
       [Description("")][EnumMember]Errored = 3,
        
    }

    public class MessageServiceStatus
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long ServiceStatusKey {get;set;}
		public bool IsUseable {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class MessageServiceStatusCollection
    {
        private static List<MessageServiceStatus> _list; 
        public static List<MessageServiceStatus> MessageServiceStatusList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<MessageServiceStatus>
                        {
                            new MessageServiceStatus
							{
								EnumValue = 1,
								EnumName = "Normal",
								EnumDescription = "",
								ServiceStatusKey = 1,
								IsUseable = true
							},
							new MessageServiceStatus
							{
								EnumValue = 2,
								EnumName = "Unstable",
								EnumDescription = "",
								ServiceStatusKey = 2,
								IsUseable = true
							},
							new MessageServiceStatus
							{
								EnumValue = 3,
								EnumName = "Errored",
								EnumDescription = "",
								ServiceStatusKey = 3,
								IsUseable = true
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
