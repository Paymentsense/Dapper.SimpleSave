using System;
using System.Collections.Generic;
using Microsoft.ApplicationServer.Caching;
using PS.Mothership.Caching.Contracts;
using PS.Mothership.Core.Common.Contracts;

namespace PS.Mothership.Caching.Implementations
{
    public class CacheService : ICacheService
    {
        private readonly DataCache _dataCache;

        public CacheService(DataCacheFactory dataCacheFactory, ICacheConfig cacheConfig)
        {
            _dataCache = dataCacheFactory.GetCache(cacheConfig.CacheName) ?? dataCacheFactory.GetDefaultCache();
        }

        /// <summary>
        ///     Get the cache data
        /// </summary>
        /// <typeparam name="T">Runtime Type</typeparam>
        /// <param name="cacheKey">Cache Key</param>
        /// <param name="region">Name of the region to store cache objects</param>
        /// <returns></returns>
        public T GetData<T>(string cacheKey, string region = null)
        {
            if(string.IsNullOrWhiteSpace(region))
                return (T)_dataCache.Get(cacheKey);

            // if region passed
            return (T)_dataCache.Get(cacheKey, region);
        }


        /// <summary>
        ///     Store data in cache
        /// </summary>
        /// <typeparam name="T">Runtime type</typeparam>
        /// <param name="cacheKey">Cache Key</param>
        /// <param name="type"></param>
        /// <param name="timeout">time data kept in cache</param>
        /// <param name="tags">search tag, should be of DataCacheTag, the client implmenting it should make sure it's of type DataCacheTag, 
        /// this is supported only in AppFabric </param>
        /// <param name="region">Name of the region to store cache objects, make sure the region exist before storing information</param>
        public void PutData<T>(string cacheKey, T type, TimeSpan? timeout = null,
            IEnumerable<T> tags = null, string region = null)
        {
            // nullable time span not allowed for Cache api,
            // so convert to non-nullable before using it
            var timeSpan = timeout ?? new TimeSpan();

            // tags will be implemented in latter stage

            // timeout is null, lets use the default
            if (timeout != null)
            {
                if (string.IsNullOrWhiteSpace(region))
                    _dataCache.Put(cacheKey, type, timeSpan);
                else
                    _dataCache.Put(cacheKey, type, timeSpan, region);                
            }
            else
            {
                if (string.IsNullOrWhiteSpace(region))
                    _dataCache.Put(cacheKey, type);
                else
                    _dataCache.Put(cacheKey, type, region);                
            }
        }

        /// <summary>
        ///     Remove data from cache
        /// </summary>
        /// <remarks>
        ///     The client should provide a valid key, 
        ///     If region name not given, the cache will be stored in the
        ///     cluster of cache
        /// </remarks>
        /// <param name="cacheKey">cache key</param>
        /// <param name="region">Name of the region to store cache objects</param>
        public void Remove(string cacheKey, string region = null)
        {
            // if region not passed
            if (string.IsNullOrWhiteSpace(region))
            {
                _dataCache.Remove(cacheKey);
                return;
            }
            // if region passed
            _dataCache.Remove(cacheKey, region);
        }

        /// <summary>
        ///     A value of true indicates that the region created successfully. 
        ///     A value of false indicates that the region already existed
        ///     If the region need to be re-created use remove region <c ref="RemoveRegion"></c>
        ///     and create the new region. This behaviour is used so the client won't lose the cache region
        ///     by mistake
        /// </summary>
        /// <remarks>
        ///     Please use the PS.Mothership.Core.Common.Constants "CacheRegionConstants.cs"
        ///     to name the regions. This way it's easy to manage
        /// </remarks>
        /// <param name="region">Name of the cache region</param>
        /// <returns></returns>
        public bool CreateRegion(string region)
        {
            if (string.IsNullOrWhiteSpace(region))
                throw new ArgumentNullException("region");
            return _dataCache.CreateRegion(region);
        }

        /// <summary>
        ///     The name of the region whose objects are removed.
        ///     This wont remove the region, only the objects within the region,
        ///     To remove the region see <c ref="RemoveRegion"></c> 
        /// </summary>
        /// <param name="region">Name of the region</param>
        public void ClearRegion(string region)
        {
            if (string.IsNullOrWhiteSpace(region))
                throw new ArgumentNullException("region");
            _dataCache.ClearRegion(region);
        }

        /// <summary>
        ///     Deletes a region. All cached objects inside the region are also removed.
        /// </summary>
        /// <param name="region">Name of the region</param>
        /// <returns></returns>
        public bool RemoveRegion(string region)
        {
            if (string.IsNullOrWhiteSpace(region))
                throw new ArgumentNullException("region");
            return _dataCache.RemoveRegion(region);
        }

        /// <summary>
        ///     Gets an enumerable list of all cached objects in the specified region.
        /// </summary>
        /// <param name="region">Name of the region</param>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, object>> GetObjectsInRegion(string region)
        {
            if (string.IsNullOrWhiteSpace(region))
                throw new ArgumentNullException("region");
            return _dataCache.GetObjectsInRegion(region);
        }
    }
}
