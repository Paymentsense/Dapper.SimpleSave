using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Dto.Campaign
{
    public class CampaignQueueDto
    {
        [DataMember]
        public Guid QueueGuid { get; set; }

        [DataMember]
        public Guid CampaignProspectTrnGuid { get; set; }

        [DataMember]
        public Guid EventGuid { get; set; }

        [DataMember]
        public Guid RolePermissionGuid { get; set; }

        [DataMember]
        public GenQueueTypeEnum QueueType { get; set; }

        [DataMember]
        public Guid UpdateSessionGuid { get; set; }

        [DataMember]
        public DateTime? UpdateDate { get; set; }
    }
}
