using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Constructs;
using PS.Mothership.Core.Common.Dto.DynamicRequest;
using PS.Mothership.Core.Common.Dto.Merchant;

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

        /// <summary>
        ///     Get similiar customers
        /// </summary>
        /// <param name="prospectDto"></param>
        /// <returns></returns>
        [OperationContract]
        ICollection<ProspectDto> SimilarCustomers(ProspectDto prospectDto);
        
        [OperationContract]
        ContactDto GetContact(Guid contactGuid);

        [OperationContract]
        ContactDto SaveContact(ContactDto contactDto);


        [OperationContract]
        PagedList<ProspectDto> GetProspectsByBusinessName(string businessName);

        [OperationContract]
        PagedList<ProspectDto> GetProspectsByFilter(DataRequestDto dataRequestDto);
    }
}
