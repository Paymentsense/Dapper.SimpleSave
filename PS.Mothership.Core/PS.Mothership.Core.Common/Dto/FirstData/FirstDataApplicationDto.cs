using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.FirstData
{
    public class FirstDataApplicationDto
    {
        public string Ext_Reference_ID { get; set; }
        public string SubmissionId { get; set; }
        public string Number_Of_Outlets { get; set; }
        public Business_Information Business_Information { get; set; }
        public List<FirstData_ApplicationInfoPrincipalDto> Business_Principals { get; set; }
        public FirstData_ApplicationInfoBankingInformationDto Banking_Information { get; set; }
        public List<FirstData_ApplicationInfoOutletDto> Outlet_Info { get; set; }
    }
}
