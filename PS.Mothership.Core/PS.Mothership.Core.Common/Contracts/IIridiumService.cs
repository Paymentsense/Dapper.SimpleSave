using System;
using System.ServiceModel;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract]
    public interface IIridiumService
    {
        [OperationContract]
        void SubmitToIridium(Guid opportunityGuid);

    }
}
