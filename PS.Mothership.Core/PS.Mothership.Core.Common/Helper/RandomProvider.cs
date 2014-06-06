using System;
using System.Threading;

namespace PS.Mothership.Core.Common.Helper
{
    /// <summary>
    ///     Random number provider, per thread
    /// </summary>  
    public static class RandomProvider
    {
        private static int _seed = Environment.TickCount;

        private static readonly ThreadLocal<Random> RandomWrapper = new ThreadLocal<Random>(() =>
            new Random(Interlocked.Increment(ref _seed)));

        private static readonly ThreadLocal<CryptoRandom> RandomCryptoWrapper = new ThreadLocal<CryptoRandom>(() =>
            new CryptoRandom());

        /// <summary>
        ///     Get Random object
        /// </summary>
        /// <returns></returns>
        public static Random GetThreadRandom()
        {
            return RandomWrapper.Value;
        }

        /// <summary>
        ///     Get Crypto Random object
        /// </summary>
        /// <returns></returns>
        public static CryptoRandom GetThreadCryptoRandom()
        {
            return RandomCryptoWrapper.Value;
        }        
    }
}