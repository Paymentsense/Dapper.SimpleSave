using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [Table("[gen].[POSTCODE_LUT]")]
    [ReferenceData]
    public class PostCodeDetailsDto
    {
        [PrimaryKey]
        public int? PostCodeKey { get; set; }

        [ManyToOne("PostalDistrictKey")]
        [Column("PostalDistrictKey")]
        public PostalDistrictNameDto PostalDistrict { get; set; }

        public string PostalLocation { get; set; }
        
        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public string TownName { get; set; }

        public int? CountyKey { get; set; }

        public GenCountryEnum CountryKey { get; set; }
    }
}
