using System;
using PS.Mothership.Core.Common.Contracts;

namespace PS.Mothership.Core.Common.Dto.Queue
{
    public class QueueItemDto : IQueueItem
    {
        public Guid QueueGuid { get; set; }
        public Guid EventGuid { get; set; }
        public Guid PermissionGuid { get; set; }
        public DateTimeOffset? ScheduledTime { get; set; }
    }
}
