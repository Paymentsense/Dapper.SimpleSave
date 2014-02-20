using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public interface ICompaniesHouseResponseDto
    {
        ResponseTypeDto GetResponseType();
        ResponseHeaderDto GetResponseHeader();
    }
}
