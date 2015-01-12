using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Campaign
{
    public class DefaultCampaignLutDto
    {
        [DataMember]
        public int DefaultCampaignKey { get; set; }

        [DataMember]
        public Guid CampaignGuid { get; set; }

        [DataMember]
        public int V1CampaignId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Url { get; set; }
    }
}
