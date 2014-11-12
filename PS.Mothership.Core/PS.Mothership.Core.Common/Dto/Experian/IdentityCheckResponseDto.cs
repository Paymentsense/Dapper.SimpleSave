using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.Experian
{
    [DataContract]
    public class IdentityCheckResponseDto
    {
        [DataMember]
        public string AuthenticationIndex { get; set; }
        [DataMember]
        public string ExperianReferenceNumber { get; set; }
        [DataMember]
        public bool DidVerificationErrorOccur { get; set; }
        [DataMember]
        public string CustomerNo { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public byte[] FileBytes { get; set; }
        [DataMember]
        public IdentityResultBlockDto ResultsBlock { get; set; }
    }
}
