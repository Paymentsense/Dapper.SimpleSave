using PS.Mothership.Core.Common.Dto;
using System;
using System.ServiceModel;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name = "AddressManagementService")]
    public interface IAddressManagementService
    {
        [OperationContract]
        FullAddressDto GetAddress(Guid addressGuid);

        [OperationContract]
        FullAddressDto SaveAddress(FullAddressDto addressDto);
    }
}
