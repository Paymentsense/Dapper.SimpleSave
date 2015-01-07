using System;
using PS.Mothership.Core.Common.Contracts;

namespace PS.Mothership.Core.Common.Dto.Queue
{
    public class QueueItemDto : IQueueItem
    {
        public Guid EventGuid;
        public Guid PermissionGuid;
        public DateTimeOffset? ScheduledTime;
    }
}
