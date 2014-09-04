using PS.Mothership.Core.Common.Constructs;

namespace PS.Mothership.Core.Common.Validation
{
    public static class GeneralRegex
    {

        public static RegexValidation AlphaOnly
        {
            get
            {
                return new RegexValidation
                {
                    Regex = @"^[a-zA-Z]+$", //This regex doesn't allow whitespaces
                    ErrorMessage = "Please specify letters only"
                };
            }
        }

        public static RegexValidation NumericOnly
        {

            get
            {
                return new RegexValidation
                {
                    Regex = @"^[0-9]+$",
                    ErrorMessage = "Please specify numbers only"
                };
            }
        }

        public static RegexValidation AlphaNumericOnly
        {

            get
            {
                return new RegexValidation
                {
                    Regex = @"^[a-zA-Z0-9]+$",
                    ErrorMessage = "Please specify letters and numbers only"
                };
            }
        }

        /// <summary>
        /// Regex checks UK formatted date
        /// </summary>
        public static RegexValidation UkDate
        {

            get
            {
                return new RegexValidation
                {
                    Regex = @"^(((0[1-9]|[12][0-8])[\/](0[1-9]|1[012]))|((29|30|31)[\/](0[13578]|1[02]))|((29|30)[\/](0[4,6,9]|11)))[\/](19|[2-9][0-9])\d\d$)|(^29[\/]02[\/](19|[2-9][0-9])(00|04|08|12|16|20|24|28|32|36|40|44|48|52|56|60|64|68|72|76|80|84|88|92|96)$",
                    ErrorMessage = "Please specify a valid date"
                };
            }
        }
        /// <summary>
        /// Regex checks both UK and RoI landline numbers
        /// </summary>
        public static RegexValidation PhoneNumber
        {

            get
            {
                return new RegexValidation
                {
                    Regex = @"^(([-\s()]*(\+|00)?[-\s()]*353([-\s()]*\d){9,10}[-\s()]*)|([-\s()]*0?[-\s()]*[1-689]([-\s()]*\d){8,9}[-\s()]*))$",
                    ErrorMessage = "Please specify a valid landline number"
                };
            }
        }

        /// <summary>
        /// Regex checks both UK and RoI mobile numbers
        /// </summary>
        public static RegexValidation MobilePhoneNumber
        {

            get
            {
                return new RegexValidation
                {
                    Regex = @"^(([-\s()]*(\+|00)?[-\s()]*353([-\s()]*\d){9,10}[-\s()]*)|([-\s()]*0?[-\s()]*7([-\s()]*\d){8,9}[-\s()]*))$",
                    ErrorMessage = "Please specify a mobile number"
                };

            }
        }

        public static RegexValidation EmailAddress
        {

            get
            {
                return new RegexValidation
                {
                    Regex = @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$",
                    ErrorMessage = "Please specify a valid email address"
                };

            }
        }

        public static RegexValidation BusinessName
        {

            get
            {
                return new RegexValidation
                {
                    Regex = @"^[a-zA-Z\d\s-'().&]*$", //allows for lower/upper case letters, numbers, spaces, apostrophe,hypen, plus, and curved brackets
                    ErrorMessage = "Please specify a valid business name. Valid characters are a-z,A-Z,0-9,&,',-,+,(,)"
                };

            }
        }

        public static RegexValidation PersonName
        {

            get
            {
                return new RegexValidation
                {
                    Regex = @"^[a-zA-Z\d\s-'().&]*$", //allows for lower/upper case letters, spaces, apostraphe and hypen
                    ErrorMessage = "Please specify a valid name. Valid characters are a-z,A-Z,',-,"
                };

            }
        }

        /// <summary>
        /// Regex checks for LocatorID that match the following patterns:
        ///  B05789 = ANNNNN
        ///  F058N42 = ANNNANN
        ///  PE678E40 = PANNNAA
        ///  CQ678E08 = CANNNANN
        ///  OX678E68 = OANNNANN
        /// </summary>
        public static RegexValidation LocatorId
        {
            get
            {
                return new RegexValidation
                {
                    RegexJavaScript = @"^([CcPpOo]{1})?((?![IOio])[A-Za-z]{1}\d{3}(?![IiOo])[A-Za-z]{1}\d{2}|[A-Za-z]{1}\d{5})$",
                    Regex = @"^([CcPpOo]{1})?([A-Za-z-[IOio]]{1}\d{3}[A-Z-[IO]]{1}\d{2}|[A-Za-z]{1}\d{5})$",
                    ErrorMessage = "Please specify a valid locator ID"
                };

            }
        }

    }
}