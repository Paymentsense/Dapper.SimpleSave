using System;
using PS.Mothership.Core.Common.Enums.DueDil;

namespace PS.Mothership.Core.Common.Dto.DueDil
{
    public class CompanyListResponseDto
    {
        public string Id { get; set; }

        public string Locale { get; set; }

        public string Name { get; set; }

        public string Postcode { get; set; }

        public string CompanyUrl { get; set; }
    }
}
