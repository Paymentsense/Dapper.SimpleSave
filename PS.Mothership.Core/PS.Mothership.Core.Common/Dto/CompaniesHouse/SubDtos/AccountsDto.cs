using System;
using PS.Mothership.Core.Common.Enums.CompaniesHouse;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos
{
    public class AccountsDto
    {
        public string AccountRefDate { get; set; }
        public DateTime? NextDueDate { get; set; }
        public Overdue? Overdue { get; set; }
        public DateTime? LastMadeUpDate { get; set; }
        public string AccountCategory { get; set; }
        public bool? DocumentAvailable { get; set; }
    }
}
