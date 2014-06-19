using System;
using PS.Mothership.Core.Common.Enums.CompaniesHouse;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos
{
    public class AccountsDto
    {
        public DateTime AccountRefDate { get; set; }
        public bool AccountRefDateSpecified { get; set; }
        public DateTime NextDueDate { get; set; }
        public bool NextDueDateSpecified { get; set; }
        public Overdue Overdue { get; set; }
        public DateTime LastMadeUpDate { get; set; }
        public bool LastMadeUpDateSpecified { get; set; }
        public string AccountCategory { get; set; }
        public bool DocumentAvailable { get; set; }
    }
}
