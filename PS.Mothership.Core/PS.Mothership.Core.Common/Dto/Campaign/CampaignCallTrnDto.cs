using PS.Mothership.Core.Common.Template.Mrkt;
using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Campaign
{
    public class CampaignCallTrnDto
    {
        [DataMember]
        public Guid CampaignCallTrnGuid { get; set; }

        [DataMember]
        public Guid CallGuid { get; set; }

        [DataMember]
        public MrktCampaignCallResolutionEnum CampaignCallResolutionKey { get; set; }

        [DataMember]
        public Guid ResponseTapTrnGuid { get; set; }

        [DataMember]
        public Guid CampaignGuid { get; set; }

        [DataMember]
        public Guid QueueGuid { get; set; }
    }
}
