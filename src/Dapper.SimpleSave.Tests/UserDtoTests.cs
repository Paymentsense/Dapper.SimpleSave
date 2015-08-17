using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.SimpleSave.Tests.RealisticDtos;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests
{
    [TestFixture]
    public class UserDtoTests : BaseTests
    {
        /* OLD USER
{
  "UserKey": 15,
  "UserGuid": "09bd1acf-a171-46ed-becf-096302ae3bc0",
  "EmployeeID": 547,
  "FirstName": "Jack",
  "LastName": "Sparrow",
  "Username": "jack.sparrow",
  "Status": 0,
  "IsOnWatchList": true,
  "WatchListFlagDate": "2015-08-14T16:34:27.1555829+01:00",
  "WatchListFlagUserKey": null,
  "WatchListUsername": null,
  "MobileNumber": {
    "PhoneNumberKey": 26,
    "PhoneGUID": "a2dfd3e5-9942-e511-8caa-989096c2e476",
    "Country": {
      "CountryKey": 224,
      "Alpha3CountryCode": "GBR",
      "NumericCountryCode": "826",
      "Name": "UnitedKingdom",
      "TelephoneCountryCode": "44",
      "IsFraudWatch": false,
      "RowGUID": "d9fb8ea8-44b3-e311-93fd-d757b57bb279",
      "RecStatus": 0,
      "CurrencyCode": {
        "CurrencyCodeKey": 1,
        "Name": "GBP",
        "Description": "BritishSterling",
        "IWSLCurrencyCode": 0,
        "CurrencyBaseFraction": 0,
        "RowGUID": "fe001e07-83b6-e311-93fe-9c6285fef377",
        "RecStatus": 0,
        "Unit": "£",
        "SubUnit": "p"
      },
      "DisplayName": "UK",
      "Description": "United Kingdom",
      "TelephoneValidationRegex": "x",
      "TelephoneValidationMessage": "Please type vaild phone number",
      "Alpha2CountryCode": "GB"
    },
    "PhoneNumber": "8001234567",
    "BadNumberCount": 0,
    "IsDoNotCall": false,
    "PhoneNumberType": 0
  },
  "MobileNumberIsVerified": false,
  "FreephoneNumber": null,
  "OfficeNumber": {
    "PhoneNumberKey": 25,
    "PhoneGUID": "a1dfd3e5-9942-e511-8caa-989096c2e476",
    "Country": {
      "CountryKey": 224,
      "Alpha3CountryCode": "GBR",
      "NumericCountryCode": "826",
      "Name": "UnitedKingdom",
      "TelephoneCountryCode": "44",
      "IsFraudWatch": false,
      "RowGUID": "d9fb8ea8-44b3-e311-93fd-d757b57bb279",
      "RecStatus": 0,
      "CurrencyCode": {
        "CurrencyCodeKey": 1,
        "Name": "GBP",
        "Description": "BritishSterling",
        "IWSLCurrencyCode": 0,
        "CurrencyBaseFraction": 0,
        "RowGUID": "fe001e07-83b6-e311-93fe-9c6285fef377",
        "RecStatus": 0,
        "Unit": "£",
        "SubUnit": "p"
      },
      "DisplayName": "UK",
      "Description": "United Kingdom",
      "TelephoneValidationRegex": "x",
      "TelephoneValidationMessage": "Please type vaild phone number",
      "Alpha2CountryCode": "GB"
    },
    "PhoneNumber": "2030000001",
    "BadNumberCount": 0,
    "IsDoNotCall": false,
    "PhoneNumberType": 0
  },
  "EmailAddress": "jack.sparrow@paymentsense.com",
  "PasswordFailureCount": 0,
  "Position": {
    "PositionKey": 5,
    "Name": "Employee",
    "Groups": []
  },
  "Department": [],
  "AdditionalRoles": [],
  "Team": [],
  "CreatedDate": "2015-08-14T16:34:24.0102684+01:00",
  "HireDate": "2015-08-14T16:34:24.0112685+01:00",
  "DeactivatedDate": null,
  "IsUserCreatedByHr": true,
  "Roles": [
    "Employee"
  ]
}
          
          
          
          
NEW USER
          
          
          
         
{
  "UserKey": 15,
  "UserGuid": "09bd1acf-a171-46ed-becf-096302ae3bc0",
  "EmployeeID": 547,
  "FirstName": "Captain",
  "LastName": "Cook",
  "Username": "jack.sparrow",
  "Status": 0,
  "IsOnWatchList": true,
  "WatchListFlagDate": "2015-08-14T16:34:27.1555829+01:00",
  "WatchListFlagUserKey": null,
  "WatchListUsername": null,
  "MobileNumber": {
    "PhoneNumberKey": null,
    "PhoneGUID": null,
    "Country": {
      "CountryKey": 224,
      "Alpha3CountryCode": "GBR",
      "NumericCountryCode": "826",
      "Name": "UnitedKingdom",
      "TelephoneCountryCode": "44",
      "IsFraudWatch": false,
      "RowGUID": "00000000-0000-0000-0000-000000000000",
      "RecStatus": 0,
      "CurrencyCode": null,
      "DisplayName": "UK",
      "Description": "United Kingdom",
      "TelephoneValidationRegex": "x",
      "TelephoneValidationMessage": "Please type vaild phone number",
      "Alpha2CountryCode": "GB"
    },
    "PhoneNumber": "7799123456",
    "BadNumberCount": 0,
    "IsDoNotCall": false,
    "PhoneNumberType": 0
  },
  "MobileNumberIsVerified": false,
  "FreephoneNumber": {
    "PhoneNumberKey": null,
    "PhoneGUID": null,
    "Country": {
      "CountryKey": 224,
      "Alpha3CountryCode": "GBR",
      "NumericCountryCode": "826",
      "Name": "UnitedKingdom",
      "TelephoneCountryCode": "44",
      "IsFraudWatch": false,
      "RowGUID": "00000000-0000-0000-0000-000000000000",
      "RecStatus": 0,
      "CurrencyCode": null,
      "DisplayName": "UK",
      "Description": "United Kingdom",
      "TelephoneValidationRegex": "x",
      "TelephoneValidationMessage": "Please type vaild phone number",
      "Alpha2CountryCode": "GB"
    },
    "PhoneNumber": "8001234567",
    "BadNumberCount": 0,
    "IsDoNotCall": false,
    "PhoneNumberType": 0
  },
  "OfficeNumber": {
    "PhoneNumberKey": null,
    "PhoneGUID": null,
    "Country": {
      "CountryKey": 224,
      "Alpha3CountryCode": "GBR",
      "NumericCountryCode": "826",
      "Name": "UnitedKingdom",
      "TelephoneCountryCode": "44",
      "IsFraudWatch": false,
      "RowGUID": "00000000-0000-0000-0000-000000000000",
      "RecStatus": 0,
      "CurrencyCode": null,
      "DisplayName": "UK",
      "Description": "United Kingdom",
      "TelephoneValidationRegex": "x",
      "TelephoneValidationMessage": "Please type vaild phone number",
      "Alpha2CountryCode": "GB"
    },
    "PhoneNumber": "2030000001",
    "BadNumberCount": 0,
    "IsDoNotCall": false,
    "PhoneNumberType": 0
  },
  "EmailAddress": "captain.cook@paymentsense.com",
  "PasswordFailureCount": 0,
  "Position": {
    "PositionKey": 5,
    "Name": "Employee",
    "Groups": []
  },
  "Department": [],
  "AdditionalRoles": [],
  "Team": [],
  "CreatedDate": "2015-08-14T16:34:24.0102684+01:00",
  "HireDate": "2015-08-14T16:34:24.0112685+01:00",
  "DeactivatedDate": null,
  "IsUserCreatedByHr": true,
  "Roles": [
    "Employee"
  ]
}

         */

        public const string OldUserDtoJson = "{\n  \"UserKey\": 15,\n  \"UserGuid\": \"09bd1acf-a171-46ed-becf-096302ae3bc0\",\n  \"EmployeeID\": 547,\n  \"FirstName\": \"Jack\",\n  \"LastName\": \"Sparrow\",\n  \"Username\": \"jack.sparrow\",\n  \"Status\": 0,\n  \"IsOnWatchList\": true,\n  \"WatchListFlagDate\": \"2015-08-14T16:34:27.1555829+01:00\",\n  \"WatchListFlagUserKey\": null,\n  \"WatchListUsername\": null,\n  \"MobileNumber\": {\n    \"PhoneNumberKey\": 26,\n    \"PhoneGUID\": \"a2dfd3e5-9942-e511-8caa-989096c2e476\",\n    \"Country\": {\n      \"CountryKey\": 224,\n      \"Alpha3CountryCode\": \"GBR\",\n      \"NumericCountryCode\": \"826\",\n      \"Name\": \"UnitedKingdom\",\n      \"TelephoneCountryCode\": \"44\",\n      \"IsFraudWatch\": false,\n      \"RowGUID\": \"d9fb8ea8-44b3-e311-93fd-d757b57bb279\",\n      \"RecStatus\": 0,\n      \"CurrencyCode\": {\n        \"CurrencyCodeKey\": 1,\n        \"Name\": \"GBP\",\n        \"Description\": \"BritishSterling\",\n        \"IWSLCurrencyCode\": 0,\n        \"CurrencyBaseFraction\": 0,\n        \"RowGUID\": \"fe001e07-83b6-e311-93fe-9c6285fef377\",\n        \"RecStatus\": 0,\n        \"Unit\": \"£\",\n        \"SubUnit\": \"p\"\n      },\n      \"DisplayName\": \"UK\",\n      \"Description\": \"United Kingdom\",\n      \"TelephoneValidationRegex\": \"x\",\n      \"TelephoneValidationMessage\": \"Please type vaild phone number\",\n      \"Alpha2CountryCode\": \"GB\"\n    },\n    \"PhoneNumber\": \"8001234567\",\n    \"BadNumberCount\": 0,\n    \"IsDoNotCall\": false,\n    \"PhoneNumberType\": 0\n  },\n  \"MobileNumberIsVerified\": false,\n  \"FreephoneNumber\": null,\n  \"OfficeNumber\": {\n    \"PhoneNumberKey\": 25,\n    \"PhoneGUID\": \"a1dfd3e5-9942-e511-8caa-989096c2e476\",\n    \"Country\": {\n      \"CountryKey\": 224,\n      \"Alpha3CountryCode\": \"GBR\",\n      \"NumericCountryCode\": \"826\",\n      \"Name\": \"UnitedKingdom\",\n      \"TelephoneCountryCode\": \"44\",\n      \"IsFraudWatch\": false,\n      \"RowGUID\": \"d9fb8ea8-44b3-e311-93fd-d757b57bb279\",\n      \"RecStatus\": 0,\n      \"CurrencyCode\": {\n        \"CurrencyCodeKey\": 1,\n        \"Name\": \"GBP\",\n        \"Description\": \"BritishSterling\",\n        \"IWSLCurrencyCode\": 0,\n        \"CurrencyBaseFraction\": 0,\n        \"RowGUID\": \"fe001e07-83b6-e311-93fe-9c6285fef377\",\n        \"RecStatus\": 0,\n        \"Unit\": \"£\",\n        \"SubUnit\": \"p\"\n      },\n      \"DisplayName\": \"UK\",\n      \"Description\": \"United Kingdom\",\n      \"TelephoneValidationRegex\": \"x\",\n      \"TelephoneValidationMessage\": \"Please type vaild phone number\",\n      \"Alpha2CountryCode\": \"GB\"\n    },\n    \"PhoneNumber\": \"2030000001\",\n    \"BadNumberCount\": 0,\n    \"IsDoNotCall\": false,\n    \"PhoneNumberType\": 0\n  },\n  \"EmailAddress\": \"jack.sparrow@paymentsense.com\",\n  \"PasswordFailureCount\": 0,\n  \"Position\": {\n    \"PositionKey\": 5,\n    \"Name\": \"Employee\",\n    \"Groups\": []\n  },\n  \"Department\": [],\n  \"AdditionalRoles\": [],\n  \"Team\": [],\n  \"CreatedDate\": \"2015-08-14T16:34:24.0102684+01:00\",\n  \"HireDate\": \"2015-08-14T16:34:24.0112685+01:00\",\n  \"DeactivatedDate\": null,\n  \"IsUserCreatedByHr\": true,\n  \"Roles\": [\n    \"Employee\"\n  ]\n}";
        public const string NewUserDtoJson = "{\n  \"UserKey\": 15,\n  \"UserGuid\": \"09bd1acf-a171-46ed-becf-096302ae3bc0\",\n  \"EmployeeID\": 547,\n  \"FirstName\": \"Captain\",\n  \"LastName\": \"Cook\",\n  \"Username\": \"jack.sparrow\",\n  \"Status\": 0,\n  \"IsOnWatchList\": true,\n  \"WatchListFlagDate\": \"2015-08-14T16:34:27.1555829+01:00\",\n  \"WatchListFlagUserKey\": null,\n  \"WatchListUsername\": null,\n  \"MobileNumber\": {\n    \"PhoneNumberKey\": null,\n    \"PhoneGUID\": null,\n    \"Country\": {\n      \"CountryKey\": 224,\n      \"Alpha3CountryCode\": \"GBR\",\n      \"NumericCountryCode\": \"826\",\n      \"Name\": \"UnitedKingdom\",\n      \"TelephoneCountryCode\": \"44\",\n      \"IsFraudWatch\": false,\n      \"RowGUID\": \"00000000-0000-0000-0000-000000000000\",\n      \"RecStatus\": 0,\n      \"CurrencyCode\": null,\n      \"DisplayName\": \"UK\",\n      \"Description\": \"United Kingdom\",\n      \"TelephoneValidationRegex\": \"x\",\n      \"TelephoneValidationMessage\": \"Please type vaild phone number\",\n      \"Alpha2CountryCode\": \"GB\"\n    },\n    \"PhoneNumber\": \"7799123456\",\n    \"BadNumberCount\": 0,\n    \"IsDoNotCall\": false,\n    \"PhoneNumberType\": 0\n  },\n  \"MobileNumberIsVerified\": false,\n  \"FreephoneNumber\": {\n    \"PhoneNumberKey\": null,\n    \"PhoneGUID\": null,\n    \"Country\": {\n      \"CountryKey\": 224,\n      \"Alpha3CountryCode\": \"GBR\",\n      \"NumericCountryCode\": \"826\",\n      \"Name\": \"UnitedKingdom\",\n      \"TelephoneCountryCode\": \"44\",\n      \"IsFraudWatch\": false,\n      \"RowGUID\": \"00000000-0000-0000-0000-000000000000\",\n      \"RecStatus\": 0,\n      \"CurrencyCode\": null,\n      \"DisplayName\": \"UK\",\n      \"Description\": \"United Kingdom\",\n      \"TelephoneValidationRegex\": \"x\",\n      \"TelephoneValidationMessage\": \"Please type vaild phone number\",\n      \"Alpha2CountryCode\": \"GB\"\n    },\n    \"PhoneNumber\": \"8001234567\",\n    \"BadNumberCount\": 0,\n    \"IsDoNotCall\": false,\n    \"PhoneNumberType\": 0\n  },\n  \"OfficeNumber\": {\n    \"PhoneNumberKey\": null,\n    \"PhoneGUID\": null,\n    \"Country\": {\n      \"CountryKey\": 224,\n      \"Alpha3CountryCode\": \"GBR\",\n      \"NumericCountryCode\": \"826\",\n      \"Name\": \"UnitedKingdom\",\n      \"TelephoneCountryCode\": \"44\",\n      \"IsFraudWatch\": false,\n      \"RowGUID\": \"00000000-0000-0000-0000-000000000000\",\n      \"RecStatus\": 0,\n      \"CurrencyCode\": null,\n      \"DisplayName\": \"UK\",\n      \"Description\": \"United Kingdom\",\n      \"TelephoneValidationRegex\": \"x\",\n      \"TelephoneValidationMessage\": \"Please type vaild phone number\",\n      \"Alpha2CountryCode\": \"GB\"\n    },\n    \"PhoneNumber\": \"2030000001\",\n    \"BadNumberCount\": 0,\n    \"IsDoNotCall\": false,\n    \"PhoneNumberType\": 0\n  },\n  \"EmailAddress\": \"captain.cook@paymentsense.com\",\n  \"PasswordFailureCount\": 0,\n  \"Position\": {\n    \"PositionKey\": 5,\n    \"Name\": \"Employee\",\n    \"Groups\": []\n  },\n  \"Department\": [],\n  \"AdditionalRoles\": [],\n  \"Team\": [],\n  \"CreatedDate\": \"2015-08-14T16:34:24.0102684+01:00\",\n  \"HireDate\": \"2015-08-14T16:34:24.0112685+01:00\",\n  \"DeactivatedDate\": null,\n  \"IsUserCreatedByHr\": true,\n  \"Roles\": [\n    \"Employee\"\n  ]\n}";

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
            PhoneGUID = new Guid("DDE36C15-F0AA-4D94-919F-D714A8366892"),
            PhoneNumber = "777 1234567",
            Country = TestCountry
        };

        public static readonly PhoneNumberDto MobileNumberDto2 = new PhoneNumberDto
        {
            PhoneNumberKey = 1,
            PhoneGUID = new Guid("DDE36C15-F0AA-4D94-919F-D714A8366892"),
            PhoneNumber = "543254",
            Country = TestCountry
        };

        private static readonly PhoneNumberDto OfficeNumberDto = new PhoneNumberDto
        {
            PhoneNumberKey = 4,
            PhoneGUID = new Guid("DDE36C15-F0AA-4D94-919F-D714A8366892"),
            PhoneNumber = "02075555555",
            Country = TestCountry
        };

        public static readonly UserDto JohnSmith = new UserDto {
            UserKey = null,
            FirstName = "John",
            LastName = "Smith",
            MobileNumber = MobileNumberDto,
            EmailAddress = "john.smith@paymentsense.com",
            Username = "john.smith",
            Password = "TODO",
            PasswordSalt = "TODO",
            Status = UserStatusEnum.Active,
            Position = new PositionDto
            {
                PositionKey = 5,
                Name = "Employee"
            },
            Department = new List<DepartmentDto>(new []
                {
                    new DepartmentDto
                    {
                        DepartmentKey = 1,
                        Name = "Field-Sales"
                    },
                    new DepartmentDto
                    {
                        DepartmentKey = 2,
                        Name = "Pro-Support"
                    } 
                }),
            OfficeNumber = OfficeNumberDto
        };

        public static readonly UserDto CaptainHook = new UserDto {
            UserKey = null,
            FirstName = "Captain",
            LastName = "Hook",
            MobileNumber = MobileNumberDto,
            EmailAddress = "captain.hook@paymentsense.com",
            Username = "john.smith",
            Password = "TODO",
            PasswordSalt = "TODO",
            Status = UserStatusEnum.Active,
            Position = new PositionDto
            {
                PositionKey = 5,
                Name = "Employee"
            },
            Department = new List<DepartmentDto>(new []
                {
                    new DepartmentDto
                    {
                        DepartmentKey = 1,
                        Name = "Field-Sales"
                    },
                    new DepartmentDto
                    {
                        DepartmentKey = 2,
                        Name = "Pro-Support"
                    } 
                }),
            OfficeNumber = OfficeNumberDto
        };

        [Test]
        [Ignore("Currently broken - shouldn't reach script execution, but it does, weirdly - relates to #29 in the issue tracker.")]
        public void update_user_dto_does_not_insert_or_update_reference_data_types()
        {
            var logger = CreateMockLogger();

            var oldUser = JsonConvert.DeserializeObject<UserDto>(OldUserDtoJson);
            var newUser = JsonConvert.DeserializeObject<UserDto>(NewUserDtoJson);

            try
            {
                using (var connection = new SqlConnection())
                {
                    connection.Update(oldUser, newUser);
                }
            }
            catch (InvalidOperationException ioe)
            {
                Assert.IsTrue(!ioe.Message.Contains(
                    "Invalid operation. The connection is closed."),
                    string.Format("Right type of exception, wrong message: {0}\r\n{1}", ioe.Message, ioe.StackTrace));
            }
            var scripts = logger.Scripts;
            Assert.AreEqual(1, scripts.Count, "Unexpected number of scripts.");
        }
    }
}
