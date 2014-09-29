using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Gen;
using PS.Mothership.Core.Common.Template.Opp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class MerchantOfferDto
    {
        [DataMember]
        public Guid CustomerGuid { get; set; }

        [DataMember]
        public Guid OfferGuid { get; set; }

        [DataMember]
        public string Reference { get; set; }

        [DataMember]
        public string Description { get; set; }

        //[DataMember]
        //public GenOpportunityStatus Status { get; set; }

        //[DataMember]
        //public string StatusDescription
        //{
        //    get
        //    {
        //        return GenOpportunityStatusCollection.GenOpportunityStatusList.Single(x => x.EnumValue == Status.EnumValue).EnumDescription;
        //    }
        //}

        [DataMember]
        public decimal Credit { get; set; }

        [DataMember]
        public decimal Debit { get; set; }

        [DataMember]
        public int ContractLengthKey { get; set; }

        [DataMember]
        public string ContractLengthDescription { get; set; }

        [DataMember]
        public DateTimeOffset UpdateDate { get; set; }

        [DataMember]
        public string UpdateUsername { get; set; }

        [DataMember]
        public Guid UpdateSessionGuid { get; set; }
    }
}
