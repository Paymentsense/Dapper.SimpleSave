using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class SelectedSalesUserAndCampaignDto
    {
        [DataMember]
        public Guid UserGuid { get; set; }
        [DataMember]
        public Guid SalesUserGuid { get; set; }
        [DataMember]
        public long CampaignId { get; set; }
        [DataMember]
        public long SessionId { get; set; }
        [DataMember]
        public DateTime SelectionDateTime { get; set; }
    }
}
