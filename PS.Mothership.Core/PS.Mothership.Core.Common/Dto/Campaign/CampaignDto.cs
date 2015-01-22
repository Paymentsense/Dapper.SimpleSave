using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Contact;
using PS.Mothership.Core.Common.Dto.User;
using PS.Mothership.Core.Common.Template.Gen;
using PS.Mothership.Core.Common.Template.Mrkt;

namespace PS.Mothership.Core.Common.Dto.Campaign
{
    public class CampaignDto
    {
        [DataMember]
        public Guid CampaignGuid { get; set; }

        [DataMember]
        public string CampaignName { get; set; }

        [DataMember]
        public string CampaignDescription { get; set; }

        [DataMember]
        public DateTimeOffset StartDate { get; set; }

        [DataMember]
        public DateTimeOffset? EndDate { get; set; }

        [DataMember]
        public Guid PhoneGuid { get; set; }

        [DataMember]
        public MrktCampaignTypeEnum CampaignType { get; set; }

        [DataMember]
        public MrktCampaignSourceEnum CampaignSource { get; set; }

        [DataMember]
        public Guid StartedByUserGuid { get; set; }

        [DataMember]
        public Guid EndedByUserGuid { get; set; }

        [DataMember]
        public DateTime? UpdateDate { get; set; }

        [DataMember]
        public Guid RolePermissionGuid { get; set; }

        [DataMember]
        public GenRecStatusEnum RecStatus { get; set; }
    }
}
