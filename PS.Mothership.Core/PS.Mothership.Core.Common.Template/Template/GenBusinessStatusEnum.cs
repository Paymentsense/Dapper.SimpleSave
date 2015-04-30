using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenBusinessStatusEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Live")][EnumMember]Live = 1,
       [Description("Dissolved")][EnumMember]Dissolved = 2,
        
    }    
    
    public class GenBusinessStatus
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int BusinessStatusKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class GenBusinessStatusCollection
    {
        private static List<GenBusinessStatus> _list; 
        public static List<GenBusinessStatus> GenBusinessStatusList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<GenBusinessStatus>
                        {
                            new GenBusinessStatus
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								BusinessStatusKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenBusinessStatus
							{
								EnumValue = 1,
								EnumName = "Live",
								EnumDescription = "Live",
								BusinessStatusKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenBusinessStatus
							{
								EnumValue = 2,
								EnumName = "Dissolved",
								EnumDescription = "Dissolved",
								BusinessStatusKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
