using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    [DataContract(Name = "GovTalkMessage", Namespace = "http://www.govtalk.gov.uk/schemas/govtalk/govtalkheader")]
    public class CompaniesHouseNumberSearchResponseDto : ICompaniesHouseResponseDto
    {
        public CompaniesHouseNumberSearchResponseDto() { }

        [DataMember(Name = "EnvelopeVersion", IsRequired = true, Order = 1)]
        public string EnvelopeVersion { get; set; }

        [DataMember(Name = "Header", IsRequired = true, Order = 2)]
        public ResponseHeaderDto Header { get; set; }

        [DataMember(Name = "GovTalkDetails", IsRequired = true, Order = 3)]
        public ResponseGovTalkDetailsDto GovTalkDetails { get; set; }

        [DataMember(Name = "Body", IsRequired = true, Order = 4)]
        public ResponseNumberSearchBodyDto Body { get; set; }

        public ResponseTypeDto GetResponseType()
        {
            return ResponseTypeDto.NumberSearch;
        }

        public ResponseHeaderDto GetResponseHeader()
        {
            return this.Header;
        }
    }
}