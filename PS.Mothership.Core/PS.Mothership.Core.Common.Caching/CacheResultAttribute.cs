using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Castle.DynamicProxy;
using PS.Mothership.Core.Common.Contracts;
using PS.Mothership.Core.Common.Enums;
using PS.Mothership.Core.Common.Helper;

namespace PS.Mothership.Core.Common.Caching
{
    /// <summary>
    ///     Provider for method caching using interceptor. Works on cross class method calls only.
    /// </summary>
    /// <remarks>
    ///     Parameters which can be passed from WCF operations
    ///     1. Key
    ///     -- Optional, if defined take priority over KeyOrdinal and None
    ///     2. KeyOrdinal
    ///     -- Optional, if defined take priority over None  -- For now we are not going to support this
    ///     3. VaryByOperation
    ///     -- Optional, by default its set to false, take the operation name and prefix it with the key -- make this as
    ///     default, we are not going to expose this
    ///     4. None
    ///     -- default, will pick the incoming parameter as Key
    ///     5. RegionName
    ///     --  Optional, this is to define whether the cache would be stored in a region
    ///     -- this option is usefull if the client want to clear the entire cache for a product,
    ///     -- by using the region, its easier to clear the entire region
    ///     read about regions - http://msdn.microsoft.com/en-us/library/ee790985(v=azure.10).aspx
    /// </remarks>
    [AttributeUsage(AttributeTargets.Method)]
    public class CacheResultAttribute : Attribute//, IOperationBehavior, IOperationInvoker
    {
        private ICacheService _cache;
        private string[] _parameterNames;

        #region future support

        //private int _keyOrdinal = -1;
        //public int KeyOrdinal
        //{
        //    get { return _keyOrdinal; }
        //    //set { _keyOrdinal = value; }
        //}
        /// <summary>
        ///     The KeyOrdinal is not going to be supported
        ///     this phase, if we need to support it, uncomment the
        ///     the property KeyOrdinal, this will be exposed
        ///     to the wcf client
        /// </summary>
        /// <summary>
        ///     Cache based on OperationContract name, default set to true
        /// </summary>
        /// <remarks>
        ///     The Method name in the below  are same, if want to key the cache prefixed by
        ///     operation name by setting VaryByOperation will prefix the name to the cachekey
        ///     By default its set to 'true'
        /// </remarks>
        /// <example ref="example">
        ///     [OperationContract(Name = "GetPermissionsById")]
        ///     IEnumerable<UserPermissionDto /> GetPermissions(long userId, long resourcesId, bool ignoreUser = true);
        ///     [OperationContract(Name = "GetPermissionsByName")]
        ///     IEnumerable<UserPermissionDto /> GetPermissions(long userId, string resourcesName, bool ignoreUser = true);
        /// </example>
        /// un comment if vary by operation supported wanted
        //private bool _varyByOperation = true;
        //public bool VaryByOperation
        //{
        //    get { return _varyByOperation; }
        //    set { _varyByOperation = value; }
        //}

        #endregion
        public string Key { get; set; }

        private const int KeyOrdinal = 0;

