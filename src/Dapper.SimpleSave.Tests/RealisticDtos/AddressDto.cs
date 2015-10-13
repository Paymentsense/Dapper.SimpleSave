using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [Table("[gen].[ADDRESS_MST]")]
    public class AddressDto
    {
        [PrimaryKey]
        public Guid? AddressGuid { get; set; }

        public string HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string HouseName { get; set; }
        public string FlatAptSuite { get; set; }
        public string TownName { get; set; }

        //public int PostCodeKey { get; set; }

        [ManyToOne("PostCodeKey")]
        [Column("PostCodeKey")]
        public PostCodeDetailsDto PostCodeDetails { get; set; }

        [ManyToOne("CountyKey")]
        [Column("CountyKey")]
        public CountyDto County { get; set; }

        //public int CountyKey { get; set; }

        public int CountryKey { get; set; }
        public GenAddressTypesEnum AddressTypeKey { get; set; }
        public DateTimeOffset? AddressConfirmedDate { get; set; }
    }
}
