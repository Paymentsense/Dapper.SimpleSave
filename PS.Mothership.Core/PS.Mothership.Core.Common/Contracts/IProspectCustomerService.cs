using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Dto.Merchant;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name = "ProspectCustomerService")]
    public interface IProspectCustomerService
    {
        [OperationContract]
        ProspectDto GetProspect(Guid id);

        /// <summary>
        ///     Add customer
        /// </summary>
        /// <param name="prospectDto"></param>
        /// <param name="prospectDto"></param>
        /// <returns></returns>
        [OperationContract]
        ProspectResponseDto AddProspect(ProspectDto prospectDto);

        /// <summary>
        ///     Get similiar customers
        /// </summary>
        /// <param name="prospectDto"></param>
        /// <returns></returns>
        [OperationContract]
        ICollection<ProspectDto> SimilarCustomers(ProspectDto prospectDto);
    }
}
