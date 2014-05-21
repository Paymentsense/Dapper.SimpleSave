using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Dial;

namespace PS.Mothership.Core.Common.Dto.Dialler
{
    [DataContract]
    public class InboundCampaignCallDto
    {       
        [DataMember]
        public Guid InboundCampaignCallGuid { get; set; }
        [DataMember]
        public long CampaignKey { get; set; }
        [DataMember]
        public string Keyword { get; set; }
        [DataMember]
        public string ReferrerUrl { get; set; }
        [DataMember]
        public DialInboundCampaignCallResolutionEnum InboundCampaignCallResolutionKey { get; set; }
    }
}