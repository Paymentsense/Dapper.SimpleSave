using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    /// <summary>
    /// Sales Channel
    /// </summary>
    public class OfferSalesChannelDto
    {
        [DataMember]
        public long DepartmentKey { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public long CountryKey { get; set; }

    }
}