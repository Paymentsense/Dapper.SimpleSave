using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Dto.Application
{
    [DataContract]
    public class ApplicationSummaryDto
    {
        [DataMember]
        public Guid ApplicationGuid { get; set; }

        [DataMember]
        public string Reference { get; set; }

        [DataMember]
        public double TotalLtr { get; set; }

        [DataMember]
        public string UpdateUsername { get; set; }

        [DataMember]
        public DateTimeOffset UpdateDate { get; set; }

        [DataMember]
        public Guid UpdateSessionGuid { get; set; }

        [DataMember]
        public ApplicationStatusDto ApplicationStatus { get; set; }

        [DataMember]
        public IList<LocationSummaryDto> Locations { get; set; }
    };
}
