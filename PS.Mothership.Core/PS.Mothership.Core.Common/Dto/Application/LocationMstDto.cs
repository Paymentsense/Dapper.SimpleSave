using PS.Mothership.Core.Common.Template.Gen;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class LocationMstDto
    {
        [DataMember]
        public Guid LocationGuid { get; set; }

        [DataMember]
        public string LocationReference { get; set; }

        [DataMember]
        public Guid ApplicationGuid { get; set; }

        [DataMember]
        public IList<LocationProductMstDto> LocationProducts { get; set; }
    }
}
