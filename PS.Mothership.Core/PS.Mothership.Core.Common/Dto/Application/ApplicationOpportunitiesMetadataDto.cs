using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Merchant;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Dto.Application
{
    [DataContract]
    public class ApplicationOpportunitiesMetadataDto
    {
        [DataMember]
        public IEnumerable<OfferSalesChannelDto> SalesChannels { get; set; }

        [DataMember]
        public IEnumerable<GenCountry> Countries { get; set; } 
    }
}
