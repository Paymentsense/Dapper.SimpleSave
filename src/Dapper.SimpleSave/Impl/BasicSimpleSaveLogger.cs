using System;
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
            if (SimpleSaveExtensions.LogBuiltScripts && Logger.IsDebugEnabled)
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
            if (SimpleSaveExtensions.LogScriptsPreExecution)
            {
                Log(script, "Executing script");
            }
        }

        public virtual void LogPostExecution(IScript script)
        {
            if (SimpleSaveExtensions.LogScriptsPostExecution)
            {
                Log(script, "Executed script");
            }
        }

        public virtual void LogExecutionTime(long executionTimeMilliseconds, IScript script)
        {
            if (executionTimeMilliseconds > SimpleSaveExtensions.ExecutionTimeWarningEmitThresholdMilliseconds)
            {
                if (Logger.IsWarnEnabled)
                {
                    Logger.Warn(string.Format(
                        @"SIMPLESAVE SCRIPT EXECUTED IN {0}ms:
{1}
CALLING STACK TRACE:
{2}",
                        executionTimeMilliseconds,
                        script.Buffer,
                        Environment.StackTrace));
                }
            }
            else
            {
                if (Logger.IsInfoEnabled)
                {
                    Logger.Info(string.Format(
                        "SimpleSave script executed in {0}ms",
                        executionTimeMilliseconds));
                }
            }
        }
    }
}
