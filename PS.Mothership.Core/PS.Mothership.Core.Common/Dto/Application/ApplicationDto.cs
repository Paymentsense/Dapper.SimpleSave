using PS.Mothership.Core.Common.Template.Gen;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class ApplicationDto
    {
        [DataMember]
        public Guid ApplicationGuid { get; set; }

        [DataMember]
        public ApplicationOpportunitiesDto Opportunities { get; set; }

        [DataMember]
        public ApplicationDetailsDto Details { get; set; }
    }
}
