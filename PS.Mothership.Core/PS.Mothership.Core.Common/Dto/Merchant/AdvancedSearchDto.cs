using System.Runtime.Serialization;


namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class AdvancedSearchDto
    {
        [DataMember]
        public string BankAccount { get; set; }

        [DataMember]
        public string BankMid { get; set; }

        [DataMember]
        public string BusinessName { get; set; }

        [DataMember]
        public string BusinessType { get; set; }

        [DataMember]
        public string CreatedFrom { get; set; }

        [DataMember]
        public string CreatedTo { get; set; }

        [DataMember]
        public string Department { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastUpdateFrom { get; set; }

        [DataMember]
        public string LastUpdateTo { get; set; }

        [DataMember]
        public string LocatorId { get; set; }

        [DataMember]
        public string Mobile { get; set; }

        [DataMember]
        public string OpportunityId { get; set; }

        [DataMember]
        public string Owner { get; set; }

        [DataMember]
        
        public string PhoneNumber { get; set; }

        [DataMember]
        public string PostCode { get; set; }

        [DataMember]
        public string Provisioner { get; set; }

        [DataMember]
        public string RegisteredNo { get; set; }

        [DataMember]
        public string Source { get; set; }

        [DataMember]
        public string Stage { get; set; }

        [DataMember]
        public string Street { get; set; }

        [DataMember]
        public string SubStage { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public string ThompsonCode { get; set; }
          
        [DataMember]
        public string Town { get; set; }

        [DataMember]
        public string V1MerchantId { get; set; }

    }
}
