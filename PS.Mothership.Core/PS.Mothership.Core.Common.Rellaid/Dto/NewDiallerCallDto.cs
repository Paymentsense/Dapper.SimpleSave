using PS.Mothership.Core.Common.Template.Dial;
using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Rellaid.Dto
{
    [DataContract]
    public class NewDiallerCallDto
    {
        [DataMember]
        public Guid MothershipSessionGuid { get; set; }

        [DataMember]
        public Guid SipCallGuid { get; set; }

        [DataMember]
        public DialCallTypeEnum CallType { get; set; }

        [DataMember]
        public Guid SessionModeGuid { get; set; }

        [DataMember]
        public DateTimeOffset StartDateTime { get; set; }

        [DataMember]
        public string DialledNumber { get; set; }

        [DataMember]
        public Guid UserSipPhoneGuid { get; set; }

        [DataMember]
        public string CIDNumber { get; set; }

        [DataMember]
        public Guid? MerchantGuid { get; set; }

        [DataMember]
        public Guid? ProspectingCampaignCallGuid { get; set; }

        [DataMember]
        public long? CampaignKey { get; set; }

        [DataMember]
        public Guid? ConsultOriginSipCallGuid { get; set; }

        [DataMember]
        public Guid? ProspectingCampaignResponseTapCallGuid { get; set; }

        [DataMember]
        public Guid InboundCampaignCallGuid { get; set; }

        [DataMember]
        public DialCallDispositionEnum CallDisposition { get; set; }
    }
}
