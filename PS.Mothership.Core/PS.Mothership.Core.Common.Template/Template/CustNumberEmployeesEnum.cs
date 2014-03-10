using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Cust
{
    
    [DataContract]
    public enum NumberEmployeesEnum : long
    {
       [Description("None")][EnumMember]None = 0,
        
    }

    public class NumberEmployees
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long NumberEmployeesKey {get;set;}
		public int RangeLow {get;set;}
		public int RangeHigh {get;set;}
		public RecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class NumberEmployeesCollection
    {
        private static List<NumberEmployees> _list; 
        public static List<NumberEmployees> NumberEmployeesList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<NumberEmployees>
                        {
                            new NumberEmployees
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								NumberEmployeesKey = 0,
								RangeLow = 0,
								RangeHigh = 0,
								RecStatusKey = (RecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
