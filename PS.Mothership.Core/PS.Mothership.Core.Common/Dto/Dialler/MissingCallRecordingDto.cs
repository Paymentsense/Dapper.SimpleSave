using PS.Mothership.Core.Common.Template.Dial;
using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Dialler
{
    [DataContract]
    public class MissingCallRecordingDto
    {
        [DataMember]
        public DateTimeOffset? AdjustedStartDateTime { get; set; }
        [DataMember]
        public DateTimeOffset? StartDateTime { get; set; }
        [DataMember]
        public string SipUserPhoneNumber { get; set; }
        [DataMember]
        public string UserPhoneNumber { get; set; }
        [DataMember]
        public DialCallTypeEnum? CallType { get; set; }
        [DataMember]
        public int? TotalTime { get; set; }
        [DataMember]
        public string DialledNumber { get; set; }
        [DataMember]
        public Guid? UserGuid { get; set; }
        [DataMember]
        public Guid? MerchantGuid { get; set; }
        [DataMember]
        public Guid SipCallGuid { get; set; }
        [DataMember]
        public Guid UpdateSessionGuid { get; set; }
    }
}
