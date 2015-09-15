using System.Collections.Generic;

namespace Dapper.SimpleSave.Impl
{
    public class ScriptTrackingSimpleSaveLogger : BasicSimpleSaveLogger
    {
        private IList<IScript> _scripts = new List<IScript>();

        public IList<IScript> Scripts
        {
            get { return _scripts; }
        }

        public override void LogBuilt(IScript script)
        {
            _scripts.Add(script);
            base.LogPreExecution(script);
        }
    }
}
