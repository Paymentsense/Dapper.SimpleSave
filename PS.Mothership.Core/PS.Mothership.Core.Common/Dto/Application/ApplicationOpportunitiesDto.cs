using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Dto.Application
{
    [DataContract]
    public class ApplicationOpportunitiesDto
    {
        [DataMember]
        public Guid ApplicationGuid { get; set; }

        [DataMember]
        public GenCountryEnum CountryKey { get; set; }

        [DataMember]
        public Guid SalesChannelGuid { get; set; }

        [DataMember]
        public IList<ApplicationOpportunityLocationDto> Locations { get; set; }

        

        

    }
}
