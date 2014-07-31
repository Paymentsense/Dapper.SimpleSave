using PS.Mothership.Core.Common.Constructs;
using PS.Mothership.Core.Common.Dto.DynamicRequest;
using PS.Mothership.Core.Common.Dto.SchedulerManagement;
using PS.Mothership.Core.Common.Template.Gen;
using System.ServiceModel;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name = "SchedulerManagementService")]
    public interface ISchedulerManagementService
    {
        [OperationContract]
        SchedulerServerInfoDto GetSchedulerServerInfo();

        [OperationContract]
        PagedList<JobProfileDto> GetJobs(DataRequestDto dataRequestDto);

        [OperationContract]
        JobProfileDto GetJob(GenSchedulerJobGroupEnum jobGroup, string jobName);

        [OperationContract]
        PagedList<TriggerProfileDto> GetTriggers(GenSchedulerJobGroupEnum jobGroup, string jobName, DataRequestDto dataRequestDto);

        [OperationContract]
        TriggerProfileDto GetTrigger(GenSchedulerJobGroupEnum jobGroup, string jobName, string triggerName);

        [OperationContract]
        void AddOrUpdateTrigger(GenSchedulerJobGroupEnum jobGroup, string jobName, TriggerProfileDto trigger);

        [OperationContract]
        void DeleteTrigger(GenSchedulerJobGroupEnum jobGroup, string jobName, string triggerName);

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
        void ExecuteJobNow(GenSchedulerJobGroupEnum jobGroup, string jobName);
    }
}
