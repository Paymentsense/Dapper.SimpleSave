using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Merchant;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Dto.Application
{
    [DataContract]
    public class LegalInfoDto
    {

        //Business Info section
        [DataMember]
        public Guid ApplicationGuid { get; set; }

        [DataMember]
        public GenBusinessLegalTypeEnum BusinessType { get; set; }

        [DataMember]
        public string CompanyRegistrationNumber { get; set; }

        [DataMember]
        public string VATNumber { get; set; }

        [DataMember]
        public DateTime? CompanyStartDate { get; set; }

        [DataMember]
        public DateTime? CompanyRegistrationDate { get; set; }

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


        //Risk info section
        [DataMember]
        public int PersonalInvestment { get; set; }

        [DataMember]
        public int YearsTrading { get; set; }

        [DataMember]
        public int YearsInIndustry { get; set; }

        [DataMember]
        public bool BusinessBankAccountHeld { get; set; }

        [DataMember]
        public DateTime AccountOpenDate { get; set; }

        [DataMember]
        public int OverdraftLimit { get; set; }

        [DataMember]
        public int AdvertisingTypes { get; set; }

        [DataMember]
        public string CommentToUnderwriting { get; set; }

    }
}
