using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Merchant;

namespace PS.Mothership.Core.Common.Dto.Application
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
