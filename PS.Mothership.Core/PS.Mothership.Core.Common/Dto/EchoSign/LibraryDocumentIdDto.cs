using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.EchoSign
{
    [DataContract]
    public class LibraryDocumentIdDto
    {
        [DataMember]
        public List<DocumentLibraryItemDto> LibraryDocumentList { get; set; }
    }
}
