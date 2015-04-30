using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Opp
{
    
    [DataContract]
    public enum OppOfferConstraintTypeEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Contract Length")][EnumMember]ContractLengths = 1,
       [Description("Field")][EnumMember]Field = 2,
       [Description("Equipment Options")][EnumMember]EquipmentOptions = 3,
       [Description("Sales Channels")][EnumMember]SalesChannels = 4,
       [Description("Countries")][EnumMember]Countries = 5,
       [Description("Gateways")][EnumMember]Gateways = 6,
       [Description("AddOns")][EnumMember]AddOns = 7,
       [Description("Authorisation Fees")][EnumMember]AuthorisationFees = 9,
       [Description("AddOn Services")][EnumMember]AddOnServices = 10,
       [Description("AddOn Service Items")][EnumMember]AddOnServiceItems = 11,
       [Description("Type of transations")][EnumMember]TypeOfTransactions = 12,
       [Description("")][EnumMember]EquipmentModels = 13,
        
    }    
    
    public class OppOfferConstraintType
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int OfferConstraintTypeKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class OppOfferConstraintTypeCollection
    {
        private static List<OppOfferConstraintType> _list; 
        public static List<OppOfferConstraintType> OppOfferConstraintTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<OppOfferConstraintType>
                        {
                            new OppOfferConstraintType
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								OfferConstraintTypeKey = 0,
								RecStatusKey = (GenRecStatusEnum)3
							},
							new OppOfferConstraintType
							{
								EnumValue = 1,
								EnumName = "ContractLengths",
								EnumDescription = "Contract Length",
								OfferConstraintTypeKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new OppOfferConstraintType
							{
								EnumValue = 2,
								EnumName = "Field",
								EnumDescription = "Field",
								OfferConstraintTypeKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new OppOfferConstraintType
							{
								EnumValue = 3,
								EnumName = "EquipmentOptions",
								EnumDescription = "Equipment Options",
								OfferConstraintTypeKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new OppOfferConstraintType
							{
								EnumValue = 4,
								EnumName = "SalesChannels",
								EnumDescription = "Sales Channels",
								OfferConstraintTypeKey = 4,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new OppOfferConstraintType
							{
								EnumValue = 5,
								EnumName = "Countries",
								EnumDescription = "Countries",
								OfferConstraintTypeKey = 5,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new OppOfferConstraintType
							{
								EnumValue = 6,
								EnumName = "Gateways",
								EnumDescription = "Gateways",
								OfferConstraintTypeKey = 6,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new OppOfferConstraintType
							{
								EnumValue = 7,
								EnumName = "AddOns",
								EnumDescription = "AddOns",
								OfferConstraintTypeKey = 7,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new OppOfferConstraintType
							{
								EnumValue = 9,
								EnumName = "AuthorisationFees",
								EnumDescription = "Authorisation Fees",
								OfferConstraintTypeKey = 9,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new OppOfferConstraintType
							{
								EnumValue = 10,
								EnumName = "AddOnServices",
								EnumDescription = "AddOn Services",
								OfferConstraintTypeKey = 10,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new OppOfferConstraintType
							{
								EnumValue = 11,
								EnumName = "AddOnServiceItems",
								EnumDescription = "AddOn Service Items",
								OfferConstraintTypeKey = 11,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new OppOfferConstraintType
							{
								EnumValue = 12,
								EnumName = "TypeOfTransactions",
								EnumDescription = "Type of transations",
								OfferConstraintTypeKey = 12,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new OppOfferConstraintType
							{
								EnumValue = 13,
								EnumName = "EquipmentModels",
								EnumDescription = "",
								OfferConstraintTypeKey = 13,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
