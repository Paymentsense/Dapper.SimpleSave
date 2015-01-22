using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenQueueTypeEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Web Lead")][EnumMember]WebLead = 1,
        
    }    
    
    public class GenQueueType
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int QueueTypeKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class GenQueueTypeCollection
    {
        private static List<GenQueueType> _list; 
        public static List<GenQueueType> GenQueueTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<GenQueueType>
                        {
                            new GenQueueType
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								QueueTypeKey = 0,
								RecStatusKey = (GenRecStatusEnum)2
							},
							new GenQueueType
							{
								EnumValue = 1,
								EnumName = "WebLead",
								EnumDescription = "Web Lead",
								QueueTypeKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
