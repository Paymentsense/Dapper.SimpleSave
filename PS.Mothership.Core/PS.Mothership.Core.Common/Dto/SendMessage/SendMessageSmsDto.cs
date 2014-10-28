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
        //[DataMember]
        //public string MessageBody { get; set; }
        //[DataMember]
        //public Guid SessionGuid { get; set; }
        //[DataMember]
        //public DateTimeOffset TimeToSend { get; set; }
        //[DataMember]
        //public Guid CustomerGUID { get; set; }
        //[DataMember]
        //public CommMessageTypeEnum MessageType { get; set; }
        //[DataMember]
        //public MessageDirectionEnum MessageDirection { get; set; }
    }
}
