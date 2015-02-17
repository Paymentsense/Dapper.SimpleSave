using libphonenumber;
using PS.Mothership.Core.Common.Dto.Dialler;
using PS.Mothership.Core.Common.Template.Gen;
using System.Linq;

namespace PS.Mothership.Core.Common.Helper
{
    public class PhoneNumberParserHelper
    {
        public static ParsedPhoneNumberDto Parse(string phoneNumber)
        {
            var ret = new ParsedPhoneNumberDto
            {
                Country = GenCountryEnum.None,
                PhoneNumber = ""
            };

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                var country = GenCountryEnum.UnitedKingdom;
                var significantPhoneNumber = phoneNumber;
                if (phoneNumber.StartsWith("00") || phoneNumber.StartsWith("+")) // international number
                {
                    PhoneNumber phoneNumberParse = null;
                    try
                    {
                        // using libphonenumber to parse an international phone number and split it
                        // into its components (https://libphonenumber.codeplex.com/)
                        // source code is in \\ps-storage01\PSData\DEVELOPERS\External DLLs Source Code\libphonenumber
                        phoneNumberParse =
                            PhoneNumberUtil.Instance.Parse(
                                phoneNumber.StartsWith("00")
                            // parser only works correctly if international number starts with +, not 00
                                    ? string.Format("+{0}", phoneNumber.Substring(2))
                                    : phoneNumber, null);

                        GenCountry genCountry = GenCountryCollection.GenCountryList.FirstOrDefault(
                            x => x.Alpha2CountryCode == phoneNumberParse.RegionCodeForNumber);

                        country = genCountry != null ? (GenCountryEnum)genCountry.CountryKey : GenCountryEnum.None;
                    }
                    catch
                    {
                        country = GenCountryEnum.None;
                    }
                    finally
                    {
                        if (phoneNumberParse != null && country != GenCountryEnum.None)
                        {
                            significantPhoneNumber = phoneNumberParse.NationalSignificantNumber;
                        }
                    }
                }

                ret.Country = country;
                ret.PhoneNumber = significantPhoneNumber;
            }

            return ret;
        }
    }
}
