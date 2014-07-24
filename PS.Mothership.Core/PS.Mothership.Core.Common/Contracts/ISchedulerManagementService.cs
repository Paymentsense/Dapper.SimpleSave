using PS.Mothership.Core.Common.Constructs;
using PS.Mothership.Core.Common.Dto.DynamicRequest;
using PS.Mothership.Core.Common.Dto.SchedulerManagement;
using PS.Mothership.Core.Common.Template.Gen;
using Quartz;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name = "SchedulerManagementService")]
    public interface ISchedulerManagementService
    {
        [OperationContract]
        SchedulerServerInfoDto GetSchedulerServerInfo();

        [OperationContract]
        void ScheduleNewJob(GenSchedulerJobGroupEnum jobGroup, string jobClass, string jobName, string triggerName,
            IntervalUnit triggerOccurrence, int triggerInterval, DateTimeOffset triggerStartTime, IEnumerable<DayOfWeek> triggerDaysOfWeek = null);

        [OperationContract]
        void PauseAllTriggers();

        [OperationContract]
        void ResumeAllTriggers();

        [OperationContract]
        void PauseJob(GenSchedulerJobGroupEnum jobGroup, string jobName);

        [OperationContract]
        void ResumeJob(GenSchedulerJobGroupEnum jobGroup, string jobName);

        [OperationContract]
        void PauseTrigger(GenSchedulerJobGroupEnum jobGroup, string jobName, string triggerName);

        [OperationContract]
        void ResumeTrigger(GenSchedulerJobGroupEnum jobGroup, string jobName, string triggerName);

        [OperationContract]
        PagedList<JobProfileDto> GetJobs(DataRequestDto dataRequestDto);

        [OperationContract]
        JobProfileDto GetJob(GenSchedulerJobGroupEnum jobGroup, string jobName);

        [OperationContract]
        PagedList<TriggerProfileDto> GetTriggers(GenSchedulerJobGroupEnum jobGroup, string jobName, DataRequestDto dataRequestDto);

        [OperationContract]
        TriggerProfileDto GetTrigger(GenSchedulerJobGroupEnum jobGroup, string jobName, string triggerName);

        [OperationContract]
        void ExecuteJobNow(GenSchedulerJobGroupEnum jobGroup, string jobName);

        [OperationContract]
        void AddTriggerToJob(GenSchedulerJobGroupEnum jobGroup, string jobName, string triggerName, IntervalUnit triggerOccurrence, int triggerInterval,
            DateTimeOffset triggerStartTime, IEnumerable<DayOfWeek> triggerDaysOfWeek = null);

        [OperationContract]
        void DeleteTrigger(GenSchedulerJobGroupEnum jobGroup, string jobName, string triggerName);

        [OperationContract]
        void RescheduleTrigger(GenSchedulerJobGroupEnum jobGroup, string jobName, string triggerName, IntervalUnit triggerOccurrence, int triggerInterval,
            DateTimeOffset triggerStartTime, IEnumerable<DayOfWeek> triggerDaysOfWeek = null);
    }
}
