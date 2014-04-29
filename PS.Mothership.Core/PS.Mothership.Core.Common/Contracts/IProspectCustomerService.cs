using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Dto.Customer;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name = "ProspectCustomerService")]
    public interface IProspectCustomerService
    {
        /// <summary>
        ///     Add customer
        /// </summary>
        /// <param name="prospectDto"></param>
        /// <param name="updateSessionGuid"></param>
        /// <returns></returns>
        [OperationContract]
        ProspectResponseDto AddCustomer(ProspectDto prospectDto, Guid updateSessionGuid);

        /// <summary>
        ///     Get similiar customers
        /// </summary>
        /// <param name="prospectDto"></param>
        /// <returns></returns>
        [OperationContract]
        ICollection<ProspectDto> SimilarCustomers(ProspectDto prospectDto);
    }
}
