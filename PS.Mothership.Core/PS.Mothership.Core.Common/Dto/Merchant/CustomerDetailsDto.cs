using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Contact;
using PS.Mothership.Core.Common.Dto.Message;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class CustomerDetailsDto 
    {
        [DataMember]
        public CustomerDto Customer { get; set; }

        [DataMember]
        public ContactDto Contact { get; set; }

        [DataMember]
        public PhoneNumberDto Phone { get; set; }

        [DataMember]
        public EmailAddressDto Email { get; set; }
    }
}
