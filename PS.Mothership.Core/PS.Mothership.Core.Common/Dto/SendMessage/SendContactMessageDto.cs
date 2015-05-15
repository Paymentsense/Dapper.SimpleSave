using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.SendMessage
{
    [DataContract]
    public class SendContactMessageDto
    {
        [DataMember]
        public Guid ContactGuid { get; set; }

        [DataMember]
        public string MessageBody { get; set; }
    }
}
