using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Dto.Customer;
using PS.Mothership.Core.Common.Dto;
<<<<<<< HEAD
using PS.Mothership.Core.Common.Dto.DynamicRequest;
=======
>>>>>>> f68e7f962612c7c2a4a31d0095b6d3d24f11681f

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name = "ProspectCustomerService")]
    public interface IProspectCustomerService
    {
        [OperationContract]
        ProspectCustDto GetCustomer(Guid prospectGuid);

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

<<<<<<< HEAD
        ///<summary>
        ///     Get list of filtered customers
        ///     Added by Alpesh
        /// </summary>  
        [OperationContract]
        IEnumerable<ProspectCustDto> QuickSearch(SearchDto searchInput);

        ///<summary>
        ///     Get list of companies
=======

        ///<summary>
        ///     Get list of customers
>>>>>>> f68e7f962612c7c2a4a31d0095b6d3d24f11681f
        ///     Added by Alpesh
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        ICollection<ProspectCustDto> GetCustomers();
<<<<<<< HEAD

        ///<summary>
        ///     Get list of companies with addresses
=======
        ///<summary>
        ///     Get list of customers
>>>>>>> f68e7f962612c7c2a4a31d0095b6d3d24f11681f
        ///     Added by Alpesh
        /// </summary>
        /// <returns></returns>
        [OperationContract]
<<<<<<< HEAD

        IEnumerable<ProspectCustDto> GetCustomersAddress(DataRequestDto dataRequestDto);

        [OperationContract]
        FullAddressDto UpdateCustomerAddress(Guid id, FullAddressDto dto);

        [OperationContract]
        ContactDto UpdateCustomerContact(Guid id, ContactDto dto);
=======
        ICollection<FullAddressDto> GetCustomersAddress();
>>>>>>> f68e7f962612c7c2a4a31d0095b6d3d24f11681f
    }
}
