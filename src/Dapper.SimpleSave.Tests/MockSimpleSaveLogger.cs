using System.Collections.Generic;
using Dapper.SimpleSave.Impl;

namespace Dapper.SimpleSave.Tests
{
    public class MockSimpleSaveLogger : Log4NetSimpleSaveLogger
    {
        private IList<IScript> _scripts = new List<IScript>();

        public IList<IScript> Scripts
        {
            get { return _scripts; }
        }

        public override void LogPreExecution(IScript script)
        {
            _scripts.Add(script);
            base.LogPreExecution(script);
        }
    }
}
