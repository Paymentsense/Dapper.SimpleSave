using PS.Mothership.Core.Common.Template.Gen;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class ApplicationDetailLocationDto
    {
        [DataMember]
        public Guid LocationGuid { get; set; }

        [DataMember]
        public Guid ApplicationGuid { get; set; }

        [DataMember]
        public IList<LocationProductMstDto> Opportunities { get; set; }
    }
}
