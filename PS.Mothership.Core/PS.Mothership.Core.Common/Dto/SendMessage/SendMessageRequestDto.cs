using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Comm;

namespace PS.Mothership.Core.Common.Dto.SendMessage
{
    [DataContract]
    [KnownType(typeof(SendMessageRequestSmsDto))]
    [KnownType(typeof(SendEmailRequestDto))]
    [KnownType(typeof(SendSmsRequestDto))]
    public abstract class SendMessageRequestDto
    {
        [DataMember]
        public Guid MessageGuid { get; set; }
        [DataMember]
        public List<Guid> OtherPartyFromToGuids { get; set; }
        [DataMember]
        public Guid MothershipFromToGuid { get; set; }
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string MessageBody { get; set; }
        [DataMember]
        public DateTimeOffset TimeToSend { get; set; }
        [DataMember]
        public Guid CustomerGuid { get; set; }
        [DataMember]
        public CommMessageTypeEnum MessageType { get; set; }
        [DataMember]
        public Guid SendFromUserGuid { get; set; }
    }
}
