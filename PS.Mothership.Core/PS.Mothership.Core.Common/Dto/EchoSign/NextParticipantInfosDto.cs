using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.EchoSign
{
    [DataContract]
    public class NextParticipantInfosDto
    {
        [DataMember]
        public DateTime WaitingSince { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
