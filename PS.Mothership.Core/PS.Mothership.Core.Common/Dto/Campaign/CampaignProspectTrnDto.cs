using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Campaign
{
    public class CampaignProspectTrnDto
    {
        [DataMember]
        public Guid CampaignProspectTrnGuid { get; set; }

        [DataMember]
        public Guid CampaignGuid { get; set; }

        [DataMember]
        public Guid MerchantGuid { get; set; }

        [DataMember]
        public Guid EventGuid { get; set; }

        [DataMember]
        public string ReferrerUrl { get; set; }

        [DataMember]
        public string Keyword { get; set; }
    }
}
