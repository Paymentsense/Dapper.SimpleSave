using System.ServiceModel;
using PS.Mothership.Core.Common.Dto;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract]
    public interface IAddressService
    {
        [OperationContract]
        FullAddressDto RetrieveById(string postCodeAnywhereAddressId);
    }
}