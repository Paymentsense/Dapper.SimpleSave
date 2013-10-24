using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using PS.Mothership.Core.Common.Contracts;

namespace PS.Mothership.Core.Common.Helper
{
    public class MSLogger : IMSLogger
    {
        public ILog Logger { get; set; }
        
        public MSLogger()
        {
            var a = new Log4NetJsonFormatter.JsonPatternLayoutConverter();
            Log4NetJsonFormatter.JsonPatternLayoutConverter.AssemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
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
