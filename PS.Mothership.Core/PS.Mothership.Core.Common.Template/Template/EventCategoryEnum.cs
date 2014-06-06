using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Event
{
    
    [DataContract]
    public enum EventCategoryEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("General")][EnumMember]General = 1,
        
    }    
    
    public class EventCategory
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long EventCategoryKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class EventCategoryCollection
    {
        private static List<EventCategory> _list; 
        public static List<EventCategory> EventCategoryList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<EventCategory>
                        {
                            new EventCategory
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								EventCategoryKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new EventCategory
							{
								EnumValue = 1,
								EnumName = "General",
								EnumDescription = "General",
								EventCategoryKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
