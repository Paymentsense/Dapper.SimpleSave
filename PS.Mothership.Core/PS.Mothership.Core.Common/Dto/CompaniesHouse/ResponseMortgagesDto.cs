using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    [DataContract(Name = "Mortgages", Namespace = "http://xmlgw.companieshouse.gov.uk/v1-0/schema")]
    public class ResponseMortgagesDto
    {
        public ResponseMortgagesDto()
        {
        }

        [DataMember(Name = "MortgageInd", IsRequired = true, Order = 1)]
        public string MortgageInd { get; set; }

        [DataMember(Name = "NumMortCharges", IsRequired = true, Order = 2)]
        public string NumMortCharges { get; set; }

        [DataMember(Name = "NumMortOutstanding", IsRequired = true, Order = 3)]
        public string NumMortOutstanding { get; set; }

        [DataMember(Name = "NumMortPartSatisfied", IsRequired = true, Order = 4)]
        public string NumMortPartSatisfied { get; set; }

        [DataMember(Name = "NumMortSatisfied", IsRequired = true, Order = 5)]
        public string NumMortSatisfied { get; set; }
    }
}
