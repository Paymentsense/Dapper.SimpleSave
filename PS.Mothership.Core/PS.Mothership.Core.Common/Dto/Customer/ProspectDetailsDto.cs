using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Contact;
using PS.Mothership.Core.Common.Dto.Message;

namespace PS.Mothership.Core.Common.Dto.Customer
{
    [DataContract]
    public class ProspectDetailsDto 
    {
        [DataMember]
        public ProspectDto Prospect { get; set; }

        [DataMember]
        public ContactDto Contact { get; set; }

        [DataMember]
        public PhoneNumberDto Phone { get; set; }

        [DataMember]
        public PhoneNumberDto Mobile { get; set; }
    }
}
