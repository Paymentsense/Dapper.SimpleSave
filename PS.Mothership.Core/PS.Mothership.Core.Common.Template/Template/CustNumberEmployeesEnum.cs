using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Cust
{
    
    [DataContract]
    public enum CustNumberEmployeesEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("1to5")][EnumMember]From1to5 = 1,
       [Description("6to10")][EnumMember]From6to10 = 2,
       [Description("11to25")][EnumMember]From11to25 = 3,
       [Description("26to50")][EnumMember]From26to50 = 4,
       [Description("51to100")][EnumMember]From51to100 = 5,
       [Description("101to500")][EnumMember]From101to500 = 6,
       [Description("501to1000")][EnumMember]From501to1000 = 7,
       [Description("Over1000")][EnumMember]Over1000 = 8,
        
    }    
    
    public class CustNumberEmployees
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int NumberEmployeesKey {get;set;}
		public int RangeLow {get;set;}
		public int RangeHigh {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class CustNumberEmployeesCollection
    {
        private static List<CustNumberEmployees> _list; 
        public static List<CustNumberEmployees> CustNumberEmployeesList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<CustNumberEmployees>
                        {
                            new CustNumberEmployees
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								NumberEmployeesKey = 0,
								RangeLow = 0,
								RangeHigh = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new CustNumberEmployees
							{
								EnumValue = 1,
								EnumName = "From1to5",
								EnumDescription = "1to5",
								NumberEmployeesKey = 1,
								RangeLow = 1,
								RangeHigh = 5,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new CustNumberEmployees
							{
								EnumValue = 2,
								EnumName = "From6to10",
								EnumDescription = "6to10",
								NumberEmployeesKey = 2,
								RangeLow = 6,
								RangeHigh = 10,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new CustNumberEmployees
							{
								EnumValue = 3,
								EnumName = "From11to25",
								EnumDescription = "11to25",
								NumberEmployeesKey = 3,
								RangeLow = 11,
								RangeHigh = 25,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new CustNumberEmployees
							{
								EnumValue = 4,
								EnumName = "From26to50",
								EnumDescription = "26to50",
								NumberEmployeesKey = 4,
								RangeLow = 26,
								RangeHigh = 50,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new CustNumberEmployees
							{
								EnumValue = 5,
								EnumName = "From51to100",
								EnumDescription = "51to100",
								NumberEmployeesKey = 5,
								RangeLow = 51,
								RangeHigh = 100,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new CustNumberEmployees
							{
								EnumValue = 6,
								EnumName = "From101to500",
								EnumDescription = "101to500",
								NumberEmployeesKey = 6,
								RangeLow = 101,
								RangeHigh = 500,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new CustNumberEmployees
							{
								EnumValue = 7,
								EnumName = "From501to1000",
								EnumDescription = "501to1000",
								NumberEmployeesKey = 7,
								RangeLow = 501,
								RangeHigh = 1000,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new CustNumberEmployees
							{
								EnumValue = 8,
								EnumName = "Over1000",
								EnumDescription = "Over1000",
								NumberEmployeesKey = 8,
								RangeLow = 1001,
								RangeHigh = 999999999,
								RecStatusKey = (GenRecStatusEnum)0
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
