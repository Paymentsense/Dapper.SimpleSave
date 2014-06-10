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

        /// <summary>
        ///     Add Prospect
        /// </summary>
        /// <param name="prospectDto"></param>
        /// <returns></returns>
        [OperationContract]
        ProspectResponseDto AddProspect(ProspectDto prospectDto);

        [OperationContract]
        void AddProspectContact(MerchantContactDto dto);

        [OperationContract]
        void RemoveProspectContact(MerchantContactDto dto);
        
        [OperationContract]
        void AddProspectAddress(MerchantAddressDto dto);

        [OperationContract]
        void RemoveProspectAddress(MerchantAddressDto dto);

        /// <summary>
        ///     Get similiar customers
        /// </summary>
        /// <param name="prospectDto"></param>
        /// <returns></returns>
        [OperationContract]
        PagedList<ProspectDto> GetProspectsByFilter(DataRequestDto dataRequestDto);

        [OperationContract]
        PagedList<ProspectAddressDto> GetProspectsAddressByFilter(DataRequestDto dataRequestDto);

    }
}
