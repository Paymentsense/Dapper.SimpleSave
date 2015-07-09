using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave
{
    public class SoftDeleteColumnAttribute : Attribute
    {
        public SoftDeleteColumnAttribute() : this(false)
        {
        }

        public SoftDeleteColumnAttribute(bool trueIndicatesDeleted)
        {
            TrueIndicatesDeleted = trueIndicatesDeleted;
        }

        public bool TrueIndicatesDeleted { get; private set; }
    }
}
