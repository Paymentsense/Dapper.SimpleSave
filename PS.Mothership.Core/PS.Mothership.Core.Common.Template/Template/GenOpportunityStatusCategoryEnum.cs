using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenOpportunityStatusCategoryEnum : int
    {
       [Description("None")][EnumMember]None = 0,
        
    }    
    
    public class GenOpportunityStatusCategory
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int OpportunityStatusCategoryKey {get;set;}
		public int OpportunityStatusGroupKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class GenOpportunityStatusCategoryCollection
    {
        private static List<GenOpportunityStatusCategory> _list; 
        public static List<GenOpportunityStatusCategory> GenOpportunityStatusCategoryList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<GenOpportunityStatusCategory>
                        {
                            new GenOpportunityStatusCategory
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								OpportunityStatusCategoryKey = 0,
								OpportunityStatusGroupKey = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
