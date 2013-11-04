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
        [OperationContract]
        Core.Common.Dto.User GetRolesForUser(int userId);
        [OperationContract]
        Core.Common.Dto.UserRoles GetRolesForUsers();
        [OperationContract]
        void RemoveRoleFromUser(Core.Common.Dto.UserRole userRole);
        [OperationContract]
        void AddRoleToUser(Core.Common.Dto.UserRole userRole);
        [OperationContract]
        void RemoveRole(Core.Common.Dto.Role role);
        [OperationContract]
        void AddRole(Core.Common.Dto.Role role);
        [OperationContract]
        IEnumerable<Core.Common.Dto.Role> GetRoles();
        [OperationContract]
        Core.Common.Dto.GroupRoles GetAllRolesAndGroups();
        [OperationContract]
        Core.Common.Dto.Group GetRolesForGroup(long groupId);
        [OperationContract]
        void RemoveGroup(Core.Common.Dto.GroupDesc groupDesc);
        [OperationContract]
        void AddOrUpdateGroup(Core.Common.Dto.GroupDesc groupDesc);
        [OperationContract]
        void RemoveRoleFromGroup(Core.Common.Dto.GroupRole groupRole);
        [OperationContract]
        void AddRoleToGroup(Core.Common.Dto.GroupRole groupRole);
    }
}
