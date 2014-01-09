using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Usr
{
    
    [DataContract]
    public enum IpStatusEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Active")][EnumMember]Active = 1,
       [Description("In Active")][EnumMember]InActive = 2,
       [Description("Deleted")][EnumMember]Deleted = 3,
        
    }

    public class IpStatus
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long IPStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class IpStatusCollection
    {
        private static List<IpStatus> _list; 
        public static List<IpStatus> IpStatusList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<IpStatus>
                        {
                            new IpStatus
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								IPStatusKey = 0
							},
							new IpStatus
							{
								EnumValue = 1,
								EnumName = "Active",
								EnumDescription = "Active",
								IPStatusKey = 1
							},
							new IpStatus
							{
								EnumValue = 2,
								EnumName = "InActive",
								EnumDescription = "In Active",
								IPStatusKey = 2
							},
							new IpStatus
							{
								EnumValue = 3,
								EnumName = "Deleted",
								EnumDescription = "Deleted",
								IPStatusKey = 3
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
