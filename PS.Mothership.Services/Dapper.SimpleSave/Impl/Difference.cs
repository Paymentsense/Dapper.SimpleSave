using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Impl {
    public class Difference {
        public Type ObjectType { get; set; }
        
        public int ID { get; set; }

        public PropertyMetadata Property { get; set; }
        public object OldValue { get; set; }
        public object NewValue { get; set; }
    }
}
