using PS.Mothership.Core.Common.Template.Usr;
using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.User
{
    [DataContract]
    public class UserDto
    {
        [DataMember]
        public Guid UserGuid { get; set; }
        [DataMember]
        public UsrStatusOptionFlagEnum UserStatusOptionFlags { get; set; }
        [DataMember]
        public string LoginName { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public Guid EmailAddressGuid { get; set; }
        [DataMember]
        public UsrUserTypeEnum UserTypeKey { get; set; }
        [DataMember]
        public Guid LoginGuid { get; set; }
        [DataMember]
        public Guid UserStatusTrnGuid { get; set; }
        [DataMember]
        public Guid PhoneGuid { get; set; }
        [DataMember]
        public long V1UserId { get; set; }
        [DataMember]
        public int PasswordFailureCount { get; set; }
    }
}
