using System;
using System.ServiceModel;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract]
    public interface IDiallerTaskServiceCallback
    {
        [OperationContract]
        bool CheckUserAvailability(Guid userGuid);
    }
}
