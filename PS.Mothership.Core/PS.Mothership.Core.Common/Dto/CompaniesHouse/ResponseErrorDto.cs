using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    [DataContract(Name = "Error", Namespace = "http://www.govtalk.gov.uk/schemas/govtalk/govtalkheader")]
    public class ResponseErrorDto
    {
        public ResponseErrorDto() { }

        [DataMember(Name = "RaisedBy", IsRequired = false, Order = 1)]
        public string RaisedBy { get; set; }

        [DataMember(Name = "Number", IsRequired = false, Order = 2)]
        public string Number { get; set; }

        [DataMember(Name = "Type", IsRequired = false, Order = 3)]
        public string Type { get; set; }

        [DataMember(Name = "Text", IsRequired = false, Order = 4)]
        public string Text { get; set; }

        [DataMember(Name = "Location", IsRequired = false, Order = 5)]
        public string Location { get; set; }
    }
}
