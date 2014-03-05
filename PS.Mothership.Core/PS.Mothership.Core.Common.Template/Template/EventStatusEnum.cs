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
       [Description("")][EnumMember]Blank = 0,
       [Description("")][EnumMember]Sent = 1,
       [Description("")][EnumMember]Delivered = 2,
       [Description("")][EnumMember]Bounced = 3,
       [Description("")][EnumMember]Recieved = 4,
       [Description("")][EnumMember]Failed = 5,
        
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
								EnumName = "Blank",
								EnumDescription = "",
								EventStatusKey = 0,
								IsClosed = false,
								RecStatusKey = (RecStatusEnum)1
							},
							new Status
							{
								EnumValue = 1,
								EnumName = "Sent",
								EnumDescription = "",
								EventStatusKey = 1,
								IsClosed = false,
								RecStatusKey = (RecStatusEnum)2
							},
							new Status
							{
								EnumValue = 2,
								EnumName = "Delivered",
								EnumDescription = "",
								EventStatusKey = 2,
								IsClosed = false,
								RecStatusKey = (RecStatusEnum)2
							},
							new Status
							{
								EnumValue = 3,
								EnumName = "Bounced",
								EnumDescription = "",
								EventStatusKey = 3,
								IsClosed = false,
								RecStatusKey = (RecStatusEnum)2
							},
							new Status
							{
								EnumValue = 4,
								EnumName = "Recieved",
								EnumDescription = "",
								EventStatusKey = 4,
								IsClosed = false,
								RecStatusKey = (RecStatusEnum)2
							},
							new Status
							{
								EnumValue = 5,
								EnumName = "Failed",
								EnumDescription = "",
								EventStatusKey = 5,
								IsClosed = false,
								RecStatusKey = (RecStatusEnum)2
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
