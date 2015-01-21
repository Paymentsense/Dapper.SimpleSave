using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Merchant;

namespace PS.Mothership.Core.Common.Dto.Campaign
{
    public class CampaignQueueDto
    {
        [DataMember]
        public Guid CampaignQueueGuid { get; set; }

        [DataMember]
        public CampaignDto Campaign { get; set; }

        [DataMember]
        public MerchantDto Merchant { get; set; }

        [DataMember]
        public Guid UpdateSessionGuid { get; set; }

        [DataMember]
        public DateTime? UpdateDate { get; set; }
    }
}
