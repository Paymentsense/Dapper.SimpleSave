using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Event;

namespace PS.Mothership.Core.Common.Dto.Event
{
    [DataContract]
    public class StatusOwnerTransactionDto
    {
        [DataMember]
        public Guid StatusOwnerGuid { get; set; }
        [DataMember]
        public EventStatusEnum EventStatusKey { get; set; }
        [DataMember]
        public Guid UserGuid { get; set; }
        [DataMember]
        public Guid EventGuid { get; set; }
    }
}
