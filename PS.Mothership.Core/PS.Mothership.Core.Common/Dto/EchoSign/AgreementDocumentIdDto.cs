using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.EchoSign
{
    [DataContract]
    public class AgreementDocumentIdDto
    {
        [DataMember]
        public List<DocumentsInfoDto> Documents { get; set; }
    }
}
