using PS.Mothership.Core.Common.Constructs;
using PS.Mothership.Core.Common.Dto;
using PS.Mothership.Core.Common.Dto.DynamicRequest;
using PS.Mothership.Core.Common.Dto.Merchant;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name = "ProspectCustomerService")]
    public interface IProspectCustomerService
    {
        [OperationContract]
        IEnumerable<MerchantOfferDto> GetLatestOffersForMerchant(Guid merchantGuid);

        [OperationContract]
        ProspectDto GetProspect(Guid merchantGuid);

        [OperationContract]
        ProspectResponseDto AddProspect(AddProspectDto prospectDto);

        [OperationContract]
        ProspectDto UpdateProspect(ProspectDto prospectDto);

        [OperationContract]
        void AddProspectContact(MerchantContactDto dto);

        [OperationContract]
        void RemoveProspectContact(MerchantContactDto dto);

        [OperationContract]
        void AddProspectAddress(MerchantAddressDto dto);

        [OperationContract]
        void RemoveProspectAddress(MerchantAddressDto dto);
        
        [OperationContract]
        PagedList<MerchantListDto> GetMerchantsByFilter(DataRequestDto dataRequestDto);

        [OperationContract]
        PagedList<MerchantListDto> GetSimilarMerchants(FullAddressDto dto);

        [OperationContract]
        PagedList<MerchantListDto> QuickSearch(SearchDto dto);

        [OperationContract]
        PagedList<ProspectAddressDto> AdvancedSearch(MerchantDataRequestDto dto);

    }
}
