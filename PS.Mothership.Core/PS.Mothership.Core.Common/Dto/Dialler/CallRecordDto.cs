using PS.Mothership.Core.Common.Template.Dial;
using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Dialler
{
    [DataContract]
    public class CallRecordDto
    {
        [DataMember]
        public Guid CallGuid { get; set; }
        [DataMember]
        public Guid SessionModeGuid { get; set; }
        [DataMember]
        public Guid UserSipPhoneGuid { get; set; }
        [DataMember]
        public Guid DialledPhoneGuid { get; set; }
        [DataMember]
        public Guid CidPhoneGuid { get; set; }
        [DataMember]
        public Guid TransferredPhoneGuid { get; set; }
        [DataMember]
        public DialCallTypeEnum CallTypeKey { get; set; }
        [DataMember]
        public DialCallDispositionEnum CallDispositionKey { get; set; }
        [DataMember]
        public DateTimeOffset StartDateTime { get; set; }
        [DataMember]
        public DateTimeOffset? EndDateTime { get; set; }
        [DataMember]
        public Guid MerchantGuid { get; set; }
        [DataMember]
        public Guid ProspectingCampaignCallGuid { get; set; }
        [DataMember]
        public Guid CampaignGuid { get; set; }
        [DataMember]
        public int PreviewTime { get; set; }
        [DataMember]
        public int DialOrRingTime { get; set; }
        [DataMember]
        public int TalkTime { get; set; }
        [DataMember]
        public int HoldTime { get; set; }
        [DataMember]
        public int WrapTime { get; set; }
        [DataMember]
        public Guid SipCallGuid { get; set; }
        [DataMember]
        public Guid ConsultOriginSipCallGuid { get; set; }
        [DataMember]
        public long? RecorderCallId { get; set; }
        [DataMember]
        public Guid ProspectingCampaignResponseTapCallGuid { get; set; }
        [DataMember]
        public Guid InboundCampaignCallGuid { get; set; }
    }
}