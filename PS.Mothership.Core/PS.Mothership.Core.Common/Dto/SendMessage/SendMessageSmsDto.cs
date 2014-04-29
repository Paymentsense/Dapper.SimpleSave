using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.SendMessage
{
    [DataContract]
    public class SendMessageRequestSmsDto : SendMessageRequestDto
    {
        [DataMember]
        public List<SendMessageSmsToDto> To { get; set; }
        [DataMember]
        public string From { get; set; }
    }
}
