using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Dialler
{
    [DataContract]
    public class CallRecordingEventDto
    {
        [DataMember]
        public DateTimeOffset? CreatedDate { get; set; }

        [DataMember]
        public Guid? ProspectingCampaignCallGuid { get; set; }

        [DataMember]
        public string FileName { get; set; }

        [DataMember]
        public Guid? MerchantGuid { get; set; }

        [DataMember]
        public Guid UpdateSessionGuid { get; set; }

        [DataMember]
        public Guid SipCallGuid { get; set; }
    }
}