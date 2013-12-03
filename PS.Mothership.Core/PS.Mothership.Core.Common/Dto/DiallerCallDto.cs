using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class DiallerCallDto
    {
        [DataMember]
        public int? SessionModeId { get; set; }
        [DataMember]
        public Guid? UserGuid { get; set; }
        [DataMember]
        public int CallTypeId { get; set; }
        [DataMember]
        public DateTime StartDateTime { get; set; }
        [DataMember]
        public DateTime EndDateTime { get; set; }
        [DataMember]
        public string DialledNumber { get; set; }
        [DataMember]
        public string ExtensionNumber { get; set; }
        [DataMember]
        public string TransferredNumber { get; set; }
        [DataMember]
        public Guid? GcCallId { get; set; }
        [DataMember]
        public Guid? SipCallId { get; set; }
        [DataMember]
        public Guid? ConsultOriginSipCallId { get; set; }
        [DataMember]
        public int? RecorderCallId { get; set; }
        [DataMember]
        public long? AdinsightCallTrnId { get; set; }
        [DataMember]
        public string CIdNumber { get; set; }
        [DataMember]
        public int CallDispositionId { get; set; }
        [DataMember]
        public Guid? MerchantGuid { get; set; }
        [DataMember]
        public long? PcMerchantTrnId { get; set; }
        [DataMember]
        public long? CampaignId { get; set; }
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
        public long? CampaignCallTrnId { get; set; }
    }
}
