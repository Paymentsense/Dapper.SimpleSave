using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Merchant;

namespace PS.Mothership.Core.Common.Dto.Application
{
    [DataContract]
    public class OpportunitySummaryDto
    {
        [DataMember]
        public Guid OpportunityGuid { get; set; }

        [DataMember]
        public double Credit { get; set; }

        [DataMember]
        public double Debit { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Reference { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string ContractLengthDescription { get; set; }


    }
}
