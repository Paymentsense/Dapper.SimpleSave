namespace PS.Mothership.Core.Common.Caching
{
    /// <summary>
    ///     Store value and outputs 
    /// </summary>
    public class ServiceCacheData
    {
        public object Value { get; set; }
        public object[] Outputs { get; set; }
    }
}
