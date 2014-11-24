using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PS.Mothership.Core.Common.Dto.Application
{
    public class PremisesTypeDto
    {
        [DataMember]
        public int BusinessLegalTypeKey { get; set; }

        [DataMember]
        public string EnumDescription { get; set; }
    }
}
