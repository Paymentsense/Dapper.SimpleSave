using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Helper
{
    public sealed class AddressSplitter
    {

        private static readonly char[] AllowedCharacters = {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '-', '/'};
                

        /// <summary>
        ///     Splits the number and address of full address
        /// </summary>        
        /// <param name="fullAddress"></param>        
        /// <returns></returns>
        public static string SplitHouseNumber(string fullAddress)
        {
            if (string.IsNullOrWhiteSpace(fullAddress)) return string.Empty;

            // check whether the first character is a number
            var result = 0;
            if (!int.TryParse(fullAddress[0].ToString(CultureInfo.InvariantCulture), out result)) return string.Empty;

            // create string builder
            var houseNumber = new StringBuilder(fullAddress.Length);

            for(int i=0; i <= fullAddress.Length; i++)
            {
                int pos = Array.IndexOf(AllowedCharacters, fullAddress[i]);
                if (pos > -1)
                {
                    houseNumber.Append(fullAddress[i].ToString(CultureInfo.InvariantCulture));
                    continue;
                }
                // if here break
                break;
            }

            return houseNumber.ToString();
        }

        /// <summary>
        ///     Splits the number and address 
        /// </summary>
        /// <param name="fullAddress"></param>
        /// <returns>house number, address</returns>
        public static Tuple<string, string> SplitHouseNumberAndAddress(string fullAddress)
        {
            var tuple = Tuple.Create(string.Empty, fullAddress);
            if (string.IsNullOrWhiteSpace(fullAddress)) return tuple;

            // check whether the first character is a number
            var result = 0;
            if (!int.TryParse(fullAddress[0].ToString(CultureInfo.InvariantCulture), out result)) return tuple;            

            // create string builder
            var houseNumber = new StringBuilder(fullAddress.Length);
            var address = string.Empty;
            int numberOfCharAdded = 0;

            for (int i = 0; i <= fullAddress.Length; i++)
            {
                int pos = Array.IndexOf(AllowedCharacters, fullAddress[i]);
                if (pos > -1)
                {
                    houseNumber.Append(fullAddress[i].ToString(CultureInfo.InvariantCulture));
                    numberOfCharAdded++;
                    continue;
                }                

                // if here take the remaning address and break
                address = fullAddress.Substring(numberOfCharAdded);
                break;
            }

            // return
            return Tuple.Create(houseNumber.ToString(), address.Trim());

        }

    }    
}
