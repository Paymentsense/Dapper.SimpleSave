using PS.Mothership.Core.Common.Constructs;

namespace PS.Mothership.Core.Common.Validation
{
    public static class AddressRegex
    {

        /// <summary>
        /// Regex checks UK postcodes plus ROI (to currently handle RoI addresses)
        /// </summary>
        public static RegexValidation PostCode
        {
            get
            {
                return new RegexValidation()
                {

                    Regex = @"^(([Rr][Oo][Ii])|([Gg][Ii][Rr] 0[Aa][Aa]|[A-PR-UWYZa-pr-uwyz]([0-9][0-9A-HJKPS-UWa-hjkps-uw]?|[A-HK-Ya-hk-y][0-9][0-9ABEHMNPRV-Yabehmnprv-y]?)\s?[0-9][ABD-HJLNP-UW-Zabd-hjlnp-uw-z]{2}))$",
                    ErrorMessage = "Please specify a valid postcode"
                };
            }
        }
    }
}
