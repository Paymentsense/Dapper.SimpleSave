using System;
using System.Collections.Generic;
using System.ServiceModel;
using PS.Mothership.Core.Common.Dto;
using PS.Mothership.Core.Common.Dto.Login;
using PS.Mothership.Core.Common.Dto.Roles;
using PS.Mothership.Core.Common.Dto.DynamicRequest;
using PS.Mothership.Core.Common.Template.Usr;

namespace PS.Mothership.Core.Common.Contracts.Security
{
    [ServiceContract(Name = "AuthenticationService")]
    public interface IAuthenticationService
    {
        [OperationContract]
        AccountDto Login(LoginCredentialsDto loginCredentialsDto);
        
        [OperationContract]
        AccountDto GetUserAccount(Guid userGuid);

        [OperationContract]
        AccountDto GetImpersonatedAccount(UserProfileDto profileImpersonating, Guid userGuid);

        [OperationContract]
        IEnumerable<UserProfileDto> GetUserProfile(long departmentId, UserProfileDto accessUserProfile, DataRequestDto dataRequestDto);

        [OperationContract]
        IEnumerable<UserGroupDto> GetGroups(Guid userGuid);

        [OperationContract]
        IEnumerable<UserRoleDto> GetRoles(Guid userGuid);

        [OperationContract]
        IEnumerable<UserRoleDto> GetRolesFromRelationShip(Guid userGuid);

        [OperationContract]
        IEnumerable<ResourceRolePermissionsDto> GetPermissionsByResource(Guid userGuid, ResourceEnum resource);

        [OperationContract]
        IEnumerable<ResourceRolePermissionsDto> GetResourcePermissionsByCollection(IList<ResourceEnum> resource);

        [OperationContract]
        IEnumerable<ResourceRolePermissionsDto> GetPermissionsByResourceType(Guid userGuid, ResourceTypeEnum resourceType);

        [OperationContract]
        bool IsAccountLockedOut(Guid userGuid, int allowedPasswordAttempts);

        /// <summary>
        ///     For now have a interface to unlock any
        ///     account, but need to give access only to administrators
        /// </summary>        
        /// <param name="userGuid"></param>
        /// <returns></returns>
        [OperationContract]
        bool UnLockAccount(Guid userGuid);
        
        [OperationContract]
        string GenerateCode(Guid userGuid);
        
        [OperationContract]
        bool CodeExists(Guid userGuid, string verificationCode);

        [OperationContract]
        bool VerifyRemoteAccess(Guid userGuid, string verificationCode);

        [OperationContract]
        bool PasswordReset(string userName);

        [OperationContract]
        ChangePasswordResultDto ChangePassword(ChangePasswordDto changePasswordDto);
    }
}
