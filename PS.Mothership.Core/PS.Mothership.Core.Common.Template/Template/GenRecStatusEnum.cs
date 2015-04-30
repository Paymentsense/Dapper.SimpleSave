using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenRecStatusEnum : int
    {
       [Description("Unknown")][EnumMember]Unknown = 0,
       [Description("Active - Show In Lists")][EnumMember]ActiveShowInLists = 1,
       [Description("Active - Do Not Show In Lists")][EnumMember]ActiveDoNotShowInLists = 2,
       [Description("In-Active")][EnumMember]InActive = 3,
        
    }    
    
    public class GenRecStatus
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class GenRecStatusCollection
    {
        private static List<GenRecStatus> _list; 
        public static List<GenRecStatus> GenRecStatusList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<GenRecStatus>
                        {
                            new GenRecStatus
							{
								EnumValue = 0,
								EnumName = "Unknown",
								EnumDescription = "Unknown",
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenRecStatus
							{
								EnumValue = 1,
								EnumName = "ActiveShowInLists",
								EnumDescription = "Active - Show In Lists",
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenRecStatus
							{
								EnumValue = 2,
								EnumName = "ActiveDoNotShowInLists",
								EnumDescription = "Active - Do Not Show In Lists",
								RecStatusKey = (GenRecStatusEnum)2
							},
							new GenRecStatus
							{
								EnumValue = 3,
								EnumName = "InActive",
								EnumDescription = "In-Active",
								RecStatusKey = (GenRecStatusEnum)3
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
