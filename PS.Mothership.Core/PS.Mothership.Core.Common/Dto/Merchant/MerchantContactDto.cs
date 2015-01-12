using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class MerchantContactDto
    {
        [DataMember]
        public Guid MerchantGuid { get; set; }

        [DataMember]
        public ContactDto Contact { get; set; }
    }
}
