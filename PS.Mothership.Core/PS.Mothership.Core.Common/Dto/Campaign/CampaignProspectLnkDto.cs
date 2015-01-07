using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Campaign
{
    public class CampaignProspectLnkDto
    {
        [DataMember]
        public Guid CampaignProspectLnkGuid { get; set; }

        [DataMember]
        public Guid CampaignGuid { get; set; }

        [DataMember]
        public Guid ProspectGuid { get; set; }

        [DataMember]
        public Guid EventGuid { get; set; }

        [DataMember]
        public string ReferrerUrl { get; set; }

        [DataMember]
        public string Url { get; set; }
    }
}
