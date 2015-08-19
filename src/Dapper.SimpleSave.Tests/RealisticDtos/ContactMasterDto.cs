using System;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [Table("[cust].CONTACT_MST")]
    public class ContactMasterDto
    {
        [PrimaryKey]
        public Guid? ContactGuid { get; set; }

        public DateTimeOffset UpdateDate { get; set; }
        public Guid UpdateSessionGuid { get; set; }

        public int SalutationKey { get; set; }
        [SimpleSaveIgnore]
        public SalutationDto Salutation { get; set; }

        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string Surname { get; set; }

        [ManyToOne, Column("EmailAddressGuid")]
        public EmailAddressMasterDto EmailAddress { get; set; }

        [ManyToOne("PhoneGUID"), Column("MainPhoneGuid")]
        public PhoneNumberDto MainPhone { get; set; }

        [ManyToOne("PhoneGUID"), Column("MobilePhoneGuid")]
        public PhoneNumberDto MobilePhone { get; set; }

        public bool IsPrimaryContact { get; set; }

        public int? PreferredContactType { get; set; }
    }

    public enum PreferredContactType : byte 
    {
        Phone,
        Mobile,
        Email
    }

}
