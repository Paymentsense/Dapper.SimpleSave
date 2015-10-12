using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [Table("[app].[APPLICATION_MST]")]
    public class ApplicationDetailsDto
    {
        public ApplicationDetailsDto()
        {
            Locations = new List<LocationDto>();
        }

        [PrimaryKey]
        public Guid? ApplicationGuid { get; set; }

        public string ApplicationReference { get; set; }

        [OneToOne("ApplicationGuid")]
        public LegalInfoDto LegalInfo { get; set; }
        /// <summary>
        /// We ignore for loading because one to many relationships can lead to a combinatorial explosion in result
        /// set rows. The average case is therfore probably more performant if we retrieve these separately.
        /// They can however be safely saved as part of the application.
        /// </summary>
        [OneToMany]
        public IList<LocationDto> Locations { get; set; }
    }
}
