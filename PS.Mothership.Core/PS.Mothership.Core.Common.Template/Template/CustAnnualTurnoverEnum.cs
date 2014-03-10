using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Cust
{
    
    [DataContract]
    public enum AnnualTurnoverEnum : long
    {
       [Description("None")][EnumMember]None = 0,
        
    }

    public class AnnualTurnover
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long AnnualTurnoverKey {get;set;}
		public int TurnoverLow {get;set;}
		public int TurnoverHigh {get;set;}
		public RecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class AnnualTurnoverCollection
    {
        private static List<AnnualTurnover> _list; 
        public static List<AnnualTurnover> AnnualTurnoverList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<AnnualTurnover>
                        {
                            new AnnualTurnover
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								AnnualTurnoverKey = 0,
								TurnoverLow = 0,
								TurnoverHigh = 0,
								RecStatusKey = (RecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
