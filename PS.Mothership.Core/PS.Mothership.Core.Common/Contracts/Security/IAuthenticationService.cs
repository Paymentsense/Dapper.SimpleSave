using System.Collections.Generic;
using System.ServiceModel;
using PS.Mothership.Core.Common.Dto;

namespace PS.Mothership.Core.Common.Contracts.Security
{
    [ServiceContract(Name = "AuthenticationService")]
    public interface IAuthenticationService
    {
        [OperationContract]
        AccountDto Login(LoginCredentialsDto loginCredentialsDto);

        [OperationContract]
        AccountDto Register(RegisterDto registerDto);

        [OperationContract]
        AccountDto GetUserAccount(long userId);

        [OperationContract]
        IEnumerable<UserProfileDto> GetUserProfile(long departmentId, UserProfileDto accessUserProfile, DataRequestDto dataRequestDto);

        [OperationContract]
        IEnumerable<UserGroupDto> GetGroups(long userId);

        [OperationContract]
        IEnumerable<UserRoleDto> GetRoles(long userId);

        [OperationContract]
        IEnumerable<UserRoleDto> GetRolesFromRelationShip(long userId);

        [OperationContract(Name = "GetPermissionsById")]
        IEnumerable<UserPermissionDto> GetPermissions(long userId, long resourcesId, bool ignoreUser=true);

        [OperationContract(Name = "GetPermissionsByName")]
        IEnumerable<UserPermissionDto> GetPermissions(long userId, string resourcesName, bool ignoreUser=true);
    }
}
