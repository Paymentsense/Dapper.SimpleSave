using PS.Mothership.Core.Common.Dto;
using PS.Mothership.Core.Common.Dto.Contact;
using PS.Mothership.Core.Common.Dto.DynamicRequest;
using PS.Mothership.Core.Common.Template.Gen;
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
        ICollection<GenCountryEnum> Countries();

        [OperationContract]
        ICollection<CountyDto> Counties(GenCountryEnum countryKey);

        [OperationContract]
        IEnumerable<PostcodeDto> Postcodes(FilterDto filter);
    }
}
