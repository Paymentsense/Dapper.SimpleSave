using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Login
{
    [DataContract]
    public class ChangePasswordDto
    {
        [DataMember] 
        public string UserName { get; set; }
        [DataMember]
        public string OldPassword { get; set; }
        [DataMember]
        public string NewPassword { get; set; }
        [DataMember]
        public string ConfirmPassword { get; set; }
    }
}
