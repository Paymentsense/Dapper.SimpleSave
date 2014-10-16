using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
    }
}
