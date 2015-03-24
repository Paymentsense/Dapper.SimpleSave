using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Dto.DueDil
{
    public class BusinessDetailTrnDto 
    {
        public Guid BusinessDetailGuid { get; set; }
        public string BusinessIdentifier { get; set; }
        public GenCountryEnum CountryKey { get; set; }
        public GenBusinessDetailProviderEnum BusinessDetailProviderKey { get; set; }
        public string VerifiedBusinessDetails { get; set; }
        public DateTimeOffset LastVerifiedDate { get; set; }
        public GenBusinessStatusEnum BusinessStatusKey { get; set; }
    }
}
