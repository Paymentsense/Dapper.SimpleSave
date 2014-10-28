using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Event;

namespace PS.Mothership.Core.Common.Dto.Event
{
    [DataContract]
    public class EventTrnDto
    {
        [DataMember]
        public Guid EventGuid { get; set; }

        [DataMember]
        public Guid? ParentEventGuid { get; set; }

        [DataMember]
        public EventTypeEnum EventTypeKey { get; set; }

        [DataMember]
        public Guid StatusOwnerGuid { get; set; }

        [DataMember]
        public Guid NotificationGuid { get; set; }

        [DataMember]
        public EventStatusOwnerTrnDto CurrentEventStatus { get; set; }

        [DataMember]
        public IList<EventNotesTrnDto> Notes { get; set; }

        [DataMember]
        public EventNotificationTrnDto CurrentNotification { get; set; }
       
    }
}
