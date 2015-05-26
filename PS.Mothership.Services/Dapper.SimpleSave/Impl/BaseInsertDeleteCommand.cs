using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Impl {
    public class BaseInsertDeleteCommand : BaseCommand
    {
        private readonly BaseInsertDeleteOperation _operation;

        public BaseInsertDeleteCommand(BaseInsertDeleteOperation operation)
        {
            _operation = operation;
            TableName = operation.TableName;
            PrimaryKeyColumn = operation.OwnerPrimaryKeyColumn;
        }

        public BaseInsertDeleteOperation Operation
        {
            get { return _operation; }
        }

        public override int? PrimaryKey
        {
            get { return _operation.OwnerPrimaryKey; }
        }
    }
}
