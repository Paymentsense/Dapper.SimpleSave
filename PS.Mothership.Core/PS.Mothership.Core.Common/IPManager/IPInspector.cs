using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using PS.Mothership.Core.Common.Constants;

namespace PS.Mothership.Core.Common.IPManager
{
    public sealed class IPInspector
    {
        /// <summary>
        ///     Is IP Address valid
        /// </summary>
        /// <param name="ipString"></param>
        /// <returns></returns>
        public static bool IsValid(string ipString)
        {
            // Create an instance of IPAddress for the specified address string (in  
            // dotted-quad, or colon-hexadecimal notation).
            IPAddress ipAddress;
            return IPAddress.TryParse(RemoveLeadingZero(ipString), out ipAddress);
        }

        /// <summary>
        ///     Checks and gives back an ip address
        /// </summary>
        /// <param name="ipString"></param>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public static bool IsValid(string ipString, out IPAddress ipAddress)
        {
            return IPAddress.TryParse(RemoveLeadingZero(ipString), out ipAddress);
        }

        /// <summary>
        ///     Check two IpAddress are equal
        /// </summary>
        /// <param name="ipStringA"></param>
        /// <param name="ipStringB"></param>
        /// <returns></returns>
        public static bool Equal(string ipStringA, string ipStringB)
        {
            IPAddress a;
            IPAddress b;

            // if both are vaid
            if (IsValid(RemoveLeadingZero(ipStringA), out a) && IsValid(RemoveLeadingZero(ipStringB), out b))
            {
                return a.Equals(b);
            }

            // return
            return false;
        }

        /// <summary>
        ///     Compare wild card ipaddress
        /// </summary>
        /// <returns></returns>
        public static bool WildCardCompare(string ipString, List<string> ipList, char replaceCard = GlobalConstants.Star)
        {
            // if a dot comes throug as replace card, switch to '*'
            char replaceCardLocal = replaceCard == GlobalConstants.Dot ? GlobalConstants.Star : replaceCard;

            IPAddress ipAddress;
            if (!IsValid(ipString, out ipAddress)) return false;

            // ipString Loader
            // if we are we know the ipAddress is valid
            // lets build a list of ipaddress string with replace card
            // to check against the ipList
            // The ipList may contains values with replaceCard
            List<string> ipStringList = AppendOctal(ipString, replaceCardLocal);
            ipStringList.AddRange(CustomOctal(ipString, replaceCardLocal));

            // if we can find one combination in the iplist
            // set it to true
            return ipList.Intersect(ipStringList).Any();
        }

        /// <summary>
        ///     Remove leading zeros from ip address
        /// </summary>
        /// <param name="ipString"></param>
        /// <returns></returns>
        public static string RemoveLeadingZero(string ipString)
        {
            return Regex.Replace(ipString, "0*([0-9]+)", "${1}");
        }

        /// <summary>
        ///     octal/start appender
        /// </summary>
        /// <param name="ipString"></param>
        /// <param name="replaceCard"></param>
        /// <returns></returns>
        public static List<string> AppendOctal(string ipString,
            char replaceCard = GlobalConstants.Star)
        {
            var sb = new StringBuilder();
            string[] ipStringList = ipString.Split(GlobalConstants.Dot);
            int strLength = ipStringList.Length;
            var returnVal = new List<string>();

            for (int i = 0; i < strLength; i++)
            {
                // append the data
                for (int j = 0; j <= i; j++)
                {
                    sb.Append(ipStringList[j]);
                    if (j < strLength - 1) sb.Append(GlobalConstants.Dot.ToString(CultureInfo.InvariantCulture));
                }

                // loop and append the dot and replacecard data
                int charLength = strLength - (i + 1);
                for (int k = 0; k < charLength; k++)
                {
                    sb.Append(replaceCard.ToString(CultureInfo.InvariantCulture));
                    if (k != charLength - 1) sb.Append(GlobalConstants.Dot.ToString(CultureInfo.InvariantCulture));
                }

                // add to list
                // and clear the string builder
                returnVal.Add(sb.ToString());
                sb.Clear();
            }

            // return
            return returnVal;
        }

        /// <summary>
        ///     Add custom octal
        /// </summary>
        /// <param name="ipString"></param>
        /// <param name="replaceCard"></param>
        /// <returns></returns>
        public static List<string> CustomOctal(string ipString,
            char replaceCard = GlobalConstants.Star)
        {
            var sb = new StringBuilder();
            string[] ipStringList = ipString.Split(GlobalConstants.Dot);
            int strLength = ipStringList.Length;
            var returnVal = new List<string> {replaceCard.ToString(CultureInfo.InvariantCulture)};

            // Add a single star

            // Add common star
            for (int i = 0; i < strLength; i++)
            {
                // loop and append the dot and replacecard data                
                sb.Append(replaceCard.ToString(CultureInfo.InvariantCulture));
                if (i != strLength - 1) sb.Append(GlobalConstants.Dot.ToString(CultureInfo.InvariantCulture));
            }

            // add to list
            // and clear the string builder
            returnVal.Add(sb.ToString());
            sb.Clear();

            // Add country star
            sb.Append(ipStringList[0] + GlobalConstants.Dot.ToString(CultureInfo.InvariantCulture) +
                      replaceCard.ToString(CultureInfo.InvariantCulture));
            // add
            returnVal.Add(sb.ToString());
            sb.Clear();

            // Add two level
            sb.Append(ipStringList[0] + GlobalConstants.Dot.ToString(CultureInfo.InvariantCulture) +
                      ipStringList[1] + GlobalConstants.Dot.ToString(CultureInfo.InvariantCulture) +
                      replaceCard.ToString(CultureInfo.InvariantCulture));

            // add and clear
            returnVal.Add(sb.ToString());
            sb.Clear();

            // return
            return returnVal;
        }
    }
}