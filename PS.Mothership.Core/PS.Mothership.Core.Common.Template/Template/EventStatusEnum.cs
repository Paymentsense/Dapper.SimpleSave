using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Event
{
    
    [DataContract]
    public enum StatusEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Open")][EnumMember]Open = 1,
       [Description("Closed")][EnumMember]Closed = 2,
       [Description("Cancelled")][EnumMember]Cancelled = 3,
       [Description("Re-Scheduled")][EnumMember]ReScheduled = 4,
       [Description("Assigned")][EnumMember]Assigned = 5,
        
    }

    public class Status
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long EventStatusKey {get;set;}
		public bool IsClosed {get;set;}
		public RecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class StatusCollection
    {
        private static List<Status> _list; 
        public static List<Status> StatusList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<Status>
                        {
                            new Status
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								EventStatusKey = 0,
								IsClosed = false,
								RecStatusKey = (RecStatusEnum)0
							},
							new Status
							{
								EnumValue = 1,
								EnumName = "Open",
								EnumDescription = "Open",
								EventStatusKey = 1,
								IsClosed = false,
								RecStatusKey = (RecStatusEnum)1
							},
							new Status
							{
								EnumValue = 2,
								EnumName = "Closed",
								EnumDescription = "Closed",
								EventStatusKey = 2,
								IsClosed = true,
								RecStatusKey = (RecStatusEnum)1
							},
							new Status
							{
								EnumValue = 3,
								EnumName = "Cancelled",
								EnumDescription = "Cancelled",
								EventStatusKey = 3,
								IsClosed = true,
								RecStatusKey = (RecStatusEnum)1
							},
							new Status
							{
								EnumValue = 4,
								EnumName = "ReScheduled",
								EnumDescription = "Re-Scheduled",
								EventStatusKey = 4,
								IsClosed = false,
								RecStatusKey = (RecStatusEnum)1
							},
							new Status
							{
								EnumValue = 5,
								EnumName = "Assigned",
								EnumDescription = "Assigned",
								EventStatusKey = 5,
								IsClosed = false,
								RecStatusKey = (RecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
