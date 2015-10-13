using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    public class FullAddressDto : AddressDto
    {
        [SimpleSaveIgnore]
        public string CompanyName { get; set; }

        [SimpleSaveIgnore]
        public string PostCode { get; set; }

        [SimpleSaveIgnore]
        public bool Verified { get; set; }

        [SimpleSaveIgnore]
        public string VerifiedId { get; set; }
    }
}
