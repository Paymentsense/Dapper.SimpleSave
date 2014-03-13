using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Event
{
    
    [DataContract]
    public enum NotesTypeEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("System Generated")][EnumMember]SystemGenerated = 1,
       [Description("General")][EnumMember]General = 2,
        
    }

    public class NotesType
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long NotesTypeKey {get;set;}
		public RecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class NotesTypeCollection
    {
        private static List<NotesType> _list; 
        public static List<NotesType> NotesTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<NotesType>
                        {
                            new NotesType
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								NotesTypeKey = 0,
								RecStatusKey = (RecStatusEnum)0
							},
							new NotesType
							{
								EnumValue = 1,
								EnumName = "SystemGenerated",
								EnumDescription = "System Generated",
								NotesTypeKey = 1,
								RecStatusKey = (RecStatusEnum)1
							},
							new NotesType
							{
								EnumValue = 2,
								EnumName = "General",
								EnumDescription = "General",
								NotesTypeKey = 2,
								RecStatusKey = (RecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
