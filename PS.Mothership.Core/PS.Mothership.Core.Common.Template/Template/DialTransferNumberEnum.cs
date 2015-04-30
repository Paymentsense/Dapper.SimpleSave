using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Dial
{
    
    [DataContract]
    public enum DialTransferNumberEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Capital On Tap")][EnumMember]CapitalOnTap = 1,
       [Description("Judo")][EnumMember]Judo = 2,
       [Description("IT Support")][EnumMember]ITSupport = 3,
       [Description("ECOM Support")][EnumMember]EcomSupport = 4,
       [Description("Sales Support")][EnumMember]SalesSupport = 5,
       [Description("Customer Service")][EnumMember]CustomerService = 6,
        
    }    
    
    public class DialTransferNumber
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int TransferNumberEnumKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class DialTransferNumberCollection
    {
        private static List<DialTransferNumber> _list; 
        public static List<DialTransferNumber> DialTransferNumberList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<DialTransferNumber>
                        {
                            new DialTransferNumber
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								TransferNumberEnumKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new DialTransferNumber
							{
								EnumValue = 1,
								EnumName = "CapitalOnTap",
								EnumDescription = "Capital On Tap",
								TransferNumberEnumKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialTransferNumber
							{
								EnumValue = 2,
								EnumName = "Judo",
								EnumDescription = "Judo",
								TransferNumberEnumKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialTransferNumber
							{
								EnumValue = 3,
								EnumName = "ITSupport",
								EnumDescription = "IT Support",
								TransferNumberEnumKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialTransferNumber
							{
								EnumValue = 4,
								EnumName = "EcomSupport",
								EnumDescription = "ECOM Support",
								TransferNumberEnumKey = 4,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialTransferNumber
							{
								EnumValue = 5,
								EnumName = "SalesSupport",
								EnumDescription = "Sales Support",
								TransferNumberEnumKey = 5,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialTransferNumber
							{
								EnumValue = 6,
								EnumName = "CustomerService",
								EnumDescription = "Customer Service",
								TransferNumberEnumKey = 6,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
