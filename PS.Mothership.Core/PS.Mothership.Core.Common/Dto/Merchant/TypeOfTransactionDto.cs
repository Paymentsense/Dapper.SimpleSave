using PS.Mothership.Core.Common.Template.Gen;
using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Opp;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class TypeOfTransactionDto
    {
        [DataMember]
        public int TypeOfTransactionKey { get; set; }

        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public Guid RowGuid { get; set; }

        [DataMember]
        public GenRecStatusEnum RecStatusKey { get; set; }

        [DataMember]
        public OppTypeOfTransactionEnum TypeOfTransactionEnumKey { get; set; }

        [DataMember]
        public int DisplayOrder { get; set; }
    }
}