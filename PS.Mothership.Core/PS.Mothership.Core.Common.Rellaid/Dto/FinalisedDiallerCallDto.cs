using PS.Mothership.Core.Common.Template.Dial;
using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Rellaid.Dto
{
    [DataContract]
    public class FinalisedDiallerCallDto
    {
        [DataMember]
        public Guid SipCallGuid { get; set; }

        [DataMember]
        public DateTime EndDateTime { get; set; }

        [DataMember]
        public string TransferredNumber { get; set; }

        [DataMember]
        public CallDispositionEnum CallDisposition { get; set; }

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
        public long? RecorderCallId { get; set; }

        [DataMember]
        public Guid? MerchantGuid { get; set; }
    }
}
