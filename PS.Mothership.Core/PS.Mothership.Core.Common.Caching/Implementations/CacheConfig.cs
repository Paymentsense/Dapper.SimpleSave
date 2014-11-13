using System.Configuration;
using PS.Mothership.Caching.Contracts;
using PS.Mothership.Core.Common.Constants;

namespace PS.Mothership.Caching.Implementations
{
    public class CacheConfig : ICacheConfig
    {
        public string CacheName
        {
            get
            {
                return GetCacheConfig(ConfigConstants.CacheName, ExceptionConstants.CacheNameDoesNotExist);
            }
        }

        private static string GetCacheConfig(string key, string exceptionMsg)
        {
            var value = ConfigurationManager.AppSettings.Get(key);
            if (value != null)
            {
                return value;
            }
            throw new ConfigurationErrorsException(exceptionMsg);
        }
    }
}
