using log4net;
using Newtonsoft.Json;

namespace Dapper.SimpleSave.Impl
{
    public class BasicSimpleSaveLogger : ISimpleSaveLogger
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(BasicSimpleSaveLogger));

        private object BuildInfoMessage(IScript script, string message)
        {
            return new
            {
                message,
                sql = script.Buffer.ToString(),
            };
        }

        private object BuildDebugMessage(IScript script, string message)
        {
            return new
            {
                message,
                sql = script.Buffer.ToString(),
                parameters = JsonConvert.SerializeObject(script.Parameters)
            };
        }

        public ILog Wrapped { get { return Logger; } }

        public virtual void LogBuilt(IScript script)
        {
            if (Logger.IsDebugEnabled)
            {
                Logger.Debug(BuildDebugMessage(script, "Built script"));
            }
        }

        private void Log(IScript script, string message)
        {
            if (Logger.IsDebugEnabled)
            {
                Logger.Debug(BuildDebugMessage(script, message));
            }
            else if (Logger.IsInfoEnabled)
            {
                Logger.Info(BuildInfoMessage(script, message));
            }
        }

        public virtual void LogPreExecution(IScript script)
        {
            Log(script, "Executing script");
        }

        public virtual void LogPostExecution(IScript script)
        {
            Log(script, "Executed script");
        }
    }
}
