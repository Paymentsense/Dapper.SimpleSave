using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Dto.DynamicRequest;
using PS.Mothership.Core.Common.Template.Cust;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract(Name = "merchantDataRequest")]
    public class MerchantDataRequestDto
    {
        //public string Test { get; set; }
        [DataMember(Name = "advancedSearch")]
        public AdvancedSearchDto AdvancedSearch { get; set; }

        
        [DataMember  (Name = "dataRequest")] 
        public DataRequestDto DataRequest { get; set; }
        
    }

    [DataContract]
    public class AdvancedSearchDto
    {

        //[DataMember]
        //public Guid MerchantContactLnkGuid { get; set; }

        //[DataMember]
        //public PS.Mothership.Core.Common.Template.Gen.GenContactRoleEnum ContactRoleKey { get; set; }

        //[DataMember]
        //public Guid ContactGuid { get; set; }


        //[DataMember]
        //public Guid MerchantGuid { get; set; }

        //[DataMember]
        //public long V1MerchantId { get; set; }

        [DataMember]
        public string BusinessName { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }

        [DataMember]
        public string Street { get; set; }

        [DataMember]
        public string Town { get; set; }

        [DataMember]
        public string PostCode { get; set; }

        //[DataMember]
        //public DataRequestDto DataRequest { get; set; }


        //[DataMember]
        //public string LocatorId { get; set; }

        //[DataMember]
        //public long ThompsonCodeKey { get; set; }

        //[DataMember]
        //public CustAnnualTurnoverEnum AnnualTurnover { get; set; }

        //[DataMember]
        //public CustNumberEmployeesEnum NumberEmployeesKey { get; set; }

        //[DataMember]
        //public GenBusinessLegalTypeEnum BusinessLegalTypeKey { get; set; }

        //[DataMember]
        //public long CurrentTradingBankKey { get; set; }


        //[DataMember]
        //public GenNoContactReasonEnum CallRestrictedReasonKey { get; set; }

        //[DataMember]
        //public long EmailRestrictedReasonKey { get; set; }


        //[DataMember]
        //public Guid PhoneGuid { get; set; }

        //[DataMember]
        //public string PhoneNumber { get; set; }

        //[DataMember]
        //public Guid EmailAddressGuid { get; set; }

        //[DataMember]
        //public string WebsiteURL { get; set; }

        //[DataMember]
        //public string CreditPreScreenFlag { get; set; }

        //[DataMember]
        //public string ExperianBusinessURN { get; set; }

        //[DataMember]
        //public string ExperianLocationURN { get; set; }

        //[DataMember]
        //public DateTime? ExperianLastUpdate { get; set; }

        //[DataMember]
        //public Guid UpdateSessionGuid { get; set; }

        //[DataMember]
        //public DateTimeOffset UpdateDate { get; set; }

        //[DataMember]
        //public IList<ContactDto> Contacts { get; set; }

        //public AdvancedSearchDto()
        //{
        //    this.Contacts = new List<ContactDto>();
        //}

    }
}
