using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Opp
{
    
    [DataContract]
    public enum OppTypeOfTransactionsEnum : long
    {
       [Description("None")][EnumMember]None = 0,
        
    }    
    
    public class OppTypeOfTransactions
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long TypeOfTranxKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class OppTypeOfTransactionsCollection
    {
        private static List<OppTypeOfTransactions> _list; 
        public static List<OppTypeOfTransactions> OppTypeOfTransactionsList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<OppTypeOfTransactions>
                        {
                            new OppTypeOfTransactions
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								TypeOfTranxKey = 0,
								RecStatusKey = (GenRecStatusEnum)2
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
