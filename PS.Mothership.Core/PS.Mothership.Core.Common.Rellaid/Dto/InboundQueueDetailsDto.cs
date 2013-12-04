using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Rellaid.Dto
{
    [DataContract]
    public class InboundQueueDetailsDto
    {
        [DataMember]
        public long QueueId { get; set; }
        [DataMember]
        public string QueueName { get; set; }
        [DataMember]
        public string Extension { get; set; }
        [DataMember]
        public string SipUserId { get; set; }
        [DataMember]
        public string SipPassword { get; set; }
        [DataMember]
        public string SipProxyUserId { get; set; }
        [DataMember]
        public string SipProxyPassword { get; set; }
        [DataMember]
        public int RingTimeout { get; set; }
        [DataMember]
        public int ConsultTimeout { get; set; }
        [DataMember]
        public string VoicemailPhoneNumber { get; set; }
        [DataMember]
        public List<long> DepartmentIdList { get; set; }
    }
}
