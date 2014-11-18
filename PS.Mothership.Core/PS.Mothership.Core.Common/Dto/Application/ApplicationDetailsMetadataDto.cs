using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.App;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Dto.Application
{
    [DataContract]
    public class ApplicationDetailsMetadataDto
    {
        [DataMember]
        public IList<GenBusinessLegalType> BusinessLegalTypes { get; set; }

        [DataMember]
        public IList<AppAdvertisingFlags> AdvertisingTypes { get; set; }
    }
}
