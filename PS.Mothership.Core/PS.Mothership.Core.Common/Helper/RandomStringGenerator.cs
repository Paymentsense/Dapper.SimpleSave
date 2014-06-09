using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Helper
{
    public class RandomStringGenerator
    {
        /// <summary>
        /// Generates a random string making sure that there are letters and numbers in the final string.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Generate(int length)
        {
            //Removed O, o, 0, l, 1
            const string allowedLetterChars = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ";
            const string allowedNumberChars = "23456789";
            var chars = new char[length];
            var useLetter = true;
            for (var i = 0; i < length; i++)
            {
                if (useLetter)
                {
                    chars[i] = allowedLetterChars[RandomProvider.GetThreadRandom().Next(0, allowedLetterChars.Length)];
                    useLetter = false;
                }
                else
                {
                    chars[i] = allowedNumberChars[RandomProvider.GetThreadRandom().Next(0, allowedNumberChars.Length)];
                    useLetter = true;
                }
            }
            return new string(chars);
        }
    }
}
