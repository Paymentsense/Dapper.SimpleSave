using System.ServiceModel;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(CallbackContract = typeof (IDiallerServiceCallback), Name = "DiallerService")]
    public interface IDiallerService
    {
    }
}
