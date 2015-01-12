using System;

namespace PS.Mothership.Core.Common.Contracts
{
    /// <summary>
    /// Represents an item that can be present within a queue
    /// </summary>
    public interface IQueueItem
    {
        Guid EventGuid { get; set; }
        Guid PermissionGuid { get; set; }
        DateTimeOffset? ScheduledTime { get; set; }
    }
}
