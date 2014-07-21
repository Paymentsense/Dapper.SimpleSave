using System;
using Castle.Core.Logging;
using Quartz;

namespace PS.Mothership.Core.Common.Contracts
{
    public interface IQuartzJobBase : IJob
    {
        void ExecuteJob(IJobExecutionContext context);
    }

   
}
