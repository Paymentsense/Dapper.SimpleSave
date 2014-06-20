using System;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Enums.CompaniesHouse;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos
{
    public class ChargeDto
    {
        public string ChargeNumber {get; set;}
        public DateTime? CreationDate {get; set;}
        public DateTime? RegistrationDate {get; set;}
        public ChargeSatisfied ChargeSatisfied {get; set;}
        public bool AdditionalPersonsEntitled {get; set;}
        public bool AdditionalPersonsEntitledSpecified {get; set;}
        public bool AlterationToChgInd {get; set;}
        public bool AlterationToChgIndSpecified {get; set;}
        public bool DetailsOnFicheInd {get; set;}
        public bool DetailsOnFicheIndSpecified {get; set;}
        public bool ReceiverAptdInd {get; set;}
        public bool ReceiverAptdIndSpecified {get; set;}
        public List<string> Items { get; set; }
        public List<ItemsChoiceType> ItemsElementName { get; set; }
        public List<string> PersonEntChgName { get; set; }
    }
}
