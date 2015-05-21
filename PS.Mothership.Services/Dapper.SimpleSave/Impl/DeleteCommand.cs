using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Impl {
    public class DeleteCommand : BaseInsertDeleteCommand
    {
        public DeleteCommand(DeleteOperation operation) : base(operation)
        {
        }
    }
}
