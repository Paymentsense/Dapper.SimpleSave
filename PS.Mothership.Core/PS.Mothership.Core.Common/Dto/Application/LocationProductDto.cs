using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Merchant;

namespace PS.Mothership.Core.Common.Dto.Application
{
    [DataContract]
    public class LocationProductDto
    {
        [DataMember]
        public Guid LocationProductGuid { get; set; }

        [DataMember]
        public Guid LocationGuid { get; set; }

        [DataMember]
        public OfferDto CurrentOffer { get; set; }
        
        [DataMember]
        public Guid ContactGuid { get; set; }

        [DataMember]
        public Guid MerchantGuid { get; set; }
    
    }
}
