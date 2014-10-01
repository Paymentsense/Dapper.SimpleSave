using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Event;

namespace PS.Mothership.Core.Common.Dto.Event
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
        [DataMember]
        public DateTimeOffset UpdateDate { get; set; }
        [DataMember]
        public Guid UpdateSessionGuid { get; set; }
        [DataMember]
        public StatusOwnerTransactionDto StatusOwnerCurrent { get; set; }
        [DataMember]
        public IList<StatusOwnerTransactionDto> StatusOwners { get; set; }
        [DataMember]
        public IList<NotesTransactionDto> Notes { get; set; }
        [DataMember]
        public NotificationTransactionDto NotificationCurrent { get; set; }
        [DataMember]
        public IList<NotificationTransactionDto> Notifications { get; set; }
        [DataMember]
        public IList<EventRoleLnkDto> EventRoleLnk { get; set; }
        [DataMember]
        public IList<EventNotesLnkDto> EventNotesLnk { get; set; }
    }
}
