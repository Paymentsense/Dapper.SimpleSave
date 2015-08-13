using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [Table("[user].USER_MST")]
    public class UserDto
    {
        public UserDto()
        {
            Department = new List<DepartmentDto>();
            AdditionalRoles = new List<RoleDto>();
            Team = new List<TeamDto>();
        }

        [PrimaryKey]
        public int? UserKey { get; set; }
        public Guid UserGuid { get; set; }
        public int? EmployeeID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        [Column("UserStatusKey")]
        [ManyToOne]
        public UserStatusEnum Status { get; set; }

        //// HACK - this is minging and might be avoidable - revisit
        //// Is used in Dapper Repository Queries
        //// ReSharper disable UnusedMember.Local
        //private int DapperEnumHack_Status
        //{
        //    set
        //    {
        //        Status = (UserStatusEnum) value;
        //    }
        //}
        //// ReSharper restore UnusedMember.Local

        public bool IsOnWatchList { get; set; }

        public DateTimeOffset? WatchListFlagDate { get; set; }

        public int? WatchListFlagUserKey { get; set; }

        [SimpleSaveIgnore]
        public string WatchListUsername { get; set; }

        [Column("MobileNumberKey")]
        [OneToOne]
        [ForeignKeyReference(typeof(PhoneNumberDto))]
        [ReferenceData]
        public PhoneNumberDto MobileNumber { get; set; }

        public bool MobileNumberIsVerified { get; set; }

        [Column("FreephoneNumberKey")]
        [OneToOne]
        [ForeignKeyReference(typeof(PhoneNumberDto))]
        [ReferenceData]
        public PhoneNumberDto FreephoneNumber { get; set; }

        [Column("OfficeNumberKey")]
        [OneToOne]
        [ForeignKeyReference(typeof(PhoneNumberDto))]
        [ReferenceData]
        public PhoneNumberDto OfficeNumber { get; set; }

        public string EmailAddress { get; set; }

        public int PasswordFailureCount { get; set; }

        [ManyToOne]
        [Column("PositionKey")]
        public PositionDto Position { get; set; }

        [ManyToMany("[user].USER_DEPARTMENT_LNK")]
        public IList<DepartmentDto> Department { get; set; }

        [ManyToMany("[user].USER_ADDITIONAL_ROLES_LNK")]
        public IList<RoleDto> AdditionalRoles { get; set; }

        [ManyToMany("[user].USER_TEAM_LNK")]
        public IList<TeamDto> Team { get; set; }

        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? HireDate { get; set; }
        public DateTimeOffset? DeactivatedDate { get; set; }

        public bool IsUserCreatedByHr { get; set; }
    }
}
