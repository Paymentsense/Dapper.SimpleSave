using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Dial;

namespace PS.Mothership.Core.Common.Dto.Campaign
{
    [DataContract]
    public class CampaignCallDto
    {       
        [DataMember]
        public Guid InboundCampaignCallGuid { get; set; }

        [DataMember]
        public Guid CampaignGuid { get; set; }

        [DataMember]
        public string Keyword { get; set; }

        [DataMember]
        public string ReferrerUrl { get; set; }

        [DataMember]
        public DialInboundCampaignCallResolutionEnum InboundCampaignCallResolutionKey { get; set; }
    }
}