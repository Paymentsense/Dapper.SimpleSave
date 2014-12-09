using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Merchant;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Dto.Application
{
    [DataContract]
    public class ApplicationInfoDto
    {
        [DataMember]
        public Guid ApplicationGuid { get; set; }

        [DataMember]
        public Guid MerchantGuid { get; set; }

        [DataMember]
        public ApplicationStatusDto Status { get; set; }

        [DataMember]
        public Guid SalesChannelGuid { get; set; }

        [DataMember]
        public GenCountryEnum CountryKey { get; set; }

    }
}
