using Quartz;
using System;

namespace PS.Mothership.Core.Common.Dto.SchedulerManagement
{
    public class TriggerProfileDto
    {
        public string Name { get; set; }
        public TriggerState State { get; set; }
        public DateTimeOffset? NextFireTime { get; set; }
        public string Schedule { get; set; }
    }
}
