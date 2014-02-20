using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    [DataContract(Name = "Person", Namespace = "http://xmlgw.companieshouse.gov.uk/v1-0/schema")]
    public class ResponsePersonDto
    {
        public ResponsePersonDto() { }

        [DataMember(Name = "Forename", IsRequired = false, Order = 1)]
        public string Forename { get; set; }

        [DataMember(Name = "Surname", IsRequired = true, Order = 2)]
        public string Surname { get; set; }

        [DataMember(Name = "Title", IsRequired = true, Order = 3)]
        public string Title { get; set; }

        [DataMember(Name = "DOB", IsRequired = true, Order = 4)]
        public string DOB { get; set; }

        [DataMember(Name = "Nationality", IsRequired = true, Order = 5)]
        public string Nationality { get; set; }

        [DataMember(Name = "CountryOfResidence", IsRequired = true, Order = 6)]
        public string CountryOfResidence { get; set; }

        [DataMember(Name = "PersonAddress", IsRequired = true, Order = 7)]
        public ResponsePersonAddressDto PersonAddress { get; set; }

        [DataMember(Name = "PersonID", IsRequired = true, Order = 8)]
        public string PersonID { get; set; }
    }

}
