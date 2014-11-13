using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Dto.Contact;
using PS.Mothership.Core.Common.Template.Ptnr;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class PartnerDto
    {
        [DataMember]
        public Guid PartnerGuid { get; set; }

        [DataMember]
        public PtnrPartnerTypeEnum PartnerTypeKey { get; set; }

        [DataMember]
        public string LocatorId { get; set; }

        [DataMember]
        public string PartnerName { get; set; }

        [DataMember]
        public string BusinessEmailAddress { get; set; }

        [DataMember]
        public string WebAddress { get; set; }

        [DataMember]
        public Guid? AcctManagerUserGuid { get; set; }

        [DataMember]
        public AddressDto Address { get; set; }

    }
}
