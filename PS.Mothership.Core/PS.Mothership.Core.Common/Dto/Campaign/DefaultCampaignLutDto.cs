using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Campaign
{
    public class DefaultCampaignLutDto
    {
        [DataMember]
        public CampaignDto Campaign { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Url { get; set; }
    }
}
