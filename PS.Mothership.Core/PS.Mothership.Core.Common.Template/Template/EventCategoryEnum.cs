using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Event
{
    
    [DataContract]
    public enum EventCategoryEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("General")][EnumMember]General = 1,
       [Description("Call")][EnumMember]Call = 2,
       [Description("Email")][EnumMember]Email = 3,
       [Description("Create Appointment")][EnumMember]CreateAppointment = 4,
       [Description("Application")][EnumMember]Application = 5,
       [Description("Opportunity")][EnumMember]Opportunity = 6,
       [Description("Touch")][EnumMember]Touch = 7,
       [Description("Dialler")][EnumMember]Dialler = 8,
       [Description("Callback")][EnumMember]Callback = 9,
       [Description("Call Resolution")][EnumMember]CallResolution = 13,
       [Description("Reminder")][EnumMember]Reminder = 10,
       [Description("System Generated")][EnumMember]SystemGenerated = 11,
       [Description("Note")][EnumMember]Note = 12,
        
    }    
    
    public class EventCategory
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int EventCategoryKey {get;set;}
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
							new EventCategory
							{
								EnumValue = 2,
								EnumName = "Call",
								EnumDescription = "Call",
								EventCategoryKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventCategory
							{
								EnumValue = 3,
								EnumName = "Email",
								EnumDescription = "Email",
								EventCategoryKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventCategory
							{
								EnumValue = 4,
								EnumName = "CreateAppointment",
								EnumDescription = "Create Appointment",
								EventCategoryKey = 4,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventCategory
							{
								EnumValue = 5,
								EnumName = "Application",
								EnumDescription = "Application",
								EventCategoryKey = 5,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventCategory
							{
								EnumValue = 6,
								EnumName = "Opportunity",
								EnumDescription = "Opportunity",
								EventCategoryKey = 6,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventCategory
							{
								EnumValue = 7,
								EnumName = "Touch",
								EnumDescription = "Touch",
								EventCategoryKey = 7,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventCategory
							{
								EnumValue = 8,
								EnumName = "Dialler",
								EnumDescription = "Dialler",
								EventCategoryKey = 8,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventCategory
							{
								EnumValue = 9,
								EnumName = "Callback",
								EnumDescription = "Callback",
								EventCategoryKey = 9,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventCategory
							{
								EnumValue = 13,
								EnumName = "CallResolution",
								EnumDescription = "Call Resolution",
								EventCategoryKey = 13,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventCategory
							{
								EnumValue = 10,
								EnumName = "Reminder",
								EnumDescription = "Reminder",
								EventCategoryKey = 10,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventCategory
							{
								EnumValue = 11,
								EnumName = "SystemGenerated",
								EnumDescription = "System Generated",
								EventCategoryKey = 11,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventCategory
							{
								EnumValue = 12,
								EnumName = "Note",
								EnumDescription = "Note",
								EventCategoryKey = 12,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
