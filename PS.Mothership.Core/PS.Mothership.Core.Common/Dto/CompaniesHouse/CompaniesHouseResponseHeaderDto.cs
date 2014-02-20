using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    /// <summary>
    /// Use this class to determine the Response type based on the MessageDetails Class and Qualifier values.
    /// </summary>
    [DataContract(Name = "GovTalkMessage", Namespace = "http://www.govtalk.gov.uk/schemas/govtalk/govtalkheader")]
    public class CompaniesHouseResponseHeaderDto : ICompaniesHouseResponseDto
    {
        public CompaniesHouseResponseHeaderDto()
        {
        }

        [DataMember(Name = "EnvelopeVersion", IsRequired = true, Order = 1)]
        public string EnvelopeVersion { get; set; }

        [DataMember(Name = "Header", IsRequired = true, Order = 2)]
        public ResponseHeaderDto Header { get; set; }

        public bool IsValidResponse()
        {
            if (
                Header != null &&
                Header.MessageDetails != null &&
                !string.IsNullOrWhiteSpace(Header.MessageDetails.Qualifier) &&
                string.Compare(Header.MessageDetails.Qualifier, "response", true) == 0
            )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ResponseTypeDto GetResponseType()
        {
            ResponseTypeDto responseType = ResponseTypeDto.Unknown;

            if (
                Header != null &&
                Header.MessageDetails != null &&
                !string.IsNullOrWhiteSpace(Header.MessageDetails.Class)
            )
            {
                switch (Header.MessageDetails.Class.ToUpper())
                {
                    case "NAMESEARCH":
                        responseType = ResponseTypeDto.NameSearch;
                        break;
                    case "NUMBERSEARCH":
                        responseType = ResponseTypeDto.NumberSearch;
                        break;
                    case "COMPANYDETAILS":
                        responseType = ResponseTypeDto.Details_V2_1;
                        break;
                    case "COMPANYAPPOINTMENTS":
                        responseType = ResponseTypeDto.Appointments_v2_2;
                        break;
                }
            }

            return responseType;
        }

        public ResponseHeaderDto GetResponseHeader()
        {
            return this.Header;
        }
    }
}
