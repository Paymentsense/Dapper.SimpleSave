using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Dial;
using PS.Mothership.Core.Common.Template.Mrkt;

namespace PS.Mothership.Core.Common.Dto.Dialler
{
    [DataContract]
    public class CallResolutionsMetadataDto
    {
        [DataMember]
        public IEnumerable<MrktCampaignCallResolution> CampaignCallResolutions { get; set; }

        //TODO: This needs to be changed to the new non-campaign call resolution type
        [DataMember]
        public IEnumerable<DialCallResolution> CallResolutions { get; set; }

        [DataMember]
        public IEnumerable<DialCallResolution> OutboundCallResolutions { get; set; }
    }
}
