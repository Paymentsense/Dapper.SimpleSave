using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Constructs;
using PS.Mothership.Core.Common.Dto.DynamicRequest;
using PS.Mothership.Core.Common.Dto.Merchant;
using PS.Mothership.Core.Common.Dto;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name = "ProspectCustomerService")]
    public interface IProspectCustomerService
    {
        [OperationContract]
        ProspectDto GetProspect(Guid merchantGuid);

        [OperationContract]
        ProspectResponseDto AddProspect(AddProspectDto prospectDto);

        [OperationContract]
        ProspectDetailsDto UpdateProspect(ProspectDetailsDto dto);

        [OperationContract]
        void AddProspectContact(MerchantContactDto dto);

        [OperationContract]
        void RemoveProspectContact(MerchantContactDto dto);

        [OperationContract]
        void AddProspectAddress(MerchantAddressDto dto);

        [OperationContract]
        void RemoveProspectAddress(MerchantAddressDto dto);

        [OperationContract]
        PagedList<ProspectDto> GetProspectsByFilter(DataRequestDto dataRequestDto);

        [OperationContract]
        PagedList<MerchantListDto> GetMerchantsByFilter(DataRequestDto dataRequestDto);

        [OperationContract]
        PagedList<ProspectAddressDto> GetSimilarMerchants(FullAddressDto dto);

        [OperationContract]
        PagedList<ProspectAddressDto> QuickSearch(SearchDto dto);

        [OperationContract]
        PagedList<ProspectAddressDto> AdvancedSearch(MerchantDataRequestDto dto);

    }
}
