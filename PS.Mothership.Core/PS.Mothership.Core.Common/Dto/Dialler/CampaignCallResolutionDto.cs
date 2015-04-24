using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.ScheduledCallBack;
using PS.Mothership.Core.Common.Template.Mrkt;

namespace PS.Mothership.Core.Common.Dto.Dialler
{
    [DataContract]
    public class CampaignCallResolutionDto
    {
        [DataMember]
        public Guid SipCallGuid { get; set; }

        [DataMember]
        public MrktCampaignCallResolutionEnum CallResolutionKey { get; set; }

        [DataMember]
        public ScheduledCallbackDto MerchantTask { get; set; }
    }
}
