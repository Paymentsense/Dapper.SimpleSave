using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [Table("[app].[LOCATION_MST]")]
    public class LocationDto
    {
        public LocationDto()
        {
            Opportunities = new List<OpportunityDto>();
        }

        [PrimaryKey]
        public Guid? LocationGuid { get; set; }

        [ForeignKeyReference(typeof(ApplicationDetailsDto))]
        public Guid? ApplicationGuid { get; set; }

        [OneToMany]
        public IList<OpportunityDto> Opportunities { get; set; }

        public string BusinessName { get; set; }

        public string LocationReference { get; set; }

        [Column("TradingAddressGUID")]
        [OneToOne]
        [ForeignKeyReference(typeof(FullAddressDto))]
        //[ForeignKeyReference(typeof(AddressDto))]
        public FullAddressDto TradingAddress { get; set; }
    }
}
