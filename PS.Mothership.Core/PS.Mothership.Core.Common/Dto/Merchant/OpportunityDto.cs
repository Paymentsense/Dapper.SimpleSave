using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class OpportunityDto
    {
        [DataMember]
        public Guid OpportunityGuid { get; set; }

        [DataMember]
        public string OpportunityLocatorId { get; set; }

        [DataMember]
        public Guid ProspectGuid { get; set; }

        [DataMember]
        public Guid CustomerGuid { get; set; }

        [DataMember]
        public Guid CurrentOfferGuid { get; set; }

        [DataMember]
        public Guid PartnerGuid { get; set; }

        [DataMember]
        public Guid CurrentStatusTrnGuid { get; set; }

        [DataMember]
        public OfferDto CurrentOffer { get; set; }

        [DataMember]
        public Guid UpdateSessionGuid { get; set; }

        [DataMember]
        public string UpdateUsername { get; set; }

        [DataMember]
        public DateTimeOffset UpdateDate { get; set; }

        [DataMember]
        public IList<OfferVersionDto> OfferVersions { get; set; }
    }
}
