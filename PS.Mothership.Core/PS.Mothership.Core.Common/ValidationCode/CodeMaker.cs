using PS.Mothership.Core.Common.Helper;

namespace PS.Mothership.Core.Common.ValidationCode
{
    public sealed class CodeMaker
    {
               
        private const int Min = 100000;
        private const int Max = 999999;

        /// <summary>
        ///     Generate a unique validation code
        ///     using random provider
        /// </summary>
        /// <returns></returns>
        public static long GenerateCode(int minValue=0, int maxValue=0)
        {
            var random = RandomProvider.GetThreadRandom();
            if (minValue <= 0) minValue = Min;
            if (maxValue <= 0) maxValue = Max;
            return random.Next(minValue, maxValue);            
        }

        public static long GenerateCodeUsingCrypto(int minValue = 0, int maxValue = 0)
        {
            var cryptoRandom = RandomProvider.GetThreadCryptoRandom();
            if (minValue <= 0) minValue = Min;
            if (maxValue <= 0) maxValue = Max;
            return cryptoRandom.Next(minValue, maxValue);     
        }
    }
}
