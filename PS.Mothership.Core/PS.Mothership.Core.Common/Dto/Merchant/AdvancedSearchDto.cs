using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class AdvancedSearchDto
    {
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
    }
}
