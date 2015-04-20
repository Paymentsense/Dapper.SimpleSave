using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.ScheduledCallBack;
using PS.Mothership.Core.Common.Template.Mrkt;

namespace PS.Mothership.Core.Common.Dto.Dialler
{
    [DataContract]
    public class CallResolutionsMetadataDto
    {
        public ScheduledCallbackMetaDataDto TaskMetadeta { get; set; }

        public IEnumerable<MrktCampaignCallResolution> CampaignCallResolutions { get; set; }

        //TODO: This needs to be changed to the new non-campaign call resolution type
        public IEnumerable<int> CallResolutions { get; set; }
    }
}
