using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.Experian
{
    [DataContract]
    public class ExperianIdCheckTrnDto
    {
        [DataMember]
        public Guid ExperianIdCheckGuid { get; set; }

        [DataMember]
        public Guid ContactGuid { get; set; }

        [DataMember]
        public IdentityCheckRequestDto IdentityCheckRequestDto { get; set; }

        [DataMember]
        public IdentityCheckResponseDto IdentityCheckResponseDto { get; set; }

        [DataMember]
        public DateTimeOffset ExperianCheckRunOn { get; set; }

    }
}
