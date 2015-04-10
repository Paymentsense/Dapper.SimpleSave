using System;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Contracts
{
    public interface ICacheService
    {

        ///// <summary>
        /////     Gets the data cache object, using this the client
        /////     should reference, Microsoft.ApplicationServer.Caching
        /////     by passing right cache, the method will return
        /////     the cache in action
        ///// </summary>
        ///// <remarks>
        /////     If more functionality needed on the cache,
        /////     can use this method
        ///// </remarks>
        ///// <typeparam name="T"></typeparam>
        ///// <returns></returns>
        //T GetDataCache<T>();

        /// <summary>
        ///     Get the cache data
        /// </summary>
        /// <typeparam name="T">Runtime Type</typeparam>
        /// <param name="cacheKey">Cache Key</param>
        /// <param name="region">Name of the region to store cache objects</param>
        /// <returns></returns>
        T GetData<T>(string cacheKey, string region = null) where T : class;

        /// <summary>
        ///     Store data in cache
        /// </summary>
        /// <typeparam name="T">Runtime type</typeparam>
        /// <param name="cacheKey">Cache Key</param>
        /// <param name="type"></param>
        /// <param name="timeout">time data kept in cache</param>
        /// <param name="tags">search tag, should be of DataCacheTag, the client implmenting it should make sure it's of type DataCacheTag, 
        /// this is supported only in AppFabric </param>
        /// <param name="region">Name of the region to store cache objects</param>
        void PutData<T>(string cacheKey, T type, TimeSpan? timeout = null, IEnumerable<T> tags=null, string region=null);

        /// <summary>
        ///     Remove date from cache    
        /// </summary>
        /// <remarks>
        ///     The client should give a valid key
        /// </remarks>
        /// <param name="cacheKey">cache key</param>
        /// <param name="region">Name of the region to store cache objects</param>
        void Remove(string cacheKey, string region=null);

        /// <summary>
        ///     A value of true indicates that the region created successfully. 
        ///     A value of false indicates that the region already existed
        /// </summary>
        /// <param name="region">Name of the cache region</param>
        /// <returns></returns>
        bool CreateRegion(string region);

        /// <summary>
        ///     The name of the region whose objects are removed.
        /// </summary>
        /// <param name="region">Name of the region</param>
        void ClearRegion(string region);

        /// <summary>
        ///     Deletes a region. All cached objects inside the region are also removed.
        /// </summary>
        /// <param name="region">Name of the region</param>
        /// <returns></returns>
        bool RemoveRegion(string region);

        /// <summary>
        ///     Gets an enumerable list of all cached objects in the specified region.
        /// </summary>
        /// <param name="region">Name of the region</param>
        /// <returns></returns>
        IEnumerable<KeyValuePair<string, Object>> GetObjectsInRegion(string region);
    }
}
