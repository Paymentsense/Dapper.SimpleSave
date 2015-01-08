using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Dialler;

namespace PS.Mothership.Core.Common.Dto.Campaign
{
    [DataContract]
    public class CampaignCallMstDto : CallRecordDto
    {       
        // TODO move campaignGuid to campaigncallmst from call_mst
        //[DataMember]
        //public Guid CampaignGuid { get; set; }

        [DataMember]
        public Guid CurrentCampaignCallTrnGuid { get; set; }
    }
}