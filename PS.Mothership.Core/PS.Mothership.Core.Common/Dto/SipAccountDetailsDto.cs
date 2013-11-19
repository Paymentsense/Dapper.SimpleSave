using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class SipAccountDetailsDto
    {
        [DataMember]
        public string SipUserId { get; set; }
        [DataMember]
        public string SipPassword { get; set; }
        [DataMember]
        public string SipProxyUserId { get; set; }
        [DataMember]
        public string SipProxyPassword { get; set; }
        [DataMember]
        public Guid UserGuid { get; set; }
        [DataMember]
        public string Extension { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string SupervisorUserName { get; set; }
        [DataMember]
        public long DepartmentId { get; set; }
        [DataMember]
        public long DepartmentCategoryId { get; set; }
        [DataMember]
        public List<InboundQueueSubscriptionDto> InboundQueueSubscriptions { get; set; }
    }
}
