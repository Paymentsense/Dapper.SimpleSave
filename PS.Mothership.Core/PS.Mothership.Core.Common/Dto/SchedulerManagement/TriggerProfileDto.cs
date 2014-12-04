using PS.Mothership.Core.Common.Template.Gen;
using Quartz;
using System;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Dto.SchedulerManagement
{
    public class TriggerProfileDto
    {
        public string Name { get; set; }
        public TriggerState State { get; set; }
        public DateTimeOffset? NextFireTime { get; set; }
        public DateTimeOffset? PreviousFireTime { get; set; }
        public string Schedule { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public IntervalUnit Occurrence { get; set; }
        public int TriggerInterval { get; set; }
        public IEnumerable<DayOfWeek> SelectedDaysOfWeek { get; set; }
        public GenSchedulerJobGroupEnum JobGroup { get; set; }
    }
}
