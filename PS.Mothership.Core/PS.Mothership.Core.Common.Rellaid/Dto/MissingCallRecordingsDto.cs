using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Rellaid.Dto
{
    [DataContract]
    public class MissingCallRecordingsDto
    {
        [DataMember]
        public DateTime? AdjustedStartDateTime { get; set; }
        [DataMember]
        public DateTime? StartDateTime { get; set; }
        [DataMember]
        public string SipUserId { get; set; }
        [DataMember]
        public string Extension { get; set; }
        [DataMember]
        public short? CallTypeId { get; set; }
        [DataMember]
        public int? TotalTime { get; set; }
        [DataMember]
        public string DialledNumber { get; set; }
        [DataMember]
        public Guid? UserGuid { get; set; }
        [DataMember]
        public long? PcCallTrandId { get; set; }
        [DataMember]
        public Guid? MerchantGuid { get; set; }
        [DataMember]
        public Guid CallGuid { get; set; }
    }
}
