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
        [OperationContract]
        UserDto AddUser(UserProfileDto userProfileDto);
        [OperationContract]
        UserDto UpDateUser(UserProfileDto userProfileDto);
        [OperationContract]
        IEnumerable<UserProfileDto> GetUsers(DataRequestDto dataRequestDto);
        [OperationContract]
        UserProfileDto GetUser(Guid userGuid);
        [OperationContract]
        ICollection<UserProfileDto> GetSimilarNames(UserProfileDto userProfileDto); 
        [OperationContract]
        IEnumerable<UserProfileDto> QuickSearch(SearchDto searchInput);
        [OperationContract]
        User GetRolesForUser(Guid userGuid);
        [OperationContract]
        UserRoles GetRolesForUsers();
        [OperationContract]
        void RemoveRoleFromUser(UserRole userRole);
        [OperationContract]
        void AddRoleToUser(UserRole userRole);
        [OperationContract]
        void RemoveRole(Role role);
        [OperationContract]
        void AddRole(Role role);
        [OperationContract]
        IEnumerable<Role> GetRoles();
        [OperationContract]
        GroupRoles GetAllRolesAndGroups();
        [OperationContract]
        Group GetRolesForGroup(long groupId);
        [OperationContract]
        void RemoveGroup(GroupDesc groupDesc);
        [OperationContract]
        void AddOrUpdateGroup(GroupDesc groupDesc);
        [OperationContract]
        void RemoveRoleFromGroup(GroupRole groupRole);
        [OperationContract]
        void AddRoleToGroup(GroupRole groupRole);
        [OperationContract]
        void AddInheritRole(RoleInheritance roleInheritance);
        [OperationContract]
        void RemoveInheritRole(RoleInheritance roleInheritance);
        [OperationContract]
        void AddGroupToUser(UserGroup userGroup);
        [OperationContract]
        void RemoveGroupFromUser(UserGroup userGroup);
        [OperationContract]
        Group GetGroupForUser(Guid userId);
        [OperationContract]
        InheritedRoles GetInheritedRoles(Role role);
    }
}
