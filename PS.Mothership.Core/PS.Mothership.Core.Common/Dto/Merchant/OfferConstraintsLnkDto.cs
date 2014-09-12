using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Contact;
using PS.Mothership.Core.Common.Template.Gen;
using PS.Mothership.Core.Common.Template.Opp;
using PS.Mothership.Core.Common.Template.Prod;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class OfferConstraintsLnkDto
    {
        [DataMember]
        public Guid OfferConstraintGuid { get; set; }

        [DataMember]
        public int AddOnServiceKey { get; set; }

        [DataMember]
        public int EquipmentModelKey { get; set; }

        [DataMember]
        public ProdAcquirerEnum AcquirerKey { get; set; }

        [DataMember]
        public GenGatewayEnum GatewayKey { get; set; }

        [DataMember]
        public GenTypeOfTransactionEnum TypeOfTransactionKey { get; set; }

        [DataMember]
        public int EquipmentOptionKey { get; set; }

        [DataMember]
        public int LessorKey { get; set; }

        [DataMember]
        public OppOfferConstraintTypeEnum OfferConstraintTypeKey { get; set; }

        [DataMember]
        public int FieldKey { get; set; }

        [DataMember]
        public int CalculatorVersionKey { get; set; } //If not for now this will be made use of for checking the selected offer's version and the current version.

        [DataMember]
        public int CountryKey { get; set; }

        [DataMember]
        public OppContractLengthEnum ContractLengthKey { get; set; }

        [DataMember]
        public GenRecStatusEnum RecStatusKey { get; set; }

    }
    
}