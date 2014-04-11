using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Event
{
    [DataContract]
    public class StatusOwnerTransactionDto
    {
        [DataMember]
        public Guid StatusOwnerGuid { get; set; }
        [DataMember]
        public int EventStatusKey { get; set; }
        [DataMember]
        public Guid UserGuid { get; set; }
        [DataMember]
        public Guid EventGuid { get; set; }
    }
}
