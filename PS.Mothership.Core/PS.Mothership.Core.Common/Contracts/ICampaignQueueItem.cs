using System;

namespace PS.Mothership.Core.Common.Contracts
{
    public interface ICampaignQueueItem : IQueueItem
    {
        Guid ProspectGuid { get; set; }
        Guid CampaignGuid { get; set; }
    }
}
