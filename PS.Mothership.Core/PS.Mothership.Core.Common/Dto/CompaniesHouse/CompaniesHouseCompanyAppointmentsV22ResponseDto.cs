using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{    
    [DataContract(Name = "GovTalkMessage", Namespace = "http://www.govtalk.gov.uk/schemas/govtalk/govtalkheader")]
    public class CompaniesHouseCompanyAppointmentsV22ResponseDto: ICompaniesHouseResponseDto
    {
        public CompaniesHouseCompanyAppointmentsV22ResponseDto() { }

        [DataMember(Name = "EnvelopeVersion", IsRequired = true, Order = 1)]
        public string EnvelopeVersion { get; set; }

        [DataMember(Name = "Header", IsRequired = true, Order = 2)]
        public ResponseHeaderDto Header { get; set; }

        [DataMember(Name = "GovTalkDetails", IsRequired = true, Order = 3)]
        public ResponseGovTalkDetailsDto GovTalkDetails { get; set; }

        [DataMember(Name = "Body", IsRequired = true, Order = 4)]
        public ResponseCompanyAppointmentsV22BodyDto Body { get; set; }

        public ResponseTypeDto GetResponseType()
        {
            return ResponseTypeDto.Appointments_v2_2;
        }

        public ResponseHeaderDto GetResponseHeader()
        {
            return this.Header;
        }
    }

}
