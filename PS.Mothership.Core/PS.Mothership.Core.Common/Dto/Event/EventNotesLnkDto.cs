using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Event
{
    [DataContract]
    public class EventNotesLnkDto
    {
        [DataMember]
        public Guid EventNotesGuid { get; set; }
        [DataMember]
        public Guid NotesGuid { get; set; }
        [DataMember]
        public Guid EventGuid { get; set; }
        [DataMember]
        public DateTimeOffset UpdateDate { get; set; }
        [DataMember]
        public Guid UpdateSessionGuid { get; set; }
        [DataMember]
        public EventTransactionDto Event { get; set; }
        [DataMember]
        public IList<NotesTransactionDto> Notes { get; set; }
    }
}
