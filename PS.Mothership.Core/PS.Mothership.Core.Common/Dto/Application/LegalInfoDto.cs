using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Merchant;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Dto.Application
{
    [DataContract]
    public class LegalInfoDto
    {
        [DataMember]
        public Guid ApplicationGuid { get; set; }

        [DataMember]
        public GenBusinessLegalTypeEnum BusinessType { get; set; }

        [DataMember]
        public int CompanyRegistrationNumber { get; set; }

        [DataMember]
        public string VATNumber { get; set; }

        [DataMember]
        public DateTimeOffset? CompanyStartDate { get; set; }

        [DataMember]
        public DateTimeOffset? CompanyRegistrationDate { get; set; }

        [DataMember]
        public string RegisteredCharityNumber { get; set; }

        [DataMember]
        public FullAddressDto Address { get; set; }

        [DataMember]
        public string RegisteredName { get; set; }

        [DataMember]
        public int PhoneCountryKey { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string CommentToUnderwriting { get; set; }

    }
}
