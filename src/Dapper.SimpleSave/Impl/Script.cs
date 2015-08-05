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
            Parameters = new ExpandoObject();
        }

        public StringBuilder Buffer { get; private set; }
        public IDictionary<string, object> Parameters { get; private set; }
        public object Config { get { return Parameters; } }
        public object InsertedValue { get; set; }
        public DtoMetadata InsertedValueMetadata { get; set; }
    }
}
