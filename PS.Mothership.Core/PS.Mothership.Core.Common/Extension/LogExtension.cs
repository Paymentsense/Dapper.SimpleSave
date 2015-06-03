using log4net;
using log4net.Core;

namespace PS.Mothership.Core.Common.Extension
{
    public static class LogExtension
    {
        public static void Notice(this ILog log, string format)
        {
            log.Logger.Log(null, Level.Notice, format, null);
        }

        public static void Notice(this ILog log, string format, params object[] args)
        {
            log.Logger.Log(null, Level.Notice, string.Format(format, args), null);
        }
    }
}
