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
        IList<AvailableJobGroupsEnum> GetAvailableJobGroups();

        [OperationContract]
        IList<JobGroupStateDto> GetActiveJobGroups();

        [OperationContract]
        IList<string> GetUnassignedJobs();

        [OperationContract]
        IJobDetail GetJobGroupDetail(string jobGroupName);

        [OperationContract]
        void ScheduleNewJob(AvailableJobGroupsEnum jobGroupName, string jobName, string jobClass, string triggerName, string cronExpression, DateTime startDate);

        [OperationContract]
        void PauseAllTriggers();

        [OperationContract]
        void ResumeAllTriggers();

        [OperationContract]
        void PauseJobGroup(string jobGroupName);

        [OperationContract]
        void ResumeJobGroup(string jobGroupName);

        [OperationContract]
        void PauseTrigger(string triggerName);

        [OperationContract]
        void ResumeTrigger(string triggerName);
    }
}
