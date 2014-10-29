using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Merchant;

namespace PS.Mothership.Core.Common.Dto.Application
{
    [DataContract]
    public class ApplicationOpportunitiesMetadataDto
    {
        [DataMember]
        public IEnumerable<OfferSalesChannelDto> SalesChannels { get; set; }
    }
}
