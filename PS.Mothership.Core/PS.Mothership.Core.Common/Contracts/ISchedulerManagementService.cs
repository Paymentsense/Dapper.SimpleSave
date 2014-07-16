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
        void ScheduleNewJob(string triggerName, string jobName, GenSchedulerJobGroupEnum jobGroupName,
            string jobClass, IntervalUnit occurance, string interval, DateTimeOffset startTime, IEnumerable<DayOfWeek> dayOfWeek = null);

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
        
        [OperationContract]
        PagedList<JobProfileDto> GetJob(string jobName);

        [OperationContract]
        void ExecuteJobNow(string jobName);

        [OperationContract]
        void AddTriggerToJob(string triggerName, string jobName,
            IntervalUnit occurance, string interval, DateTimeOffset startTime, IEnumerable<DayOfWeek> dayOfWeek = null);

        [OperationContract]
        void DeleteTrigger(string triggerName);

        [OperationContract]
        void RescheduleTrigger(string triggerName, IntervalUnit occurance, string interval, DateTimeOffset startTime,
            IEnumerable<DayOfWeek> dayOfWeek = null);
    }
}
