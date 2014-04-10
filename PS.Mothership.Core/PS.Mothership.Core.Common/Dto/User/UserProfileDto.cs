using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using PS.Mothership.Core.Common.Dto.Groups;
using PS.Mothership.Core.Common.Template.Usr;

namespace PS.Mothership.Core.Common.Dto.User
{
    /// <summary>
    /// User Proile Dto
    /// </summary>
    /// <remarks>
    ///     1. For caching purpose, we use the object as cache key, if the client want
    ///     to ignore certain property which are not any value, decorate those properties
    ///     with JsonIgnore, as the cache server convert the object to json for generating key
    /// </remarks>
    [DataContract]
    public class UserProfileDto
    {        
        [DataMember]
        public Guid UserGuid { get; set; }
        [DataMember]
        public string LoginName { get; set; }
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Initial { get; set; }
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public bool IsLoggedIn { get; set; }
        [DataMember]
        public bool IsPersistent { get; set; }
        [DataMember]
        public bool IsValid { get; set; }
        [DataMember]
        public bool IsDefining { get; set; }
        [DataMember]
        public bool CanImpersonate { get; set; }

        [DataMember]
        public bool IsImpersonate { get; set; }
        [DataMember]
        public Guid ImpersonateGuid { get; set; }

        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public int TotalCount { get; set; } // gives the total count based on selection criteria
        [DataMember]
        public string ValidationCode { get; set; }
        [DataMember]
        public ICollection<string> AlternateLoginNames { get; set; }         
        [DataMember]
        public string ChosenLoginName { get; set; }
        [DataMember]
        public ICollection<UserProfileDto> SimilarNames { get; set; }
                
        [JsonIgnore]     
        [DataMember]
        public Guid SessionId { get; set; }


        [DataMember]
        public UsrLoginResultEnum Status { get; set; }
        [DataMember]
        public UsrUserTypeEnum UserType { get; set; }

        private UsrStatusOptionFlagEnum _statusOptions = UsrStatusOptionFlagEnum.None;
        [DataMember]
        public UsrStatusOptionFlagEnum StatusOptions
        {
            get { return _statusOptions; }
            set { _statusOptions = value; }
        }
        
        private UsrUserStatusEnum _userStatus = UsrUserStatusEnum.NewHire;        
        [DataMember]
        public UsrUserStatusEnum UserStatus
        {
            get { return _userStatus; }
            set { _userStatus = value; }

        }
        [DataMember]
        public bool UnlockAccount { get; set; }
        [DataMember]
        public bool ResetPassword { get; set; }
        [DataMember]
        public RoleDto DefiningRole { get; set; }
        [DataMember]
        public GroupDto Group { get; set; }
        [DataMember]
        public Guid SipAccountGuid { get; set; }

        public List<GroupDto> Groups { get; set; }
        public List<RoleDto> AllDefiningRoles { get; set; }
    }
}