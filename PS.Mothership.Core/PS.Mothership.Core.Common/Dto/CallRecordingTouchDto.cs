using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class CallRecordingTouchDto
    {
        [DataMember]
        public DateTime? CreatedDate { get; set; }
        [DataMember]
        public long? DiallerQueueId { get; set; }
        [DataMember]
        public string FileName { get; set; }
        [DataMember]
        public Guid? MerchantGuid { get; set; }
        [DataMember]
        public Guid UserGuid { get; set; }
    }
}
