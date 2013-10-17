using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class LoginCredentialsDto
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string IpAddress { get; set; }
        [DataMember]
        public bool IsPersistent { get; set; }
        [DataMember]
        public bool ValidationCode { get; set; }
    }
}