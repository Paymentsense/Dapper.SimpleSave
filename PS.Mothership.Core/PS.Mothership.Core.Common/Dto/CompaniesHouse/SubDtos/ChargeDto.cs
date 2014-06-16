using System;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos
{
    public class ChargeDto
    {
        public int ChargeNumber { get; set; }
        public string ChargeCode { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string ChargeSatisfied { get; set; }
        public string PersonEntChgName { get; set; }
        public string AdditionalPersonsEntitled { get; set; }
        public string AlterationToChgIndicator { get; set; }
        public string DetailsOnFicheInd { get; set; }
        public string ReceiverApptInd { get; set; }
    }
}
