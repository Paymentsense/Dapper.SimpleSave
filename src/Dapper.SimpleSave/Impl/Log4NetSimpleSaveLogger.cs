using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Impl
{
    public class Log4NetSimpleSaveLogger : ISimpleSaveLogger
    {
        public virtual void LogPreExecution(IScript script)
        {
            //  TODO: log me
        }

        public virtual void LogPostExecution(IScript script)
        {
            //  TODO: log me
        }
    }
}
