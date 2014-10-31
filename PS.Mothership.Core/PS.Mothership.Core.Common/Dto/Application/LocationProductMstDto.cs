using PS.Mothership.Core.Common.Template.Gen;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class LocationProductMstDto
    {
        [DataMember]
        public Guid LocationProductGuid { get; set; }

        [DataMember]
        public Guid LocationGuid { get; set; }

        [DataMember]
        public Guid OpportunityGuid { get; set; }
      
    }
}
