using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Event;

namespace PS.Mothership.Core.Common.Dto.Reminder
{
    [DataContract]
    public class ReminderMetaDataDto
    {
        [DataMember]
        public IList<EventType> EventTypes { get; set; }

        [DataMember]
        public IList<ReminderContactMetadataDto> MerchantContacts { get; set; }
    }
}
