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
        void PauseJob(string jobName);

        [OperationContract]
        void ResumeJob(string jobName);

        [OperationContract]
        void PauseTrigger(string jobName, string triggerName);

        [OperationContract]
        void ResumeTrigger(string jobName, string triggerName);

        [OperationContract]
        PagedList<JobProfileDto> GetJobs(DataRequestDto dataRequestDto);

        [OperationContract]
        JobProfileDto GetJob(string jobName);

        [OperationContract]
        PagedList<TriggerProfileDto> GetTriggers(string jobName, DataRequestDto dataRequestDto);

        [OperationContract]
        TriggerProfileDto GetTrigger(string jobName, string triggerName);

        [OperationContract]
        void ExecuteJobNow(string jobName);

        [OperationContract]
        void AddTriggerToJob(string jobName, string triggerName, IntervalUnit triggerOccurrence, int triggerInterval,
            DateTimeOffset triggerStartTime, IEnumerable<DayOfWeek> triggerDaysOfWeek = null);

        [OperationContract]
        void DeleteTrigger(string jobName, string triggerName);

        [OperationContract]
        void RescheduleTrigger(string jobName, string triggerName, IntervalUnit triggerOccurrence, int triggerInterval,
            DateTimeOffset triggerStartTime, IEnumerable<DayOfWeek> triggerDaysOfWeek = null);
    }
}
