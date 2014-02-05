using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum RecStatusEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Active")][EnumMember]Active = 1,
       [Description("")][EnumMember]InActive = 2,
       [Description("")][EnumMember]Deleted = 3,
        
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
								EnumName = "None",
								EnumDescription = "None"
							},
							new RecStatus
							{
								EnumValue = 1,
								EnumName = "Active",
								EnumDescription = "Active"
							},
							new RecStatus
							{
								EnumValue = 2,
								EnumName = "InActive",
								EnumDescription = ""
							},
							new RecStatus
							{
								EnumValue = 3,
								EnumName = "Deleted",
								EnumDescription = ""
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
