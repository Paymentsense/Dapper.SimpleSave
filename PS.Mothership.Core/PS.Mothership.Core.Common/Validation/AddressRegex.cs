using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Constructs;

namespace PS.Mothership.Core.Common.Validation
{
    public static class AddressRegex
    {

        public static RegexValidation PostCode
        {
            get
            {
                return new RegexValidation()
                {
                    //Regex = @"^(([Rr][Oo][Ii])|([Gg][Ii][Rr] 0[Aa][Aa]|[A-PR-UWYZa-pr-uwyz]([0-9][0-9A-HJKPS-UWa-hjkps-uw]?|[A-HK-Ya-hk-y][0-9][0-9ABEHMNPRV-Yabehmnprv-y]?)\s?[0-9][ABD-HJLNP-UW-Zabd-hjlnp-uw-z]{2}))$",
                    
                    Regex = @"^(GIR 0AA)|(((A[BL]|B[ABDHLNRSTX]?|C[ABFHMORTVW]|D[ADEGHLNTY]|E[HNX]?|F[KY]|G[LUY]?|H[ADGPRSUX]|I[GMPV]|JE|K[ATWY]|L[ADELNSU]?|M[EKL]?|N[EGNPRW]?|O[LX]|P[AEHLOR]|R[GHM]|S[AEGKLMNOPRSTY]?|T[ADFNQRSW]|UB|W[ADFNRSV]|YO|ZE)[1-9]?[0-9]|((E|N|NW|SE|SW|W)1|EC[1-4]|WC[12])[A-HJKMNPR-Y]|(SW|W)([2-9]|[1-9][0-9])|EC[1-9][0-9])( [0-9][ABD-HJLNP-UW-Z]{2})?)$",
                    
                    //Regex = @"(GIR 0AA)|((([A-Z-[QVX]][0-9][0-9]?)|(([A-Z-[QVX]][A-Z-[IJZ]][0-9][0-9]?)|(([A-Z-[QVX]][0-9][A-HJKSTUW])|([A-Z-[QVX]][A-Z-[IJZ]][0-9][ABEHMNPRVWXY])))) [0-9][A-Z-[CIKMOV]]{2})",
                    ErrorMessage = "Please specify a valid postcode"
                };
            }
        }


    }
}
