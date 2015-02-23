using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Event;

namespace PS.Mothership.Core.Common.Dto.Event
{
    [DataContract]
    public class EventTrnFullDto
    {
        [DataMember]
        public Guid EventGuid { get; set; }

        [DataMember]
        public EventTrnDto ParentEvent { get; set; }

        [DataMember]
        public EventTypeEnum EventTypeKey { get; set; }

        [DataMember]
        public EventStatusOwnerTrnDto CurrentEventStatus { get; set; }

        [DataMember]
        public IList<EventStatusOwnerTrnDto> EventStatuses { get; set; }

        [DataMember]
        public IList<EventNotesTrnDto> Notes { get; set; }

        [DataMember]
        public EventNotificationTrnDto CurrentNotification { get; set; }

        [DataMember]
        public IList<EventNotificationTrnDto> Notifications { get; set; }
       
    }
}
