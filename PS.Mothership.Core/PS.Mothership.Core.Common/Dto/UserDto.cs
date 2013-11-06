using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Usr;

namespace PS.Mothership.Core.Common.Dto
{
    public class UserDto
    {
        [DataMember]
        public LoginResultEnum Status { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public UserAccountDto UserAccountDto { get; set; }        
    }
}
