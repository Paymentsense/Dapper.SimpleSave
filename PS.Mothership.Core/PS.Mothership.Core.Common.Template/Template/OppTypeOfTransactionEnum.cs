using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Opp
{
    
    [DataContract]
    public enum OppTypeOfTransactionEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("F2F")][EnumMember]F2F = 1,
       [Description("ECOM")][EnumMember]ECOM = 2,
       [Description("MOTO")][EnumMember]MOTO = 3,
       [Description("EPOS")][EnumMember]EPOS = 4,
       [Description("PSConnect (Terminal)")][EnumMember]PSConnectTerminal = 5,
       [Description("PSConnect (Ecom)")][EnumMember]PSConnectEcom = 6,
       [Description("VAR (YesPay)")][EnumMember]VARYesPay = 7,
        
    }    
    
    public class OppTypeOfTransaction
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int TypeOfTransactionKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class OppTypeOfTransactionCollection
    {
        private static List<OppTypeOfTransaction> _list; 
        public static List<OppTypeOfTransaction> OppTypeOfTransactionList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<OppTypeOfTransaction>
                        {
                            new OppTypeOfTransaction
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								TypeOfTransactionKey = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new OppTypeOfTransaction
							{
								EnumValue = 1,
								EnumName = "F2F",
								EnumDescription = "F2F",
								TypeOfTransactionKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new OppTypeOfTransaction
							{
								EnumValue = 2,
								EnumName = "ECOM",
								EnumDescription = "ECOM",
								TypeOfTransactionKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new OppTypeOfTransaction
							{
								EnumValue = 3,
								EnumName = "MOTO",
								EnumDescription = "MOTO",
								TypeOfTransactionKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new OppTypeOfTransaction
							{
								EnumValue = 4,
								EnumName = "EPOS",
								EnumDescription = "EPOS",
								TypeOfTransactionKey = 4,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new OppTypeOfTransaction
							{
								EnumValue = 5,
								EnumName = "PSConnectTerminal",
								EnumDescription = "PSConnect (Terminal)",
								TypeOfTransactionKey = 5,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new OppTypeOfTransaction
							{
								EnumValue = 6,
								EnumName = "PSConnectEcom",
								EnumDescription = "PSConnect (Ecom)",
								TypeOfTransactionKey = 6,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new OppTypeOfTransaction
							{
								EnumValue = 7,
								EnumName = "VARYesPay",
								EnumDescription = "VAR (YesPay)",
								TypeOfTransactionKey = 7,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
