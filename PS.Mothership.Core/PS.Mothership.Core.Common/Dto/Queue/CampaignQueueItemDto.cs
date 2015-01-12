using System;
using PS.Mothership.Core.Common.Contracts;

namespace PS.Mothership.Core.Common.Dto.Queue
{
    public class CampaignQueueItemDto : QueueItemDto, ICampaignQueueItem
    {
        public Guid ProspectGuid { get; set; }
        public Guid CampaignGuid { get; set; }
    }
}
