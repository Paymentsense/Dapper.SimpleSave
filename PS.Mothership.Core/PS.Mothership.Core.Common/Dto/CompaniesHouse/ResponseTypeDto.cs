using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    [Flags]
    public enum ResponseTypeDto
    {
        [Description("Response Type Unknown")]
        Unknown = 0,

        [Description("Response Type Qualifier is Error")]
        Error = 1,

        [Description("Response Type Class is CompanyNameSearch")]
        NameSearch = 2,

        [Description("Response Type is CompanyNumberSearch")]
        NumberSearch = 4,

        [Description("Response Type is CompanyDetails_V2_1")]
        Details_V2_1 = 8,

        [Description("Response Type is CompanyAppointments_v2_2")]
        Appointments_v2_2 = 16
    }

}
