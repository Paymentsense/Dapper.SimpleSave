using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    [DataContract(Name = "MessageDetails", Namespace = "http://www.govtalk.gov.uk/schemas/govtalk/govtalkheader")]
    public class ResponseMessageDetailsDto
    {
        public ResponseMessageDetailsDto() { }

        [DataMember(Name = "Class", IsRequired = true, Order = 1)]
        public string Class { get; set; }

        [DataMember(Name = "Qualifier", IsRequired = true, Order = 2)]
        public string Qualifier { get; set; }

        [DataMember(Name = "TransactionID", IsRequired = true, Order = 3)]
        public string TransactionID { get; set; }

        [DataMember(Name = "GatewayTimestamp", IsRequired = true, Order = 4)]
        public string GatewayTimestamp { get; set; }
    }
}
