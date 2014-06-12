using PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class CompanyAppointmentsDto
    {
        public string CompanyName { get; set; }
        public string CompanyNumber { get; set; }
        public string HasInconsistencies { get; set; }
        public string NumCurrentAppt { get; set; }
        public string NumResignedAppt { get; set; }
        public string SearchRows { get; set; }
        public string ContinuationKey { get; set; }
        public CoApptDto CoAppt { get; set; }
        public string NumAppointments { get; set; }
        public string NumAppInd { get; set; }
        //TODO Enum
        public string AppointmentType { get; set; }
        public string AppointmentStatus { get; set; }
        public string ApptDatePrefix { get; set; }
        public string AppointmentDate { get; set; }
        public string ResignationDate { get; set; }
        public string Occupation { get; set; }
    }
}
