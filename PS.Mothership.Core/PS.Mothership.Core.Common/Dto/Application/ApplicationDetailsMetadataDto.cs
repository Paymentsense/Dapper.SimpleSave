using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Dto.Application
{
    [DataContract]
    public class ApplicationDetailsMetadataDto
    {
        public IList<GenBusinessLegalType> BusinessLegalTypes { get; set; }
    }
}
