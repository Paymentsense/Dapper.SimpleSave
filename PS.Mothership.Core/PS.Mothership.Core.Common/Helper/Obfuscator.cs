using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Constants;

namespace PS.Mothership.Core.Common.Helper
{
    public static class Obfuscator
    {        
        /// <summary>
        ///     Obfuscate the email address
        /// </summary>
        /// <remarks>
        ///     Proper e-mail validation should have 
        ///     done either during email address capturing
        ///     or loading into user object.
        ///     This method job is just to obfuscate an email
        ///     string.
        /// </remarks>
        /// <param name="email">email to obfuscate</param>
        /// <returns></returns>
        public static string Email(string email)
        {
            if(string.IsNullOrWhiteSpace(email)) return null;

            // lets get the email length before @ sign
            var atSignLength = email.IndexOf(GlobalConstants.At, 0);

            // if no AT (@) sign, we don't have a valid email address
            // basic checking
            if(atSignLength <= 0) return null;

            // find the random numbers
            // to insert stars
            var random = RandomProvider.GetThreadRandom();
            var randomList = new List<int>();
            var conversion = (long) Math.Round((decimal) atSignLength/2);
            if (conversion != 0)
            {
                for (var i = 0; i < conversion; i++)
                {
                    var no = random.Next(i, atSignLength);
                    if (!randomList.Contains(no)) randomList.Add(no);
                }
            }
            else
            {
                randomList.Add(0);
            }


            // get the length
            var phoneLength = email.Length;

            // add some buffer to the string builder
            var sb = new StringBuilder(email.Length + 10);

            for (var i = 0; i < phoneLength; i++)
            {               
                // append star // will replace this
                sb.Append(randomList.Contains(i) ? GlobalConstants.Star : email[i]);
            }

            // return
            return sb.ToString();            
        }

        /// <summary>
        ///     Obfuscate the phone number -
        ///     the numbers will be filled
        ///     with stars just showing the last
        ///     4 or digits to show
        /// </summary>
        /// <remarks>
        ///     Proper phone number validation should have 
        ///     done either during phone number capturing
        ///     or loading into user object.
        ///     This method job is just to obfuscate an phone
        ///     number string.
        /// </remarks>
        /// <param name="phone">Phone number</param>
        /// <param name="digitsToShow">the last number of digits to show</param>
        /// <returns></returns>
        public static string Phone(string phone, int digitsToShow=4)
        {
            if (string.IsNullOrWhiteSpace(phone)) return null;
            if (digitsToShow < 0) digitsToShow = 4;

            // make all the character *
            // except the last four digits (digitsToShow)            
            var phoneLength = phone.Length;
            var startShowing = phoneLength - digitsToShow;

            // add some buffer to the string builder
            var sb = new StringBuilder(phone.Length + startShowing);

            for (var i = 0; i < phoneLength; i++)
                sb.Append(i < startShowing ? GlobalConstants.Star : phone[i]);            

            return sb.ToString();
        }
    }    
}
