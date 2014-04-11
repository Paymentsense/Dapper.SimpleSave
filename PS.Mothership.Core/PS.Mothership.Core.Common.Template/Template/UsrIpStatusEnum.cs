using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Usr
{
    
    [DataContract]
    public enum UsrIpStatusEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Active")][EnumMember]Active = 1,
       [Description("In Active")][EnumMember]InActive = 2,
       [Description("Deleted")][EnumMember]Deleted = 3,
        
    }    
    
    public class UsrIpStatus
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long IPStatusKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class UsrIpStatusCollection
    {
        private static List<UsrIpStatus> _list; 
        public static List<UsrIpStatus> UsrIpStatusList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<UsrIpStatus>
                        {
                            new UsrIpStatus
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								IPStatusKey = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrIpStatus
							{
								EnumValue = 1,
								EnumName = "Active",
								EnumDescription = "Active",
								IPStatusKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrIpStatus
							{
								EnumValue = 2,
								EnumName = "InActive",
								EnumDescription = "In Active",
								IPStatusKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrIpStatus
							{
								EnumValue = 3,
								EnumName = "Deleted",
								EnumDescription = "Deleted",
								IPStatusKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
