using PS.Mothership.Core.Common.Constructs;
using PS.Mothership.Core.Common.Dto;
using PS.Mothership.Core.Common.Dto.DynamicRequest;
using PS.Mothership.Core.Common.Dto.Groups;
using PS.Mothership.Core.Common.Dto.Roles;
using PS.Mothership.Core.Common.Dto.User;
using System;
using System.ServiceModel;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name = "UserManagementService")]
    public interface IUserManagementService
    {
        [OperationContract]
        UserLoginResultDto AddUser(UserProfileDto userProfileDto, Guid updateSessionGuid);
        [OperationContract]
        UserLoginResultDto UpdateUser(UserProfileDto userProfileDto, Guid updateSessionGuid);
        //[OperationContract]
        //PagedList<UserProfileDto> GetUsers(DataRequestDto dataRequestDto);
        [OperationContract]
        UserProfileDto GetUser(Guid userGuid);
        [OperationContract]
        PagedList<UserListDto> GetSimilarNames(DataRequestDto dataRequestDto, UserProfileDto userProfileDto);
        // TODO: this operation isn't used anywhere on the front end but possibly should be for searching.
        //[OperationContract]
        //PagedList<UserProfileDto> QuickSearch(SearchDto searchInput);
        [OperationContract]
        UserRolesDto GetRolesForUser(Guid userGuid);
        [OperationContract]
        void RemoveRoleFromUser(BasicUserRoleDto userRole);
        [OperationContract]
        void AddRoleToUser(BasicUserRoleDto userRole);
        [OperationContract]
        void RemoveRole(RoleDto role);
        [OperationContract]
        void AddRole(RoleDto role);
        [OperationContract]
        PagedList<RoleDto> GetRoles(SearchDto searchInput);
        [OperationContract]
        PagedList<GroupDto> GetAllRolesAndGroups(SearchDto searchInput);
        [OperationContract]
        GroupDto GetRolesForGroup(Guid groupGuid);
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
        void AddGroupToUser(Dto.Groups.UserGroupDto userGroup);
        [OperationContract]
        void RemoveGroupFromUser(PS.Mothership.Core.Common.Dto.Groups.UserGroupDto userGroup);
        [OperationContract]
        GroupDto GetGroupForUser(Guid userGuid);
        [OperationContract]
        InheritedRolesDto GetInheritedRoles(RoleDto role);
        [OperationContract]
        UserRolesDto RolesForUserAvailableAndAssigned(Guid userGuid);
        [OperationContract]
        PagedList<UserListDto> GetUsersList(DataRequestDto dataRequestDto);
    }
}
