using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Dialler
{
    [DataContract]
    public class ValidUserInfoDto
    {
        [DataMember]
        public Guid UserGuid { get; set; }
        [DataMember]
        public string PhoneNumberOverride { get; set; }
        [DataMember]
        public string VoicemailNumber { get; set; }
        [DataMember]
        public string MonitorPhoneNumber { get; set; }
        [DataMember]
        public string UserPhoneNumber { get; set; }
        [DataMember]
        public IList<CallLogItemDto> CallLog { get; set; }
        [DataMember]
        public string SipUserId { get; set; }
        [DataMember]
        public string SipPassword { get; set; }
        [DataMember]
        public string SipProxyUserId { get; set; }
        [DataMember]
        public string SipProxyPassword { get; set; }
        [DataMember]
        public IList<InboundQueueSubscriptionDto> InboundQueueSubscriptions { get; set; }
        [DataMember]
        public long DepartmentKey { get; set; }
        [DataMember]
        public long DepartmentCategoryKey { get; set; }
        [DataMember]
        public IList<SpeedDialNumberDto> SpeedDialNumbers { get; set; }
        [DataMember]
        public Guid UserSipPhoneGuid { get; set; }
        [DataMember]
        public string LoginName { get; set; }
    }
}
