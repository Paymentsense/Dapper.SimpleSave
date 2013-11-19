using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class CampaignDetailsDto
    {
        [DataMember]
        public long CampaignId { get; set; }
        [DataMember]
        public string CampaignName { get; set; }
    }
}
