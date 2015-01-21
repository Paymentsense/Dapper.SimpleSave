using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Merchant;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Dto.Application
{
    [DataContract]
    public class ApplicationDetailPrincipalDto : ContactDto
    {
        [DataMember]
        public DateTimeOffset DateOfBirth { get; set; }

        [DataMember]
        public GenGenderEnum GenderKey { get; set; }

        [DataMember]
        public bool BeneficialOwner { get; set; }

        //[DataMember]
        //public int ContactRoleKey { get; set; }

        [DataMember]
        public GenCountryEnum Nationality { get; set; }

        [DataMember]
        public int SharesHeldPercent { get; set; }

        [DataMember]
        public IList<PrincipalAddressDto> Addresses { get; set; }

        [DataMember]
        public bool HasValidEidCheck { get; set; }

        [DataMember]
        public Guid ExperianIdCheckGuid { get; set; }

        [DataMember]
        public string ExperianScore { get; set; }

        [DataMember]
        public string ExperianMessage { get; set; }
    }
}
