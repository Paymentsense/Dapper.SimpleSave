using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Cust
{
    
    [DataContract]
    public enum CustAnnualTurnoverEnum : long
    {
       [Description("None")][EnumMember]None = 0,
        
    }    
    
    public class CustAnnualTurnover
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long AnnualTurnoverKey {get;set;}
		public int TurnoverLow {get;set;}
		public int TurnoverHigh {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class CustAnnualTurnoverCollection
    {
        private static List<CustAnnualTurnover> _list; 
        public static List<CustAnnualTurnover> CustAnnualTurnoverList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<CustAnnualTurnover>
                        {
                            new CustAnnualTurnover
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								AnnualTurnoverKey = 0,
								TurnoverLow = 0,
								TurnoverHigh = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
