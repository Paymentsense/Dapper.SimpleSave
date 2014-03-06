using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GuidLinkTypeEnum : long
    {
       [Description("")][EnumMember]Undefined = 0,
       [Description("")][EnumMember]Prospect = 1,
       [Description("")][EnumMember]Customer = 2,
       [Description("")][EnumMember]ServiceCall = 3,
       [Description("")][EnumMember]Application = 4,
       [Description("")][EnumMember]RellaidCall = 5,
       [Description("")][EnumMember]Role = 6,
        
    }

    public class GuidLinkType
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long GUIDLinkTypeKey {get;set;}
		public string LinkTable {get;set;}
		public string LinkColumn {get;set;}
		public RecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class GuidLinkTypeCollection
    {
        private static List<GuidLinkType> _list; 
        public static List<GuidLinkType> GuidLinkTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<GuidLinkType>
                        {
                            new GuidLinkType
							{
								EnumValue = 0,
								EnumName = "Undefined",
								EnumDescription = "",
								GUIDLinkTypeKey = 0,
								LinkTable = "",
								LinkColumn = "",
								RecStatusKey = (RecStatusEnum)1
							},
							new GuidLinkType
							{
								EnumValue = 1,
								EnumName = "Prospect",
								EnumDescription = "",
								GUIDLinkTypeKey = 1,
								LinkTable = "cust.PROSPECT_MST",
								LinkColumn = "ProspectGUID",
								RecStatusKey = (RecStatusEnum)1
							},
							new GuidLinkType
							{
								EnumValue = 2,
								EnumName = "Customer",
								EnumDescription = "",
								GUIDLinkTypeKey = 2,
								LinkTable = "cust.CUSTOMER_MST",
								LinkColumn = "CustomerGUID",
								RecStatusKey = (RecStatusEnum)1
							},
							new GuidLinkType
							{
								EnumValue = 3,
								EnumName = "ServiceCall",
								EnumDescription = "",
								GUIDLinkTypeKey = 3,
								LinkTable = "svc.SERVICECALL_MST",
								LinkColumn = "ServiceCallGUID",
								RecStatusKey = (RecStatusEnum)1
							},
							new GuidLinkType
							{
								EnumValue = 4,
								EnumName = "Application",
								EnumDescription = "",
								GUIDLinkTypeKey = 4,
								LinkTable = "app.APPLICATION_MST",
								LinkColumn = "ApplicationGUID",
								RecStatusKey = (RecStatusEnum)1
							},
							new GuidLinkType
							{
								EnumValue = 5,
								EnumName = "RellaidCall",
								EnumDescription = "",
								GUIDLinkTypeKey = 5,
								LinkTable = "dial.CALL_TRN",
								LinkColumn = "CallTrnGUID",
								RecStatusKey = (RecStatusEnum)1
							},
							new GuidLinkType
							{
								EnumValue = 6,
								EnumName = "Role",
								EnumDescription = "",
								GUIDLinkTypeKey = 6,
								LinkTable = "usr.ROLE_LUT",
								LinkColumn = "RowGUID",
								RecStatusKey = (RecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
