using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.EchoSign
{
    [DataContract]
    public class AppCredentialsDto
    {
        [DataMember]
        public string ApplicationId { get; set; }

        [DataMember]
        public string ApplicationSecret { get; set; }
    }
}
