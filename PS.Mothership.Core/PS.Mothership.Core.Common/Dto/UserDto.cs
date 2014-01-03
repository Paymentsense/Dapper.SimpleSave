using PS.Mothership.Core.Common.Template.Usr;
using System.Net;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{
    public class UserDto
    {
        // To manage on client side
        private HttpStatusCode _statusCode = HttpStatusCode.OK;

        public HttpStatusCode StatusCode
        {
            get { return _statusCode; }
            set { _statusCode = value; }
        }

        [DataMember]
        public LoginResultEnum Status { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public UserProfileDto UserProfileDto { get; set; }
    }
}
