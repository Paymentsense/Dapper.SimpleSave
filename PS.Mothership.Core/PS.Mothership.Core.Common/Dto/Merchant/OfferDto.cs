using PS.Mothership.Core.Common.Template.Gen;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class OfferDto
    {
        [DataMember]
        public Guid OfferGuid { get; set; }

        [DataMember]
        public string OfferReference { get; set; }

        [DataMember]
        public OpportunityDto Opportunity { get; set; }

        [DataMember]
        public GatewayOfferDto GatewayOffer { get; set; }

        [DataMember]
        public Guid SalesChannelGuid { get; set; }

        [DataMember]
        public GenCountryEnum CountryKey { get; set; }

        [DataMember]
        public int CalculatorVersionKey { get; set; }

        [DataMember]
        public AcquiringOfferDto AcquiringOffer { get; set; }

        [DataMember]
        public IList<EquipmentModelDto> Equipment { get; set; }
       
        [DataMember]
        public IList<AddOnOfferTrnDto> OfferAddOns { get; set; }

        [DataMember]
        public string LastUpdatedUserName { get; set; }
        
        [DataMember]
        public Guid LastUpdatedUserGuid { get; set; }
    }
}
