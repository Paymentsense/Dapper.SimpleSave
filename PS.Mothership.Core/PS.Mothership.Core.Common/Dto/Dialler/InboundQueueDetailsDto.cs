using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Dialler
{
    [DataContract]
    public class InboundQueueDetailsDto
    {
        [DataMember]
        public Guid InboundQueueGuid { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string SipUserPhoneNumber { get; set; }

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
        public List<long> DepartmentKeyList { get; set; }
    }
}
