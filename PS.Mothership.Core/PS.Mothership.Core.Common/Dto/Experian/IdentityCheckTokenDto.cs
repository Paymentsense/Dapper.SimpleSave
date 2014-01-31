using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.Experian
{
    [DataContract]
    public class IdentityCheckTokenDto
    {
        [DataMember]
        public string Token { get; set; }

        [DataMember]
        public TimeSpan TokenTimeOut { get; set; }
    }
}
