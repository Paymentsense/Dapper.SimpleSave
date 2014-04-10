using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Dto.Customer;
using PS.Mothership.Core.Common.Dto;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name = "ProspectCustomerService")]
    public interface IProspectCustomerService
    {
        /// <summary>
        ///     Add customer
        /// </summary>
        /// <param name="prospectCustDto"></param>
        /// <param name="updateSessionGuid"></param>
        /// <returns></returns>
        [OperationContract]
        ProspectCustResponseDto AddCustomer(ProspectCustDto prospectCustDto, Guid updateSessionGuid);

        /// <summary>
        ///     Get similiar customers
        /// </summary>
        /// <param name="prospectCustDto"></param>
        /// <returns></returns>
        [OperationContract]
        ICollection<ProspectCustDto> SimilarCustomers(ProspectCustDto prospectCustDto);


        ///<summary>
        ///     Get list of customers
        ///     Added by Alpesh
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        ICollection<ProspectCustDto> GetCustomers();
        ///<summary>
        ///     Get list of customers
        ///     Added by Alpesh
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        ICollection<FullAddressDto> GetCustomersAddress();
    }
}
