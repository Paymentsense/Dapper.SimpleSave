using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Newtonsoft.Json;

namespace Dapper.SimpleSave.Impl
{
    public class BasicSimpleSaveLogger : ISimpleSaveLogger
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(BasicSimpleSaveLogger));

        private object BuildMessage(IScript script, string message)
        {
            return new
            {
                message,
                sql = script.Buffer.ToString(),
                parameters = script.Parameters
            };
        }

        public ILog Wrapped { get { return Logger; } }

        public virtual void LogBuilt(IScript script)
        {
            if (Logger.IsDebugEnabled)
            {
                Logger.Debug(BuildMessage(script, "Built script"));
            }
        }

        public virtual void LogPreExecution(IScript script)
        {
            if (Logger.IsInfoEnabled)
            {
                Logger.Info(BuildMessage(script, "Executing script"));
            }
        }

        public virtual void LogPostExecution(IScript script)
        {
            if (Logger.IsInfoEnabled)
            {
                Logger.Info(BuildMessage(script, "Executed script"));
            }
        }
    }
}
