using PS.Mothership.Core.Common.Dto.Contact;
using PS.Mothership.Core.Common.Template.Dial;
using PS.Mothership.Core.Common.Template.Gen;
using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Dialler
{
    [DataContract]
    public class SipAccountDto : PhoneNumberDto
    {       
        [DataMember]
        public Guid DiallerSessionGuid { get; set; }
        [DataMember]
        public string Extension  { get; set; }
        [DataMember]
        public string SipUserId { get; set; }
        [DataMember]
        public string SipPassword { get; set; }
        [DataMember]
        public string SipProxyUserId { get; set; }
        [DataMember]
        public string SipProxyPassword { get; set; }
        [DataMember]
        public DialSipAccountTypeEnum SipAccountTypeKey { get; set; }
        [DataMember]
        public string VoicemailNumber { get; set; }
        [DataMember]
        public GenRecStatusEnum RecStatusKey { get; set; }
    }
}