using System;
using System.ServiceModel;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract]
    public interface IIridiumService : IQuartzJobBase
    {
        [OperationContract]
        void SubmitToIridium(Guid opportunityGuid);

        //[OperationContract]
        //void ConfirmIridiumAccount(IridiumBo iridiumBo);

    }
}
