using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave {
    public class ForeignKeyReferenceAttribute : Attribute {
        public Type ReferencedDto { get; private set; }

        public ForeignKeyReferenceAttribute(Type referencedDto)
        {
            ReferencedDto = referencedDto;
        }
    }
}
