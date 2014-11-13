using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

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
        public string LastModifiedBy { get; set; }

        [DataMember]
        public Guid LastUpdateSessionGuid { get; set; }

        [DataMember]
        public DateTimeOffset LastModifiedOn { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public IList<LocationSummaryDto> Locations { get; set; }

    }
}
