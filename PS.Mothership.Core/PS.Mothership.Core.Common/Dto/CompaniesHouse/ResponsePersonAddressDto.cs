using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    [DataContract(Name = "PersonAddress", Namespace = "http://xmlgw.companieshouse.gov.uk/v1-0/schema")]
    public class ResponsePersonAddressDto
    {
        public ResponsePersonAddressDto() { }

        //[DataMember(Name = "AddressLines", IsRequired = true, Order = 1)]
        //public ResponseAddressLineList AddressLines { get; set; }

        [DataMember(Name = "AddressLine1", IsRequired = true, Order = 1)]
        public string AddressLine1 { get; set; }

        [DataMember(Name = "AddressLine2", IsRequired = false, Order = 2)]
        public string AddressLine2 { get; set; }

        [DataMember(Name = "PostTown", IsRequired = true, Order = 3)]
        public string PostTown { get; set; }

        [DataMember(Name = "County", IsRequired = true, Order = 4)]
        public string County { get; set; }

        [DataMember(Name = "Country", IsRequired = true, Order = 5)]
        public string Country { get; set; }

        [DataMember(Name = "Postcode", IsRequired = true, Order = 6)]
        public string Postcode { get; set; }
    }
}
