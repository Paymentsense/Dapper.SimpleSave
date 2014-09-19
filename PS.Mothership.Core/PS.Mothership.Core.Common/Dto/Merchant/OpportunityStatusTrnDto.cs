using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Gen;
using PS.Mothership.Core.Common.Template.Opp;
using PS.Mothership.Core.Common.Template.Prod;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class OpportunityStatusTrnDto
    {
        [DataMember]
        public Guid OpportunityStatusTrnGuid { get; set; }

        [DataMember]
        public Guid OpportunityGuid { get; set; }

        [DataMember]
        public GenOpportunityStatusEnum StatusKey { get; set; }

        [DataMember]
        public Guid OwnerUserGuid { get; set; }
    }
}
