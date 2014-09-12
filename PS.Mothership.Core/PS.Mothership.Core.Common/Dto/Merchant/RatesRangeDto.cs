using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Contact;
using PS.Mothership.Core.Common.Template.Gen;
using PS.Mothership.Core.Common.Template.Opp;
using PS.Mothership.Core.Common.Template.Prod;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class RatesRangeDto
    {
        [DataMember]
        public int FieldKey { get; set; }

        [DataMember]
        public int CountryKey { get; set; }

        [DataMember]
        public double FloorPrice { get; set; }

        [DataMember]
        public double CeilingPrice { get; set; }        

    }
    
}