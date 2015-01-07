using System;

namespace PS.Mothership.Core.Common.Dto.Queue
{
    public class CampaignQueueItemDto : QueueItemDto
    {
        public Guid ProspectGuid;
        public Guid CampaignGuid;
    }
}
