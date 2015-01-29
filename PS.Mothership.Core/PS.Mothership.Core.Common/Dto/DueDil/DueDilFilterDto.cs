using System;
using PS.Mothership.Core.Common.Enums.DueDil;

namespace PS.Mothership.Core.Common.Dto.DueDil
{
    public class DueDilFilterDto
    {
        public DueDilLocale Locale { get; set; }

        public string Name { get; set; }

        public string PostCode { get; set; }

        public string Location { get; set; }
    }
}
