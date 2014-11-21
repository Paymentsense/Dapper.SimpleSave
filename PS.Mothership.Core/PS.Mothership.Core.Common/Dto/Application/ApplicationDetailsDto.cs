using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Merchant;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Dto.Application
{
    [DataContract]
    public class ApplicationDetailsDto
    {
        [DataMember]
        public Guid ApplicationGuid { get; set; }

        [DataMember]
        public LegalInfoDto LegalInfo { get; set; }

        [DataMember]
        public ApplicationDetailLocationDto ApplicationDetailLocation { get; set; }



    }
}
