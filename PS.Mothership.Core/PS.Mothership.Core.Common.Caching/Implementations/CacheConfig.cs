using System.Configuration;
using PS.Mothership.Core.Common.Caching.Contracts;
using PS.Mothership.Core.Common.Constants;

namespace PS.Mothership.Core.Common.Caching.Implementations
{
    public class CacheConfig : ICacheConfig
    {
        public string CacheName
        {
            get
            {
                return GetCacheConfig(ConfigurationConstants.CacheName, ExceptionConstants.CacheNameDoesNotExist);
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
