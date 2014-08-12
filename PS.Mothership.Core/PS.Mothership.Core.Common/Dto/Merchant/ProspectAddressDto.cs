using System;
using System.Runtime.Serialization;


namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class ProspectAddressDto
    {
        [DataMember]
        public Guid MerchantGuid { get; set; }

        [DataMember]
        public string BusinessName { get; set; }

        [DataMember]
        public string HouseNumber { get; set; }
  
        [DataMember]
        public string HouseName { get; set; }
       
        [DataMember]
        public string FlatAptSuite { get; set; }

        [DataMember]
        public string Street { get; set; }
 
        [DataMember]
        public string Town { get; set; }

        [DataMember]
        public string County { get; set; }

        [DataMember]
        public string PostCode { get; set; }


    }
}
