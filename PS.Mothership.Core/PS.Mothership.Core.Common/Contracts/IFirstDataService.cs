using System;
using System.ServiceModel;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract]
    public interface IFirstDataService
    {
        [OperationContract]
        void QueueFirstDataApplication(Guid applicationGuid);


    }
}
