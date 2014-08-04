using System.Text.RegularExpressions;
using PS.Mothership.Core.Common.Constructs;

namespace PS.Mothership.Core.Common.Validation
{
    public static class GeneralRegex
    {

        public static RegexValidation AlphaOnly
        {
            get { return new RegexValidation {Regex = "", ErrorMessage = ""}; }
        }

        public static RegexValidation NumericOnly
        {

            get { return new RegexValidation {Regex = "", ErrorMessage = ""}; }
        }

        public static RegexValidation UkDate {

            get
            {
                return new RegexValidation
                {
                    Regex = @"^(((0[1-9]|[12][0-8])[\/](0[1-9]|1[012]))|((29|30|31)[\/](0[13578]|1[02]))|((29|30)[\/](0[4,6,9]|11)))[\/](19|[2-9][0-9])\d\d$)|(^29[\/]02[\/](19|[2-9][0-9])(00|04|08|12|16|20|24|28|32|36|40|44|48|52|56|60|64|68|72|76|80|84|88|92|96)$", 
                    ErrorMessage = "Please specify a valid date"
                };
            }
        }

        public static RegexValidation PhoneNumber
        {

            get
            {
                return new RegexValidation
                {
                    Regex =@"^(([-\s()]*(\+|00)?[-\s()]*353([-\s()]*\d){9,10}[-\s()]*)|([-\s()]*0?[-\s()]*[1-689]([-\s()]*\d){8,9}[-\s()]*))$", 
                    ErrorMessage = "Please specify a valid landline number"
                };              
            }
        }


        public static RegexValidation  MobilePhoneNumber 
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

    }
}