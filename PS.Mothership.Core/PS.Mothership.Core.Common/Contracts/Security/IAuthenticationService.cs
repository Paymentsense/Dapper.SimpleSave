using System;
using System.Collections.Generic;
using System.ServiceModel;
using PS.Mothership.Core.Common.Constructs;
using PS.Mothership.Core.Common.Dto;
using PS.Mothership.Core.Common.Dto.Groups;
using PS.Mothership.Core.Common.Dto.Login;
using PS.Mothership.Core.Common.Dto.Roles;
using PS.Mothership.Core.Common.Dto.DynamicRequest;
using PS.Mothership.Core.Common.Dto.User;
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
        PagedList<UserImpersonationDto> GetUserImpersonations(long departmentId, UserProfileDto accessUserProfile, DataRequestDto dataRequestDto);

        [OperationContract]
        PagedList<GroupDto> GetGroups(Guid userGuid);

        [OperationContract]
        PagedList<UserRoleDto> GetRoles(Guid userGuid);

        [OperationContract]
        PagedList<UserRoleDto> GetRolesFromRelationShip(Guid userGuid);

        [OperationContract]
        PagedList<ResourceRolePermissionsDto> GetPermissionsByResource(Guid userGuid, UsrResourceEnum resource);

        [OperationContract]
        PagedList<ResourceRolePermissionsDto> GetResourcePermissionsByCollection(IList<UsrResourceEnum> resource);

        [OperationContract]
        PagedList<ResourceRolePermissionsDto> GetPermissionsByResourceType(Guid userGuid, UsrResourceTypeEnum resourceType);

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
        bool CodeExists(Guid userGuid, string validationCode);

        [OperationContract]
        bool VerifyRemoteAccess(Guid userGuid, string validationCode);

        [OperationContract]
        bool PasswordReset(string userName);

        [OperationContract]
        ChangePasswordResultDto ChangePassword(ChangePasswordDto changePasswordDto);

        [OperationContract]
        void LogOff(Guid userGuid);
    }
}
