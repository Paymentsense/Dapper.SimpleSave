using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace PS.Mothership.Core.Common.Dto.Application
{
    [DataContract]
    public class ApplicationDetailLocationDto
    {
        [DataMember]
        public Guid LocationGuid { get; set; }

        [DataMember]
        public Guid ApplicationGuid { get; set; }

        [DataMember]
        public string LocationReference { get; set; }

        [DataMember]
        public string BusinessName { get; set; }

        [DataMember]
        public FullAddressDto TradingAddress { get; set; }

        [DataMember]
        public IList<ApplicationDetailLocationProductDto> ApplicationDetailLocationProduct { get; set; }


    }
}
