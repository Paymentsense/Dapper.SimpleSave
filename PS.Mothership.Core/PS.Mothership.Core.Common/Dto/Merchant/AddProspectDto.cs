using System;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    public class AddProspectDto
    {
        public string CompanyName { get; set; }

        public string LocatorId { get; set; }

        public long MainPhoneCountryKey { get; set; }

        public string MainPhoneNumber { get; set; }

        public Guid ContactGuid { get; set; }

        public Guid AddressGuid { get; set; }

        public Guid MainPhoneGuid { get; set; }
    }
}
