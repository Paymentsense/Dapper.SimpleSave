using System;
using log4net;

namespace Dapper.SimpleSave
{
    public interface ISimpleSaveLogger
    {
        ILog Wrapped { get; }
        void LogBuilt(IScript script);
        void LogPreExecution(IScript script);
        void LogPostExecution(IScript script);
        void LogExecutionTime(long executionTimeMilliseconds);
    }
}
