using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Cust
{
    
    [DataContract]
    public enum CustStatusEnum : int
    {
       [Description("None")][EnumMember]None = 0,
        
    }    
    
    public class CustStatus
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int CustomerStatusKey {get;set;}
		public int CustStatusGroupKey {get;set;}
		public bool IsArchived {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class CustStatusCollection
    {
        private static List<CustStatus> _list; 
        public static List<CustStatus> CustStatusList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<CustStatus>
                        {
                            new CustStatus
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								CustomerStatusKey = 0,
								CustStatusGroupKey = 0,
								IsArchived = false,
								RecStatusKey = (GenRecStatusEnum)0
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
