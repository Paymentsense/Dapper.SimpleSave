using System;
using PS.Mothership.Core.Common.Enums.CompaniesHouse;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos
{
    public class FhistChildDocDto
    {
        public FHistCPLXtTypeChildDocumentChildDocumentType ChildDocumentType { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string FormType { get; set; }
        public string DocumentDesc { get; set; }
        public string Description { get; set; }
        public bool? LastestStatementOfCapital { get; set; }
        public bool LastestStatementOfCapitalSpecified { get; set; }
    }
}
