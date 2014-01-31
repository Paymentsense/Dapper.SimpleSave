using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Login
{
    [DataContract]
    public class ChangePasswordResultDto
    {
        [DataMember]
        public bool IsSuccess { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
    }
}