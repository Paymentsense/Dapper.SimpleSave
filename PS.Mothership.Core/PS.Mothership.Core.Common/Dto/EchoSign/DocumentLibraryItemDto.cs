using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Enums.EchoSign;

namespace PS.Mothership.Core.Common.Dto.EchoSign
{
    [DataContract]
    public class DocumentLibraryItemDto
    {
        [DataMember]
        public DocumentLibraryItemScopeEnum Scope { get; set; }
        [DataMember]
        public string LibraryDocumentId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public DateTime ModifiedDate { get; set; }
    }
}
