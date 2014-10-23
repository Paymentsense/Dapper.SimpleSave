using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Gen;
using PS.Mothership.Core.Common.Template.Opp;
using PS.Mothership.Core.Common.Template.Prod;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class AddOnServiceDto
    {
        [DataMember]
        public int AddOnServiceKey { get; set; }

        [DataMember]
        public string ShortName { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public GenRecStatusEnum RecStatusKey { get; set; }

        [DataMember]
        public IEnumerable<AddOnServicePriceDto> AddOnServicePrices { get; set; }
        
        [DataMember]
        public int DisplayOrder { get; set; }

    }
}
