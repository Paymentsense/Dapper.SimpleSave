using System.ServiceModel;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(CallbackContract = typeof(IDiallerTaskServiceCallback))]
    public interface IDiallerTaskService
    {
        //This is only here because wcf needs atleast one operation contract per service contract
        [OperationContract]
        void Post();
    }
}
