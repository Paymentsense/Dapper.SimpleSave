using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Cust
{
    
    [DataContract]
    public enum StatusGroupEnum : long
    {
       [Description("None")][EnumMember]None = 0,
        
    }

    public class StatusGroup
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long CustStatusGroupKey {get;set;}
		public int SortOrder {get;set;}
		public RecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class StatusGroupCollection
    {
        private static List<StatusGroup> _list; 
        public static List<StatusGroup> StatusGroupList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<StatusGroup>
                        {
                            new StatusGroup
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								CustStatusGroupKey = 0,
								SortOrder = 0,
								RecStatusKey = (RecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
