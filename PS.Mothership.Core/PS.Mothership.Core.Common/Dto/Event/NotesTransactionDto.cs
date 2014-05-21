using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Event;

namespace PS.Mothership.Core.Common.Dto.Event
{
    [DataContract]
    public class NotesTransactionDto
    {
        [DataMember]
        public Guid NotesGuid { get; set; }
        [DataMember]
        public string Notes { get; set; }
        [DataMember]
        public EventNotesTypeEnum NotesTypeKey { get; set; }
        [DataMember]
        public Guid EventGuid { get; set; }
    }
}
