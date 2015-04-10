using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Event;

namespace PS.Mothership.Core.Common.Dto.Event
{
    [DataContract]
    public class EventNotesTrnDto
    {
        [DataMember]
        public Guid NotesGuid { get; set; }

        [DataMember]
        public Guid EventGuid { get; set; }

        [DataMember]
        public Guid MerchantGuid { get; set; }

        [DataMember]
        public Guid UserGuid { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Notes { get; set; }

        [DataMember]
        public EventNotesTypeEnum NotesTypeKey { get; set; }

        [DataMember]
        public DateTimeOffset UpdateDate { get; set; }

        [DataMember]
        public bool IsEditable { get; set; }
    }
}
