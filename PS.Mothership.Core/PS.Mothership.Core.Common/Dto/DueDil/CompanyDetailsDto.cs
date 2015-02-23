using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.DueDil
{
    public class CompanyDetailsDto : ProcessResponseDto
    {
        public CompanyResponseDto Company { get; set; }

        public IList<DirectorResponseDto> Directors { get; set; }

        public IList<ShareholderResponseDto> ShareHolders { get; set; }
    }
}
