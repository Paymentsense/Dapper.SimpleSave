using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class OpportunityLatestOfferDto
    {
        [DataMember]
        public Guid OpportunityGuid { get; set; }

        [DataMember]
        public OfferDto LatestOffer { get; set; }

        [DataMember]
        public IList<OfferVersionDto> OfferVersions { get; set; }

        [DataMember]
        public DateTimeOffset UpdateDate { get; set; }

        [DataMember]
        public Guid UpdateSessionGuid { get; set; }

        [DataMember]
        public string UpdateUsername { get; set; }
    }
}
