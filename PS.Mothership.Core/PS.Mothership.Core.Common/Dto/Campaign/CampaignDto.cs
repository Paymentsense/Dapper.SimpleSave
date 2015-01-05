using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Contact;
using PS.Mothership.Core.Common.Dto.User;
using PS.Mothership.Core.Common.Template.Mrkt;

namespace PS.Mothership.Core.Common.Dto.Campaign
{
    public class CampaignDto
    {
        [DataMember]
        public string CampaignName { get; set; }

        [DataMember]
        public string CampaignDescription { get; set; }

        [DataMember]
        public DateTime? StartDate { get; set; }

        [DataMember]
        public DateTime? EndDate { get; set; }

        [DataMember]
        public PhoneNumberDto Phone { get; set; }

        [DataMember]
        public MrktCampaignTypeEnum CampaignType { get; set; }

        [DataMember]
        public MrktCampaignSourceEnum CampaignSource { get; set; }

        [DataMember]
        public UserDto StartedByUser { get; set; }

        [DataMember]
        public UserDto EndedByUser { get; set; }

        [DataMember]
        public DateTime? UpdateDate { get; set; }
    }
}
