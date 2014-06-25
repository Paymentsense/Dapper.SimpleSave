using PS.Mothership.Core.Common.Enums.QuartzManagement;
using System;

namespace PS.Mothership.Core.Common.Dto.QuartzManagement
{
    public class QuartzServerInfoDto
    {
        public string SchedulerName { get; set; }
        public Type JobStoreType { get; set; }
        public int NumberOfJobsExecuted { get; set; }
        public DateTimeOffset? RunningSince { get; set; }
        public SchedulerStatusEnum SchedulerStatus { get; set; }
    }
}
