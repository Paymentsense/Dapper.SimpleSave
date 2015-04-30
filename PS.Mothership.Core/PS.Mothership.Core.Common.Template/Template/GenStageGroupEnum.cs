using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenStageGroupEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Prospect")][EnumMember]Prospect = 1,
       [Description("Cold")][EnumMember]Cold = 2,
       [Description("Warm")][EnumMember]Warm = 3,
       [Description("Hot")][EnumMember]Hot = 4,
       [Description("Provisioning")][EnumMember]Provisioning = 5,
       [Description("Live")][EnumMember]Live = 6,
       [Description("Inactive")][EnumMember]Inactive = 7,
        
    }    
    
    public class GenStageGroup
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int StageGroupKey {get;set;}
		public string LowConvertRange {get;set;}
		public string HighConvertRange {get;set;}
		public string AvgNumOfDays {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class GenStageGroupCollection
    {
        private static List<GenStageGroup> _list; 
        public static List<GenStageGroup> GenStageGroupList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<GenStageGroup>
                        {
                            new GenStageGroup
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								StageGroupKey = 0,
								LowConvertRange = "0",
								HighConvertRange = "0",
								AvgNumOfDays = "0",
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenStageGroup
							{
								EnumValue = 1,
								EnumName = "Prospect",
								EnumDescription = "Prospect",
								StageGroupKey = 1,
								LowConvertRange = "0",
								HighConvertRange = "0",
								AvgNumOfDays = "0",
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenStageGroup
							{
								EnumValue = 2,
								EnumName = "Cold",
								EnumDescription = "Cold",
								StageGroupKey = 2,
								LowConvertRange = "0",
								HighConvertRange = "2",
								AvgNumOfDays = "8",
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenStageGroup
							{
								EnumValue = 3,
								EnumName = "Warm",
								EnumDescription = "Warm",
								StageGroupKey = 3,
								LowConvertRange = "2",
								HighConvertRange = "10",
								AvgNumOfDays = "20",
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenStageGroup
							{
								EnumValue = 4,
								EnumName = "Hot",
								EnumDescription = "Hot",
								StageGroupKey = 4,
								LowConvertRange = "21",
								HighConvertRange = "75",
								AvgNumOfDays = "20",
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenStageGroup
							{
								EnumValue = 5,
								EnumName = "Provisioning",
								EnumDescription = "Provisioning",
								StageGroupKey = 5,
								LowConvertRange = "76",
								HighConvertRange = "100",
								AvgNumOfDays = "15",
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenStageGroup
							{
								EnumValue = 6,
								EnumName = "Live",
								EnumDescription = "Live",
								StageGroupKey = 6,
								LowConvertRange = "100",
								HighConvertRange = "100",
								AvgNumOfDays = "0",
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenStageGroup
							{
								EnumValue = 7,
								EnumName = "Inactive",
								EnumDescription = "Inactive",
								StageGroupKey = 7,
								LowConvertRange = "0",
								HighConvertRange = "0",
								AvgNumOfDays = "0",
								RecStatusKey = (GenRecStatusEnum)0
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
