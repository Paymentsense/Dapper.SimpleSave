using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum RecStatusEnum : int
    {
       [Description("Unknown")][EnumMember]Unknown = 0,
       [Description("Active - Show In Lists")][EnumMember]ActiveShowInLists = 1,
       [Description("Active - Do Not Show In Lists")][EnumMember]ActiveDoNotShowInLists = 2,
       [Description("In-Active")][EnumMember]InActive = 3,
        
    }

    public class RecStatus
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class RecStatusCollection
    {
        private static List<RecStatus> _list; 
        public static List<RecStatus> RecStatusList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<RecStatus>
                        {
                            new RecStatus
							{
								EnumValue = 0,
								EnumName = "Unknown",
								EnumDescription = "Unknown"
							},
							new RecStatus
							{
								EnumValue = 1,
								EnumName = "ActiveShowInLists",
								EnumDescription = "Active - Show In Lists"
							},
							new RecStatus
							{
								EnumValue = 2,
								EnumName = "ActiveDoNotShowInLists",
								EnumDescription = "Active - Do Not Show In Lists"
							},
							new RecStatus
							{
								EnumValue = 3,
								EnumName = "InActive",
								EnumDescription = "In-Active"
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
