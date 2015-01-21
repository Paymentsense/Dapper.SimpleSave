using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Application
{
    [DataContract]
    public class ApplicationDetailsDto
    {
        [DataMember]
        public Guid ApplicationGuid { get; set; }

        [DataMember]
        public Guid MerchantGuid { get; set; }

        [DataMember]
        public LegalInfoDto LegalInfo { get; set; }
        
        [DataMember]
        public IEnumerable<ApplicationDetailLocationDto> ApplicationDetailLocation { get; set; }

    }
}
