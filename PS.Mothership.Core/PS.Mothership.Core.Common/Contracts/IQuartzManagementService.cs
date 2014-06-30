using PS.Mothership.Core.Common.Constructs;
using PS.Mothership.Core.Common.Dto.DynamicRequest;
using PS.Mothership.Core.Common.Dto.QuartzManagement;
using PS.Mothership.Core.Common.Enums.QuartzManagement;
using Quartz;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name = "QuartzManagementService")]
    public interface IQuartzManagementService
    {
        [OperationContract]
        QuartzServerInfoDto GetQuartzServerInfo();

        [OperationContract]
        void ScheduleNewJob(string triggerName, string jobName, AvailableJobGroupsEnum jobGroupName,
            string jobClass, IntervalUnit occurance, string interval, DateTimeOffset startTime, IEnumerable<DayOfWeek> dayOfWeek);

        [OperationContract]
        void PauseAllTriggers();

        [OperationContract]
        void ResumeAllTriggers();

        [OperationContract]
        void PauseJob(string jobName);

        [OperationContract]
        void ResumeJob(string jobName);

        [OperationContract]
        void PauseTrigger(string triggerName);

        [OperationContract]
        void ResumeTrigger(string triggerName);

        [OperationContract]
        PagedList<JobProfileDto> GetJobs(DataRequestDto dataRequestDto);
    }
}
