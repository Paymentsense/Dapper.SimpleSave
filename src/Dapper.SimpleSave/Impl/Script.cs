using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Dapper.SimpleSave.Impl
{
    public class Script : IScript
    {
        public Script()
        {
            Buffer = new StringBuilder();
            Parameters = new Dictionary<string, Tuple<Type, object>>();
        }

        public StringBuilder Buffer { get; private set; }
        public IDictionary<string, Tuple<Type, object>> Parameters { get; private set; }
        public object Config { get { return Parameters; } }
        public object InsertedValue { get; set; }
        public DtoMetadata InsertedValueMetadata { get; set; }
    }
}
