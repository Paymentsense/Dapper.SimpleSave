using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

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
		public RecStatusEnum RecStatusKey {get;set;}
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
								EnumDescription = "Unknown",
								RecStatusKey = (RecStatusEnum)0
							},
							new RecStatus
							{
								EnumValue = 1,
								EnumName = "ActiveShowInLists",
								EnumDescription = "Active - Show In Lists",
								RecStatusKey = (RecStatusEnum)1
							},
							new RecStatus
							{
								EnumValue = 2,
								EnumName = "ActiveDoNotShowInLists",
								EnumDescription = "Active - Do Not Show In Lists",
								RecStatusKey = (RecStatusEnum)2
							},
							new RecStatus
							{
								EnumValue = 3,
								EnumName = "InActive",
								EnumDescription = "In-Active",
								RecStatusKey = (RecStatusEnum)3
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
