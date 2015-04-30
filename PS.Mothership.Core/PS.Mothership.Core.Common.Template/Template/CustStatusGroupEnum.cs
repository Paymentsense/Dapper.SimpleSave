using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Cust
{
    
    [DataContract]
    public enum CustStatusGroupEnum : int
    {
       [Description("None")][EnumMember]None = 0,
        
    }    
    
    public class CustStatusGroup
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int CustStatusGroupKey {get;set;}
		public int SortOrder {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class CustStatusGroupCollection
    {
        private static List<CustStatusGroup> _list; 
        public static List<CustStatusGroup> CustStatusGroupList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<CustStatusGroup>
                        {
                            new CustStatusGroup
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								CustStatusGroupKey = 0,
								SortOrder = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
