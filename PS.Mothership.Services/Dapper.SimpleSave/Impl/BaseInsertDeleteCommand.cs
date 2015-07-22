using System;

namespace Dapper.SimpleSave.Impl
{
    public abstract class BaseInsertDeleteCommand : BaseCommand
    {
        private readonly BaseInsertDeleteOperation _operation;

        protected BaseInsertDeleteCommand(BaseInsertDeleteOperation operation)
        {
            _operation = operation;
            TableName = operation.TableName;
            PrimaryKeyColumn = operation.OwnerPrimaryKeyColumn;
        }

        public BaseInsertDeleteOperation Operation
        {
            get { return _operation; }
        }
    }
}
