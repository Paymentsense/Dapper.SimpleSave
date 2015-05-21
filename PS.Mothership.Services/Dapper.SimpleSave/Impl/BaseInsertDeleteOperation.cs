using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Impl {
    public class BaseInsertDeleteOperation : BaseOperation
    {
        public DtoMetadata ValueMetadata { get; set; }
    }
}
