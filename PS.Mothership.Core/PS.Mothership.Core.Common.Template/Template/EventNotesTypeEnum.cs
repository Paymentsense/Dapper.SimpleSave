using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Event
{
    
    [DataContract]
    public enum EventNotesTypeEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("System Generated")][EnumMember]SystemGenerated = 1,
       [Description("General")][EnumMember]General = 2,
        
    }    
    
    public class EventNotesType
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long NotesTypeKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class EventNotesTypeCollection
    {
        private static List<EventNotesType> _list; 
        public static List<EventNotesType> EventNotesTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<EventNotesType>
                        {
                            new EventNotesType
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								NotesTypeKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new EventNotesType
							{
								EnumValue = 1,
								EnumName = "SystemGenerated",
								EnumDescription = "System Generated",
								NotesTypeKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventNotesType
							{
								EnumValue = 2,
								EnumName = "General",
								EnumDescription = "General",
								NotesTypeKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
