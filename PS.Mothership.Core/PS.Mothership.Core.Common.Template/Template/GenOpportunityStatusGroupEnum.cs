using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenOpportunityStatusGroupEnum : int
    {
       [Description("None")][EnumMember]None = 0,
        
    }    
    
    public class GenOpportunityStatusGroup
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int OpportunityStatusGroupKey {get;set;}
		public string LowConvertRange {get;set;}
		public string HighConvertRange {get;set;}
		public string AvgNumOfDays {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class GenOpportunityStatusGroupCollection
    {
        private static List<GenOpportunityStatusGroup> _list; 
        public static List<GenOpportunityStatusGroup> GenOpportunityStatusGroupList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<GenOpportunityStatusGroup>
                        {
                            new GenOpportunityStatusGroup
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								OpportunityStatusGroupKey = 0,
								LowConvertRange = "0",
								HighConvertRange = "0",
								AvgNumOfDays = "0",
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
