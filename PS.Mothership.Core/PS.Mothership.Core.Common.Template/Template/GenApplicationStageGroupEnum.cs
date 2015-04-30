using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenApplicationStageGroupEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Pre-Out")][EnumMember]PreOut = 1,
       [Description("Error")][EnumMember]Error = 2,
       [Description("Docs Out")][EnumMember]DocsOut = 3,
       [Description("Provisioning")][EnumMember]Provisioning = 4,
       [Description("Submit")][EnumMember]Submit = 5,
       [Description("At Bank")][EnumMember]AtBank = 6,
       [Description("In Credit")][EnumMember]InCredit = 7,
       [Description("Approved")][EnumMember]Approved = 8,
       [Description("Live")][EnumMember]Live = 9,
       [Description("Dead")][EnumMember]Dead = 10,
        
    }    
    
    public class GenApplicationStageGroup
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int ApplicationStageGroupKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class GenApplicationStageGroupCollection
    {
        private static List<GenApplicationStageGroup> _list; 
        public static List<GenApplicationStageGroup> GenApplicationStageGroupList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<GenApplicationStageGroup>
                        {
                            new GenApplicationStageGroup
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								ApplicationStageGroupKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageGroup
							{
								EnumValue = 1,
								EnumName = "PreOut",
								EnumDescription = "Pre-Out",
								ApplicationStageGroupKey = 1,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageGroup
							{
								EnumValue = 2,
								EnumName = "Error",
								EnumDescription = "Error",
								ApplicationStageGroupKey = 2,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageGroup
							{
								EnumValue = 3,
								EnumName = "DocsOut",
								EnumDescription = "Docs Out",
								ApplicationStageGroupKey = 3,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageGroup
							{
								EnumValue = 4,
								EnumName = "Provisioning",
								EnumDescription = "Provisioning",
								ApplicationStageGroupKey = 4,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageGroup
							{
								EnumValue = 5,
								EnumName = "Submit",
								EnumDescription = "Submit",
								ApplicationStageGroupKey = 5,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageGroup
							{
								EnumValue = 6,
								EnumName = "AtBank",
								EnumDescription = "At Bank",
								ApplicationStageGroupKey = 6,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageGroup
							{
								EnumValue = 7,
								EnumName = "InCredit",
								EnumDescription = "In Credit",
								ApplicationStageGroupKey = 7,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageGroup
							{
								EnumValue = 8,
								EnumName = "Approved",
								EnumDescription = "Approved",
								ApplicationStageGroupKey = 8,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageGroup
							{
								EnumValue = 9,
								EnumName = "Live",
								EnumDescription = "Live",
								ApplicationStageGroupKey = 9,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenApplicationStageGroup
							{
								EnumValue = 10,
								EnumName = "Dead",
								EnumDescription = "Dead",
								ApplicationStageGroupKey = 10,
								RecStatusKey = (GenRecStatusEnum)0
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
