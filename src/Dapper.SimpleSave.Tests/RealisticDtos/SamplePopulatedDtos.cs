using System;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    public static class SamplePopulatedDtos
    {
        public static readonly CountryDto TestCountry = new CountryDto
        {
            CountryKey = 1,
            Alpha2CountryCode = "GB",
            Alpha3CountryCode = "GBR",
            CurrencyCode = new CurrencyCodeDto
            {
                CurrencyCodeKey = 1,
                CurrencyBaseFraction = 100,
                Description = "United Kingom Pound",
                IWSLCurrencyCode = 163,
                Name = "GBP",
                RecStatus = RecStatusEnum.ActiveShowInLists,
                RowGUID = new Guid("5BD76710-0D86-4ECA-93AE-D6C276B51F9F"),
                SubUnit = "p",
                Unit = "£"
            }
        };

        public static readonly PhoneNumberDto MobileNumberDto = new PhoneNumberDto
        {
            PhoneNumberKey = 1,
            PhoneGuid = new Guid("DDE36C15-F0AA-4D94-919F-D714A8366892"),
            PhoneNumber = "777 1234567",
            Country = TestCountry
        };

        public static readonly PhoneNumberDto MobileNumberDto2 = new PhoneNumberDto
        {
            PhoneNumberKey = 1,
            PhoneGuid = new Guid("DDE36C15-F0AA-4D94-919F-D714A8366892"),
            PhoneNumber = "543254",
            Country = TestCountry
        };

        public static readonly PhoneNumberDto OfficeNumberDto = new PhoneNumberDto
        {
            PhoneNumberKey = 4,
            PhoneGuid = new Guid("DDE36C15-F0AA-4D94-919F-D714A8366892"),
            PhoneNumber = "02075555555",
            Country = TestCountry
        };

        public static readonly ContactMasterDto Contact = new ContactMasterDto
        {
            ContactGuid = Guid.NewGuid(),
            EmailAddress = new EmailAddressMasterDto
            {
                EmailAddress = "mal.reynolds@example.com",
                EmailAddressGuid = Guid.NewGuid(),
                ReasonKey = 0,
                UpdateDate = DateTimeOffset.Now,
                UpdateSessionGuid = Guid.NewGuid()
            },
            FirstName = "Malcolm",
            MiddleInitial = null,
            Surname = "Reynolds",
            Salutation = new SalutationDto
            {
                SalutationKey = 1,
                Description = "Captain"
            },
            SalutationKey = 1,
            IsPrimaryContact = true,
            MainPhone = MobileNumberDto,
            MobilePhone = MobileNumberDto2,
            UpdateSessionGuid = Guid.NewGuid(),
            UpdateDate = DateTimeOffset.Now
        };
    }
}
