using System;
using System.ServiceModel;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract]
    public interface IDiallerTaskService
    {
        [OperationContract]
        bool CheckUserAvailability(Guid userGuid);
    }
}