        public int Days { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int MilliSeconds { get; set; }

        // Name of the region
        public string RegionName = null;

        // action on region
        public RegionAction RegionAction = RegionAction.None;

        // remove key
        public bool RemoveKey;

        public object GetOrCacheRequest(ICacheService cache, IInvocation invocation)
        {
            // return nothing if cache is not available
            if (cache == null)
                return null;

            // Initialize the cache
            if (_cache == null)
            {
                _cache = cache;
            }

            _parameterNames = invocation.MethodInvocationTarget.GetParameters().Select(x => x.Name).ToArray();

            // if RegionAction is set to clear to remove
            // ignore the caching and return
            if (_cache != null && !string.IsNullOrWhiteSpace(RegionName))
            {
                switch (RegionAction)
                {
                    case RegionAction.Clear:
                        {
                            _cache.ClearRegion(RegionName);
                            return null;
                        }
                    //case RegionAction.Remove:
                    //{
                    //    _cache.RemoveRegion(RegionName);
                    //    noCache = true;
                    //    break;
                    //}
                    case RegionAction.None:
                        {
                            // if no action given, set region name to null
                            // Need to discuss about this logic, for now the default is don't 
                            // save the data in distributed cache, if no action is given
                            RegionName = null;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }

            // if remove key coming through, remove the key and return nothing
            if (_cache != null && RemoveKey && !string.IsNullOrWhiteSpace(Key))
            {
                _cache.Remove(Key, RegionName);
                return null;
            }

            // key storage
            ServiceCacheData cacheData = null;

            var inputs = invocation.Arguments;

            // lets map the parameter name for incoming inputs
            var inputsMapper = new Dictionary<string, object>(inputs.Length + 1);
            for (int i = 0; i < inputs.Length; i++)
            {
                string param = _parameterNames[i];
                if (!inputsMapper.ContainsKey(param))
                    inputsMapper.Add(param, inputs[i]);
            }

            // 0. Use Parameter as key, this is default
            // 1. Key
            // 2. KeyOrdinal            
            int priority = 0;

            // key check
            if (!string.IsNullOrWhiteSpace(Key)) priority = 1;

            // Uncomment this if KeyOrdinal support needed
            // ordinal check
            // chekc whether the length of the keyOrdinal is larger
            // than the incoming parameters
            //if (priority == 0 && (KeyOrdinal >= 0 && KeyOrdinal <= inputs.Length - 1))            
            //  priority = 2;                            

            // set up the key
            string generatedKey;
            switch (priority)
            {
                case 1:
                    {
                        generatedKey = Key;
                        break;
                    }
                case 2:
                    {
                        string keyOrdinalString = _parameterNames[KeyOrdinal];
                        Dictionary<string, object> dict =
                            inputsMapper.Where(d => d.Key == keyOrdinalString)
                                .ToDictionary(k => k.Key, v => v.Value);
                        generatedKey = JsonHelper.ConvertToJson(dict);
                        break;
                    }
                default:
                    {
                        generatedKey = JsonHelper.ConvertToJson(inputsMapper);
                        break;
                    }
            }

            // if the client wanted to store the key based on Operation
            // lets prefix with service type and operation name, so the key would be unique
            generatedKey = invocation.TargetType.FullName + "_" + invocation.Method.Name + "_" + generatedKey;


            // check cache status
            if (_cache == null)
            {
                Trace.WriteLine("Cache Not Set");
            }
            else
            {
                cacheData = _cache.GetData<ServiceCacheData>(generatedKey, RegionName);
            }

            Trace.WriteLine(string.Format("Method:{0},Inputs/Key:{1}", "Invoke", generatedKey));

            // if we have data in cache, return the data from cache, if not
            // fall through to the next stage
            if (cacheData != null)
            {
                //Trace.WriteLine(string.Format("Method:{0},From:{1},Data:{2}", "Invoke", "Cache", cacheData.Value));
                //outputs = cacheData.Outputs;
                return cacheData.Value;
            }

            // if not in cache
            invocation.Proceed();
            //Trace.WriteLine(string.Format("Method:{0},Value:{1}", "Invoke", JsonHelper.ConvertToJson(value)));

            // store in cache
            var storeData = new ServiceCacheData { Outputs = null, Value = invocation.ReturnValue };

            // set up the time Out
            TimeSpan? timeOut = null;
            // one of them should have a value, if not lets do the cache take the default time
            if (Days != 0 || Hours != 0 || Minutes != 0 || Seconds != 0 || MilliSeconds != 0)
                timeOut = new TimeSpan(Days, Hours, Minutes, Seconds, MilliSeconds);
            else
                return storeData.Value;

            // before adding check the cache
            if (!string.IsNullOrWhiteSpace(RegionName) &&
                RegionAction == RegionAction.DoCreateIfNotExists)
            {
                bool isRegionCreated = _cache.CreateRegion(RegionName);
                Trace.WriteLine(isRegionCreated
                    ? string.Format("Region : {0} : Created", RegionName)
                    : string.Format("Region : {0} : Not Created, or already exists", RegionName));
            }

            // store it in cache
            _cache.PutData(generatedKey, storeData, timeOut, region: RegionName);

            // return
            return storeData.Value;
        }
    }
}