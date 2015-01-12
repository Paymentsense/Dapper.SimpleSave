using System;

namespace PS.Mothership.Core.Common.Contracts
{
    /// <summary>
    /// This is a wrapper classes around log4net for logging
    /// </summary>
    public interface IMSLogger
    {
        bool IsDebugEnabled { get; }
        bool IsInfoEnabled { get; }
        bool IsWarnEnabled { get; }
        bool IsErrorEnabled { get; }
        bool IsFatalEnabled { get; }
        void Debug(object message);
        void DebugFormat(string format, params object[] args);
        void Info(object message);
        void InfoFormat(string format, params object[] args);
        void InfoFormat(string format, object arg0);
        void InfoFormat(string format, object arg0, object arg1);
        void Warn(object message);
        void WarnFormat(string format, params object[] args);
        void WarnFormat(string format, object arg0);
        void WarnFormat(string format, object arg0, object arg1);
        /// <summary>
        /// Logs errors with a UniqueKey and associated exceptionobject
        /// </summary>
        /// <param name="uniqueKey">This has to be UniqueKey, not general message</param>
        /// <param name="exception">Exception object</param>
        void Error(string uniqueKey, Exception exception);
    }
}