using System.ComponentModel;

namespace PS.Mothership.Core.Common.Config
{
    public enum WcfMode
    {
        [Description("Running everything in process, on the same physical tier")]
        InProcess,
        [Description("Running on Web Server or other frontend, in WCF client mode, connecting to WCF services hosted on a separate physical tier")]
        ClientSide,
        [Description("Running on a separate WCF Application Server, hosting the WCF services")]
        ServerSide
    }
}