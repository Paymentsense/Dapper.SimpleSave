using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Dto.Contact;

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
        public CountryDto Country { get; set; }

        [DataMember]
        public int CalculatorVersionKey { get; set; }

        [DataMember]
        public AcquiringOfferDto AcquiringOffer { get; set; }

        [DataMember]
        public IList<EquipmentModelDto> Equipment { get; set; }

        [DataMember]
        public IList<AddOnOfferDto> OfferAddOns { get; set; }

    }
}
