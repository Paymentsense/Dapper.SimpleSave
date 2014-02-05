using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Dto;
using PS.Mothership.Core.Common.Dto.DynamicRequest;
using PS.Mothership.Core.Common.Dto.Groups;
using PS.Mothership.Core.Common.Dto.Login;
using PS.Mothership.Core.Common.Dto.Roles;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name = "UserManagementService")]
    public interface IUserManagementService 
    {        
        [OperationContract]
        PS.Mothership.Core.Common.Dto.Login.UserDto AddUser(UserProfileDto userProfileDto);
        [OperationContract]
        PS.Mothership.Core.Common.Dto.Login.UserDto UpDateUser(UserProfileDto userProfileDto);
        [OperationContract]
        IEnumerable<UserProfileDto> GetUsers(DataRequestDto dataRequestDto);
        [OperationContract]
        UserProfileDto GetUser(Guid userGuid);
        [OperationContract]
        ICollection<UserProfileDto> GetSimilarNames(UserProfileDto userProfileDto); 
        [OperationContract]
        IEnumerable<UserProfileDto> QuickSearch(SearchDto searchInput);
        [OperationContract]
        PS.Mothership.Core.Common.Dto.Roles.UserDto GetRolesForUser(Guid userGuid);
        [OperationContract]
        IEnumerable<PS.Mothership.Core.Common.Dto.Roles.UserDto> GetRolesForUsers();
        [OperationContract]
        void RemoveRoleFromUser(BasicUserRoleDto userRole);
        [OperationContract]
        void AddRoleToUser(BasicUserRoleDto userRole);
        [OperationContract]
        void RemoveRole(RoleDto role);
        [OperationContract]
        void AddRole(RoleDto role);
        [OperationContract]
        IEnumerable<RoleDto> GetRoles(SearchDto searchInput);
        [OperationContract]
        List<GroupDto> GetAllRolesAndGroups();
        [OperationContract]
        GroupDto GetRolesForGroup(long groupId);
        [OperationContract]
        void RemoveGroup(GroupDescDto groupDesc);
        [OperationContract]
        void AddOrUpdateGroup(GroupDescDto groupDesc);
        [OperationContract]
        void RemoveRoleFromGroup(GroupRoleDto groupRole);
        [OperationContract]
        void AddRoleToGroup(GroupRoleDto groupRole);
        [OperationContract]
        void AddInheritRole(RoleInheritanceDto roleInheritance);
        [OperationContract]
        void RemoveInheritRole(RoleInheritanceDto roleInheritance);
        [OperationContract]
        void AddGroupToUser(PS.Mothership.Core.Common.Dto.Groups.UserGroupDto userGroup);
        [OperationContract]
        void RemoveGroupFromUser(PS.Mothership.Core.Common.Dto.Groups.UserGroupDto userGroup);
        [OperationContract]
        GroupDto GetGroupForUser(Guid userId);
        [OperationContract]
        InheritedRolesDto GetInheritedRoles(RoleDto role);
        [OperationContract]
        PS.Mothership.Core.Common.Dto.Roles.UserDto RolesForUserAvailableAndAssigned(Guid userGuid);
        [OperationContract]
        IEnumerable<RecStatusDto> GetAllStatuses();
    }
}
