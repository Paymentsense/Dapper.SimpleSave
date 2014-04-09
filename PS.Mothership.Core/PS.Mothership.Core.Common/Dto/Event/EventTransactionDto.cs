using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class EventTransactionDto
    {
        [DataMember]
        public Guid EventGuid { get; set; }
        [DataMember]
        public Guid ParentEventGuid { get; set; }
        [DataMember]
        public int EventTypeKey { get; set; }
        [DataMember]
        public Guid StatusOwnerGuid { get; set; }
        [DataMember]
        public Guid NotificationGuid { get; set; }
    }
}
