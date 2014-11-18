using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Gen;

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
        public string TypeOfTransaction { get; set; }

        [DataMember]
        public string ProductType { get; set; }

        [DataMember]
        public GenOpportunityStatusEnum OpportunityStatusKey { get; set; }

        [DataMember]
        public string ContractLengthDescription { get; set; }

        [DataMember]
        public string Status { get; set; }
    }
}
