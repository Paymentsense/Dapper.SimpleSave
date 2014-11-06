using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Merchant;

namespace PS.Mothership.Core.Common.Dto.Application
{
    [DataContract]
    public class LocationDto
    {
        [DataMember]
        public Guid LocationGuid { get; set; }

        [DataMember]
        public string LocationReference { get; set; }

        [DataMember]
        public Guid ApplicationGuid { get; set; }

        [DataMember]
        public string BusinessName { get; set; }

        [DataMember]
        public Guid TradingAddressGuid { get; set; }

        [DataMember]
        public IList<LocationProductDto> LocationProducts { get; set; }
    }
}
