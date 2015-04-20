using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Event;
using PS.Mothership.Core.Common.Template.Gen;
using PS.Mothership.Core.Common.Template.Mrkt;

namespace PS.Mothership.Core.Common.Dto.Dialler
{
    [DataContract]
    public class CampaignCallResolutionDto
    {
        [DataMember]
        public Guid EventGuid { get; set; }

        [DataMember]
        public MrktCampaignCallResolutionEnum CallResolutionKey { get; set; }

        [DataMember]
        public DateTimeOffset ScheduledDate { get; set; }

        [DataMember]
        public Guid MerchantGuid { get; set; }

        [DataMember]
        public Guid ContactGuid { get; set; }

        [DataMember]
        public Guid PhoneGuid { get; set; }

        [DataMember]
        public EventTypeEnum CallBackType { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public Guid UserGuid { get; set; }

        [DataMember]
        public EventNotificationMethodEnum ReminderType { get; set; }

        [DataMember]
        public GenPhoneNumberTypeEnum PhoneCountryKey { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }
    }
}
