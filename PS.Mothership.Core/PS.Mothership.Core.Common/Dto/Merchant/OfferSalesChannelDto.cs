using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    /// <summary>
    /// Sales Channel
    /// </summary>
    [DataContract]
    public class OfferSalesChannelDto
    {
        [DataMember]
        public Guid SalesChannelGuid { get; set; }

        [DataMember]
        public int DepartmentKey { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int CountryKey { get; set; }
    }
}