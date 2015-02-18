using System;
using System.ServiceModel;

namespace PS.Mothership.Core.Common.Contracts
{
    public interface IDiallerServiceCallback
    {
        [OperationContract]
        bool CheckUserAvailability(Guid userGuid);
    }
}
