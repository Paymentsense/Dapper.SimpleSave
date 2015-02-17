using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Dto.DueDil
{
    public class LastFetchedDetailsDto 
    {
        public string Id { get; set; }

        public GenBusinessStatusEnum Status { get; set; }

        public DateTimeOffset LastVerifiedDate { get; set; }

    }
}
