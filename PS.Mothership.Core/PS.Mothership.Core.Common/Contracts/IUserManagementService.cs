using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Dto;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name = "UserManagementService")]
    public interface IUserManagementService
    {
        /// <summary>
        ///     Manage method used to both 
        ///     add and update a user information
        /// </summary>
        /// <param name="userAccountDto"></param>
        /// <returns></returns>
        [OperationContract]
        UserDto Manage(UserAccountDto userAccountDto);        
    }
}
