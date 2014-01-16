using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Contracts
{
    public interface ICacheService
    {
        /// <summary>
        ///     Get the cache data
        /// </summary>
        /// <typeparam name="T">Runtime Type</typeparam>
        /// <param name="cacheKey">Cache Key</param>
        /// <returns></returns>
        T GetData<T>(string cacheKey);

        /// <summary>
        ///     Store data in cache
        /// </summary>
        /// <typeparam name="T">Runtime type</typeparam>
        /// <param name="cacheKey">Cache Key</param>
        /// <param name="type"></param>
        /// <param name="timeout">time data kept in cache</param>
        /// <param name="tags">search tag, should be of DataCacheTag, the client implmenting it should make sure it's of type DataCacheTag, 
        /// this is supported only in AppFabric </param>
        void PutData<T>(string cacheKey, T type, TimeSpan? timeout = null, IEnumerable<T> tags=null);

        /// <summary>
        ///     Remove date from cache    
        /// </summary>
        /// <remarks>
        ///     The client should give a valid key
        /// </remarks>
        /// <param name="cacheKey">cache key</param>
        void Remove(string cacheKey);
    }
}
