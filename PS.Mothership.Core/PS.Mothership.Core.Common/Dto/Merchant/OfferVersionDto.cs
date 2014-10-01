using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class OfferVersionDto
    {
        [DataMember]
        public Guid OfferGuid { get; set; }

        [DataMember]
        public string Version { get; set; }
    }
}
