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
        public MerchantDto Merchant { get; set; }

        [DataMember]
        public PartnerDto Partner { get; set; }
    }
}
