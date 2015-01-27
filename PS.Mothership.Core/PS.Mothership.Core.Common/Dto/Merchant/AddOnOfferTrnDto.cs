using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Gen;
using PS.Mothership.Core.Common.Template.Opp;
using PS.Mothership.Core.Common.Template.Prod;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class AddOnOfferTrnDto
    {
        [DataMember]
        public Guid AddOnOfferGuid { get; set; }

        [DataMember]
        public Guid OfferGuid { get; set; }

        [DataMember]
        public Guid AddOnServicePriceGuid { get; set; }
      
        [DataMember]
        public GenRecStatusEnum RecStatusKey { get; set; }

        [DataMember]
        public decimal ActualPrice { get; set; }
    }
}
