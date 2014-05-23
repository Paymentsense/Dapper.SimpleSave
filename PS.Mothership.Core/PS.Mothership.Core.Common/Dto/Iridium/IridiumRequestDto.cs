using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.Iridium
{
    [DataContract]
    public class IridiumRequestDto
    {
        [DataMember]
        public Guid CustomerGuid { get; set; }
        [DataMember]
        public Guid OpportunityGUID { get; set; }
        [DataMember]
        public string BusinessName { get; set; }
        [DataMember]
        public string LocatorID { get; set; }
        [DataMember]
        public string ContactEmail { get; set; }
        [DataMember]
        public string ContactFirstName { get; set; }
        [DataMember]
        public string ContactLastName { get; set; }
        [DataMember]
        public string Telephone { get; set; }
        [DataMember]
        public string WebAddress { get; set; }
        [DataMember]
        public string StreetAndNumber { get; set; }
        [DataMember]
        public string StreetAndNumber2 { get; set; }
        [DataMember]
        public string StreetAndNumber3 { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string PostCode { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public bool isECom { get; set; }
    }
}
