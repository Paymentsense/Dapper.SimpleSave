using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave {
    public class OneToOneAttribute : Attribute {
        public OneToOneAttribute()
        {
        }

        public OneToOneAttribute(string childForeignKeyColumn)
        {
            ChildForeignKeyColumn = childForeignKeyColumn;
        }

        public string ChildForeignKeyColumn { get; private set; }
    }
}
