using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Dial;

namespace PS.Mothership.Core.Common.Dto.Campaign
{
    public class CampaignCallTrnDto
    {
        [DataMember]
        public Guid CampaignCallTrnGuid { get; set; }

        [DataMember]
        public Guid CallGuid { get; set; }

        [DataMember]
        public Guid PhoneNumberGuid { get; set; }

        [DataMember]
        public DialInboundCampaignCallResolutionEnum CampaignCallResolutionKey { get; set; }
    }
}
