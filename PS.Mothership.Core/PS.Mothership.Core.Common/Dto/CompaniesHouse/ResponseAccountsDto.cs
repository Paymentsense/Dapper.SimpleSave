using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    [DataContract(Name = "Accounts", Namespace = "http://xmlgw.companieshouse.gov.uk/v1-0/schema")]
    public class ResponseAccountsDto
    {
        public ResponseAccountsDto() { }

        [DataMember(Name = "AccountRefDate", IsRequired = false, Order = 1)]
        public string AccountRefDate { get; set; }

        [DataMember(Name = "NextDueDate", IsRequired = false, Order = 2)]
        public string NextDueDate { get; set; }

        [DataMember(Name = "Overdue", IsRequired = true, Order = 3)]
        public string Overdue { get; set; }

        [DataMember(Name = "LastMadeUpDate", IsRequired = false, Order = 4)]
        public string LastMadeUpDate { get; set; }

        [DataMember(Name = "AccountCategory", IsRequired = false, Order = 5)]
        public string AccountCategory { get; set; }

        [DataMember(Name = "DocumentAvailable", IsRequired = true, Order = 6)]
        public string DocumentAvailable { get; set; }
    }

}
