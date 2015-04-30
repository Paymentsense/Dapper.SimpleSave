using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Comm
{
    
    [DataContract]
    public enum CommMessageServiceStatusEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Normal")][EnumMember]Normal = 1,
       [Description("Unstable")][EnumMember]Unstable = 2,
       [Description("Errored")][EnumMember]Errored = 3,
        
    }    
    
    public class CommMessageServiceStatus
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int ServiceStatusKey {get;set;}
		public bool IsUseable {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class CommMessageServiceStatusCollection
    {
        private static List<CommMessageServiceStatus> _list; 
        public static List<CommMessageServiceStatus> CommMessageServiceStatusList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<CommMessageServiceStatus>
                        {
                            new CommMessageServiceStatus
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								ServiceStatusKey = 0,
								IsUseable = false,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new CommMessageServiceStatus
							{
								EnumValue = 1,
								EnumName = "Normal",
								EnumDescription = "Normal",
								ServiceStatusKey = 1,
								IsUseable = true,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new CommMessageServiceStatus
							{
								EnumValue = 2,
								EnumName = "Unstable",
								EnumDescription = "Unstable",
								ServiceStatusKey = 2,
								IsUseable = true,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new CommMessageServiceStatus
							{
								EnumValue = 3,
								EnumName = "Errored",
								EnumDescription = "Errored",
								ServiceStatusKey = 3,
								IsUseable = true,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
