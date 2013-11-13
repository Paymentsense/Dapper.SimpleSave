using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class ChangePasswordResult
    {
        [DataMember]
        public bool IsSuccess { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
    }
}