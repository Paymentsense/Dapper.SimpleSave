using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Contact;
using PS.Mothership.Core.Common.Template.Gen;
using PS.Mothership.Core.Common.Template.Opp;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class OfferFieldLutDto
    {
        [DataMember]
        public long FieldKey { get; set; }

        [DataMember]
        public long Name { get; set; }

        [DataMember]
        public long Description { get; set; }

        [DataMember]
        public GenRecStatusEnum RecStatusKey { get; set; }

    }
    
}