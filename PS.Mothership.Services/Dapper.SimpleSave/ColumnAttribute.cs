using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave {
    public class ColumnAttribute : Attribute {
        public string Name { get; private set; }
        public ColumnAttribute(string name)
        {
            Name = name;
        }
    }
}
