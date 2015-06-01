using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Impl {
    public class Script {
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
