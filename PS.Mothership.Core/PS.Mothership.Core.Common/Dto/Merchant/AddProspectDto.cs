using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    public class AddProspectDto
    {
        public string CompanyName { get; set; }

        public string LocatorId
        {
            get
            {
                var id = Convert.ToString(((CompanyName.GetHashCode() ^ DateTime.UtcNow.Ticks.GetHashCode())
                    & 0xffffff) | 0x1000000, 16).Substring(1);
                return id;
            }
        }

        public long MainPhoneCountryKey { get; set; }

        public string MainPhoneNumber { get; set; }

        public Guid ContactGuid { get; set; }

        public Guid AddressGuid { get; set; }

        public Guid MainPhoneGuid { get; set; }
    }
}
