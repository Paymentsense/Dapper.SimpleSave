using PS.Mothership.Core.Common.Template.Cust;
using PS.Mothership.Core.Common.Template.Gen;
using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Customer
{
    [DataContract]
    public class MerchantDto
    {
        [DataMember]
        public Guid MerchantGuid { get; set; }

        [DataMember]
        public long V1MerchantId { get; set; }

        [DataMember]
        public string LocatorId { get; set; }

        [DataMember]
        public long ThompsonCodeKey { get; set; }

        [DataMember]
        public CustAnnualTurnoverEnum AnnualTurnover { get; set; }

        [DataMember]
        public CustNumberEmployeesEnum NumberEmployeesKey { get; set; }

        [DataMember]
        public GenBusinessLegalTypeEnum BusinessLegalTypeKey { get; set; }
       
        [DataMember]
        public long CurrentTradingBankKey { get; set; }

        [DataMember]
        public GenNoContactReasonEnum CallRestrictedReasonKey { get; set; }

        [DataMember]
        public long EmailRestrictedReasonKey { get; set; }

        [DataMember]
        public FullAddressDto Address { get; set; }

        [DataMember]
        public Guid PhoneGuid { get; set; }

        [DataMember]
        public Guid EmailAddressGuid { get; set; }

        [DataMember]
        public string WebsiteURL { get; set; }

        [DataMember]
        public string CreditPreScreenFlag { get; set; }

        [DataMember]
        public string ExperianBusinessURN { get; set; }

        [DataMember]
        public string ExperianLocationURN { get; set; }

        [DataMember]
        public DateTime? ExperianLastUpdate { get; set; }

        [DataMember]
        public Guid UpdateSessionGuid { get; set; }

        [DataMember]
        public DateTimeOffset UpdateDate { get; set; }
       
    }
}
