using System;

namespace PS.Mothership.Core.Common.Contracts
{
    public interface ICampaignQueueItem
    {
        Guid ProspectGuid { get; set; }
        Guid CampaignGuid { get; set; }
    }
}
