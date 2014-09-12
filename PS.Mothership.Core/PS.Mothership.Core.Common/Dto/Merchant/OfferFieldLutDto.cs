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
        public int FieldKey { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public GenRecStatusEnum RecStatusKey { get; set; }

    }
    
}