using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Opp
{
    
    [DataContract]
    public enum OppProvisionTypeEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Not Required")][EnumMember]NotRequired = 1,
       [Description("Add New")][EnumMember]AddNew = 2,
       [Description("Transfer Existing")][EnumMember]TransferExisting = 3,
        
    }    
    
    public class OppProvisionType
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int ProvisionTypeKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class OppProvisionTypeCollection
    {
        private static List<OppProvisionType> _list; 
        public static List<OppProvisionType> OppProvisionTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<OppProvisionType>
                        {
                            new OppProvisionType
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								ProvisionTypeKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new OppProvisionType
							{
								EnumValue = 1,
								EnumName = "NotRequired",
								EnumDescription = "Not Required",
								ProvisionTypeKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new OppProvisionType
							{
								EnumValue = 2,
								EnumName = "AddNew",
								EnumDescription = "Add New",
								ProvisionTypeKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new OppProvisionType
							{
								EnumValue = 3,
								EnumName = "TransferExisting",
								EnumDescription = "Transfer Existing",
								ProvisionTypeKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
