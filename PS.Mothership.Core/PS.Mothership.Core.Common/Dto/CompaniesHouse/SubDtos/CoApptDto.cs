using PS.Mothership.Core.Common.Enums.CompaniesHouse;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos
{
    public class CoApptDto
    {
        public PersonDto Person { get; set; }
        public string NumAppointments { get; set; }
        public NumAppInd NumAppInd { get; set; }
        public bool NumAppIndSpecified { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public ApptDatePrefix ApptDatePrefix { get; set; }
        public bool ApptDatePrefixSpecified { get; set; }
        public System.DateTime AppointmentDate { get; set; }
        public System.DateTime ResignationDate { get; set; }
        public bool ResignationDateSpecified { get; set; }
        public string Occupation { get; set; }
    }
}
