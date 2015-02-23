using NUnit.Framework;
using PS.Mothership.Core.Common.Dto.Dialler;
using PS.Mothership.Core.Common.Helper;
using PS.Mothership.Core.Common.Template.Gen;
using System.Collections.Generic;

namespace PS.Mothership.Core.UnitTest.Helper
{
    [TestFixture]
    public class PhoneNumberParserHelperTest
    {
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ParseNullOrEmptyPhoneNumberReturnsCountryNoneAndEmptyPhoneNumber(string phoneNumber)
        {
            ParsedPhoneNumberDto parsedPhoneNumber = PhoneNumberParserHelper.Parse(phoneNumber);

            Assert.That(new ParsedPhoneNumberDto {Country = GenCountryEnum.None, PhoneNumber = ""},
                Is.EqualTo(parsedPhoneNumber).Using(new ParsedPhoneNumberDtoComparer()));
        }

        [Test]
        [TestCase("07553975612")]
        public void ParseUkPhoneNumberReturnsCountryUkAndPhoneNumber(string phoneNumber)
        {
            ParsedPhoneNumberDto parsedPhoneNumber = PhoneNumberParserHelper.Parse(phoneNumber);

            Assert.That(new ParsedPhoneNumberDto { Country = GenCountryEnum.UnitedKingdom, PhoneNumber = phoneNumber },
                Is.EqualTo(parsedPhoneNumber).Using(new ParsedPhoneNumberDtoComparer()));
        }

        [Test]
        [TestCase(GenCountryEnum.Portugal, "351", "919613522", "+")]
        [TestCase(GenCountryEnum.Portugal, "351", "919613522", "00")]
        [TestCase(GenCountryEnum.Germany, "49", "89123456", "+")]
        [TestCase(GenCountryEnum.Germany, "49", "89123456", "00")]
        [TestCase(GenCountryEnum.UnitedStates, "1", "2127363100", "+")]
        [TestCase(GenCountryEnum.UnitedStates, "1", "2127363100", "00")]
        [TestCase(GenCountryEnum.Canada, "1", "5148614653", "+")]
        [TestCase(GenCountryEnum.Canada, "1", "5148614653", "00")]
        [TestCase(GenCountryEnum.Ireland, "353", "16600311", "+")]
        [TestCase(GenCountryEnum.Ireland, "353", "16600311", "00")]
        public void ParseInternationalPhoneNumberReturnsCountryAndSignificantNumber(GenCountryEnum country, string countryPrefix, string significantPhoneNumber, string plusOrDoubleZero)
        {
            ParsedPhoneNumberDto parsedPhoneNumber = PhoneNumberParserHelper.Parse(string.Format("{0}{1}{2}", plusOrDoubleZero, countryPrefix, significantPhoneNumber));

            Assert.That(new ParsedPhoneNumberDto { Country = country, PhoneNumber = significantPhoneNumber },
                Is.EqualTo(parsedPhoneNumber).Using(new ParsedPhoneNumberDtoComparer()));
        }
    }

    public class ParsedPhoneNumberDtoComparer : IEqualityComparer<ParsedPhoneNumberDto>
    {

        public bool Equals(ParsedPhoneNumberDto phoneNumberDto1, ParsedPhoneNumberDto phoneNumberDto2)
        {
            return phoneNumberDto1.Country == phoneNumberDto2.Country &&
                   phoneNumberDto1.PhoneNumber == phoneNumberDto2.PhoneNumber;
        }

        public int GetHashCode(ParsedPhoneNumberDto obj)
        {
            return
                new
                {
                    obj.Country,
                    obj.PhoneNumber
                }.GetHashCode();
        }
    }
}
