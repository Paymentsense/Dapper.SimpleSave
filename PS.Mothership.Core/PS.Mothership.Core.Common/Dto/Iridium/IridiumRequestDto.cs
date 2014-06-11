using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.Iridium
{

    public class IridiumRequestDto
    {
        public Guid CustomerGuid { get; set; }
        public Guid OpportunityGUID { get; set; }
        public Guid GatewayAccountGUID { get; set; }
        public string BusinessName { get; set; }
        public string LocatorID { get; set; }
        public string ContactEmail { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string Telephone { get; set; }
        public string WebAddress { get; set; }
        public string StreetAndNumber { get; set; }
        public string StreetAndNumber2 { get; set; }
        public string StreetAndNumber3 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string State { get; set; }
        public bool isECom { get; set; }
        public string TypeOfTranx { get; set; }
        public int NumOfTerminals { get; set; }
        public string ResultString { get; set; }
        public string ConfirmationUID { get; set; }
    }
}
