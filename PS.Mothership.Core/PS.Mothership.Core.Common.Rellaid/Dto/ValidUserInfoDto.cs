using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Rellaid.Dto
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
        public string CrmLandingPage { get; set; }
        [DataMember]
        public string Extension { get; set; }
        [DataMember]
        public string DisplayName { get; set; }
        [DataMember]
        public bool IsTeleAppointer { get; set; }
        [DataMember]
        public bool IsLeadGenerator { get; set; }
        [DataMember]
        public bool IsCot { get; set; }
        [DataMember]
        public bool IsOffshoreTa { get; set; }
        [DataMember]
        public List<CallLogItemDto> CallLog { get; set; }
    }
}
