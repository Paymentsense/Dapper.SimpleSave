using System;
using log4net;
using PS.Mothership.Core.Common.Contracts;
using PS.Mothership.Core.Common.Log4NetJsonFormatter;

namespace PS.Mothership.Core.Common.Helper
{
    public class MSLogger : IMSLogger
    {
        public ILog Logger { get; set; }
        
        public MSLogger(string assemblyName, string applicationName)
        {
            var a = new JsonPatternLayoutConverter();
            JsonPatternLayoutConverter.AssemblyName = assemblyName;
            JsonPatternLayoutConverter.ApplicationName = applicationName;
        }

        #region IMSlogger Members

        #region public properties


        public bool IsDebugEnabled
        {
            get
            {
                return Logger.IsDebugEnabled;
            }
        }

        public bool IsInfoEnabled
        {
            get
            {
                return Logger.IsInfoEnabled;
            }
        }

        public bool IsWarnEnabled
        {
            get
            {
                return Logger.IsWarnEnabled;
            }
        }

        public bool IsErrorEnabled
        {
            get
            {
                return Logger.IsErrorEnabled;
            }
        }

        public bool IsFatalEnabled
        {
            get
            {
                return Logger.IsFatalEnabled;
            }
        }

        #endregion

        public void Debug(object message)
        {
            Logger.Debug(message);
        }

        public void DebugFormat(string format, params object[] args)
        {
            Logger.DebugFormat(format,args);
        }

        public void Info(object message)
        {
            Logger.Info(message);
        }

        public void InfoFormat(string format, params object[] args)
        {
            Logger.InfoFormat(format, args);
        }

        public void InfoFormat(string format, object arg0)
        {
            Logger.InfoFormat(format, arg0);
        }

        public void InfoFormat(string format, object arg0, object arg1)
        {
            Logger.InfoFormat(format, arg0, arg1);
        }

        public void Warn(object message)
        {
            Logger.Warn(message);
        }

        public void WarnFormat(string format, params object[] args)
        {
            Logger.WarnFormat(format,args);
        }

        public void WarnFormat(string format, object arg0)
        {
            Logger.WarnFormat(format, arg0);
        }

        public void WarnFormat(string format, object arg0, object arg1)
        {
            Logger.WarnFormat(format, arg0, arg1);
        }
        

        public void Error(string uniqueKey, Exception exception)
        {
            Logger.Error(uniqueKey, exception);
        }
        #endregion


    }
}
