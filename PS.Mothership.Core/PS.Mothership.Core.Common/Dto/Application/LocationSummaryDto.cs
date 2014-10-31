using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Merchant;

namespace PS.Mothership.Core.Common.Dto.Application
{
    [DataContract]
    public class LocationSummaryDto
    {
        [DataMember]
        public Guid LocationGuid { get; set; }

        [DataMember]
        public IList<OpportunitySummaryDto> Opportunities { get; set; }


    }
}
