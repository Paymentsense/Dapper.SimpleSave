using PS.Mothership.Core.Common.Dto;
using PS.Mothership.Core.Common.Dto.Contact;
using PS.Mothership.Core.Common.Dto.DynamicRequest;
using System;
using System.Collections.Generic;
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

        [OperationContract]
        ICollection<CountryDto> Countries();

        [OperationContract]
        ICollection<CountyDto> Counties(int countryKey);

        [OperationContract]
        IEnumerable<PostcodeDto> Postcodes(FilterDto filter);
    }
}
