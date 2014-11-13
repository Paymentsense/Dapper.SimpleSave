using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Enums;
using PS.Mothership.Core.Common.Contracts;
using PS.Mothership.Core.Common.Helper;

namespace PS.Mothership.Caching.Service
{
    /// <summary>
    ///     Provider for caching
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
    public class WcfCacheResultAttribute : Attribute, IOperationBehavior, IOperationInvoker
    {
        private ICacheService _cache;
        private ServiceHostBase _serviceHost;
        private IOperationInvoker _innerOperationInvoker;
        private string _operationName;
        private string[] _parameterNames;
        private object[] _outputs;

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

        public WcfCacheResultAttribute(ICacheService cache)
        {
            _cache = cache;
        }

        public WcfCacheResultAttribute(ServiceHostBase serviceHost, ICacheService cache)
        {
            _serviceHost = serviceHost;
            _cache = cache;
        }

        #region Implementation of IOperationBehavior Member

        public void AddBindingParameters(OperationDescription operationDescription,
            BindingParameterCollection bindingParameters)
        {
            //Trace.WriteLine("AddBindingParameters");
            // If want to bind new parameters
        }

        /// <summary>
        ///     Implements a modification or extension of the client across an operation.
        /// </summary>
        /// <param name="operationDescription">
        ///     The operation being examined. Use for examination only. If the operation description
        ///     is modified, the results are undefined.
        /// </param>
        /// <param name="clientOperation">
        ///     The run-time object that exposes customization properties for the operation described by
        ///     <paramref name="operationDescription" />.
        /// </param>
        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
            //Trace.WriteLine("ApplyClientBehavior");
            // Do any client behaviour logic here
        }

        /// <summary>
        ///     Implements a modification or extension of the service across an operation.
        /// </summary>
        /// <param name="operationDescription">
        ///     The operation being examined. Use for examination only. If the operation description
        ///     is modified, the results are undefined.
        /// </param>
        /// <param name="dispatchOperation">
        ///     The run-time object that exposes customization properties for the operation described
        ///     by <paramref name="operationDescription" />.
        /// </param>
        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            Trace.WriteLine(string.Format("Method:{0},Name:{1}", "ApplyDispatchBehavior", operationDescription.Name));
            _innerOperationInvoker = dispatchOperation.Invoker;
            dispatchOperation.Invoker = this;
            // name of the method
            _operationName = operationDescription.Name;
            // name of the parameters
            _parameterNames = operationDescription.Messages[0].Body.Parts
                .OrderBy(mpd => mpd.Index)
                .Select(mpd => mpd.Name)
                .ToArray();
        }

        /// <summary>
        ///     Implements a modification or extension of the service across an operation.
        /// </summary>
        /// <param name="operationDescription">
        ///     The operation being examined. Use for examination only. If the operation description
        ///     is modified, the results are undefined.
        /// </param>
        public void Validate(OperationDescription operationDescription)
        {
            //Trace.WriteLine("Validate");
            // Any Validation, do it here
        }

        #endregion

        #region Implementation of IOperationInvoker Member

        public object[] AllocateInputs()
        {
            //Trace.WriteLine("AllocateInputs");
            return _innerOperationInvoker.AllocateInputs();
        }

        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {
            // Initialize the cache
            if (_cache == null)
            {
                // try to get the host from the context
                if (_serviceHost == null)
                    _serviceHost = OperationContext.Current.Host;
            }

            // if RegionAction is set to clear to remove
            // ignore the caching and return
            bool noCache = false;
            if (_cache != null && !string.IsNullOrWhiteSpace(RegionName))
            {
                switch (RegionAction)
                {
                    case RegionAction.Clear:
                    {
                        _cache.ClearRegion(RegionName);
                        noCache = true;
                        break;
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

            // if remove key coming through, remove the key and return by setting nocache to true
            // here region name is optional
            if (_cache != null && RemoveKey && !string.IsNullOrWhiteSpace(Key))
            {
                _cache.Remove(Key,RegionName);
                noCache = true;
            }
            
            // if no cache needed return back
            if (noCache) return _innerOperationInvoker.Invoke(instance, inputs, out outputs);

            // key storage
            ServiceCacheData cacheData = null;

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
            generatedKey = _serviceHost.Description.ServiceType.FullName + "_" + _operationName + "_" + generatedKey;


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
                outputs = cacheData.Outputs;
                return cacheData.Value;
            }

            // if not in cache
            object value = _innerOperationInvoker.Invoke(instance, inputs, out outputs);
            //Trace.WriteLine(string.Format("Method:{0},Value:{1}", "Invoke", JsonHelper.ConvertToJson(value)));

            // if cach is null return value
            if (_cache == null) return value;

            // store in cache
            var storeData = new ServiceCacheData {Outputs = outputs, Value = value};

            // set up the time Out
            TimeSpan? timeOut = null;
            // one of them should have a value, if not lets do the cache take the default time
            if (Days != 0 || Hours != 0 || Minutes != 0 || Seconds != 0 || MilliSeconds != 0)
                timeOut = new TimeSpan(Days, Hours, Minutes, Seconds, MilliSeconds);

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
            return value;
        }

        public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
        {
            //Trace.WriteLine("InvokeBegin");
            Task<object> f = Task<object>.Factory.StartNew(o => Invoke(instance, inputs, out _outputs), state);
            if (callback != null) f.ContinueWith(res => callback(f));

            return f;
        }

        public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
        {
            //Trace.WriteLine("InvokeEnd");
            outputs = _outputs;
            return ((Task<object>) result).Result;
        }

        public bool IsSynchronous
        {
            get { return _innerOperationInvoker.IsSynchronous; }
        }

        #endregion

        //#region Implementation of IParameterInspector Member

        //public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        //{
        //    Debug.WriteLine("IParameterInspector.AfterCall called for {0} with return value {1}.",operationName,returnValue.ToString());
        //}

        //public object BeforeCall(string operationName, object[] inputs)
        //{
        //    Debug.WriteLine("IParameterInspector.BeforeCall called for {0} with return value {1}.", operationName, inputs.ToString());
        //    return null;
        //}

        //#endregion
    }
}