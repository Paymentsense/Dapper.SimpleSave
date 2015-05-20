using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Impl {
    public class DeleteCommand : BaseCommand
    {
        private readonly RemoveOperation _operation;

        public DeleteCommand(RemoveOperation operation)
        {
            _operation = operation;
            TableName = operation.TableName;
            PrimaryKey = operation.OwnerPrimaryKey;
            PrimaryKeyColumn = operation.OwnerPrimaryKeyColumn;
        }

        public RemoveOperation Operation
        {
            get { return _operation; }
        }
    }
}
