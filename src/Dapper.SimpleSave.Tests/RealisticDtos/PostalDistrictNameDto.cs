using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [Table("[gen].[POSTCODE_DISTRICT_LUT]")]
    [ReferenceData]
    public class PostalDistrictNameDto
    {
        [PrimaryKey]
        public int? PostalDistrictKey { get; set; }

        public string PostalDistrict { get; set; }

        public override string ToString()
        {
            return PostalDistrict;
        }
    }
}
