using System;
using System.Security.Cryptography;

namespace PS.Mothership.Core.Common.Helper
{
    public class CryptoRandom : RandomNumberGenerator
    {
        private RandomNumberGenerator _rngGenerator;

        /// <summary>
        ///     Crypto Random number generator
        /// </summary>
        /// <remarks>
        /// if the random generator is not working let look
        /// into 'RNGCryptoServiceProvider'
        /// http://msdn.microsoft.com/en-us/library/system.security.cryptography.rngcryptoserviceprovider.aspx            
        /// </remarks>
        public CryptoRandom()
        {
            _rngGenerator = Create();
        }

        public RandomNumberGenerator RngGenerator
        {
            get { return _rngGenerator; }
            set { _rngGenerator = value; }
        }

        public override void GetBytes(byte[] data)
        {
            _rngGenerator.GetBytes(data);
        }

        ///<summary>
        /// Returns a random number between 0.0 and 1.0.
        ///</summary>
        public double NextDouble()
        {
            var b = new byte[100];
            _rngGenerator.GetBytes(b);
            return (double)BitConverter.ToUInt32(b, 0) / UInt32.MaxValue;
        }

        /// <summary>
        ///  Returns a random number within the specified range.
        /// </summary>       
        public long Next(int minValue, int maxValue)
        {
            var range = (long)(maxValue - minValue);
            return (long)(Math.Round(NextDouble() * range) + minValue);
        }

        ///<summary>
        /// Returns a nonnegative random number.
        ///</summary>
        public long Next()
        {
            return Next(0, Int32.MaxValue);
        }

        /// <summary>
        ///  Returns a nonnegative random number less than the specified maximum
        /// </summary>        
        /// <param name="maxValue">The inclusive upper bound of the random number returned. maxValue must be greater than or equal 0</param>
        public long Next(int maxValue)
        {
            return Next(0, maxValue);
        }
    }
}
