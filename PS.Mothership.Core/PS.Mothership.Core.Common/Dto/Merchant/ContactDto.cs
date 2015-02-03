using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Message;
using PS.Mothership.Core.Common.Dto.Contact;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class ContactDto
    {
        [DataMember]
        public Guid ContactGuid { get; set; }

        [DataMember]
        public GenSalutationEnum SalutationKey { get; set; }

        [DataMember]
        public string SalutationText { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string MiddleInitial { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public EmailAddressDto EmailAddress { get; set; }

        [DataMember]
        public PhoneNumberDto MainPhone { get; set; }

        [DataMember]
        public PhoneNumberDto MobilePhone { get; set; }

        [DataMember]
        public GenContactRoleEnum ContactRoleKey { get; set; }

        [DataMember]
        public string ContactRoleText { get; set; }

        [DataMember]
        public bool IsPrimaryContact { get; set; }
    }
}
