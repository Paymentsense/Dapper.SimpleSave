using System;
using System.Collections.Generic;

namespace Dapper.SimpleSave.Impl
{
    public class UpdateCommand : BaseCommand
    {

        private readonly IList<UpdateOperation> _operations = new List<UpdateOperation>();

        public void AddOperation(UpdateOperation operation)
        {
            var name = TableName;
            if (null != name && operation.TableName != name)
            {
                throw new ArgumentException(string.Format(
                    "Table name mismatch for UPDATE command. Expected: {0}. Actual: {1}.",
                    name,
                    operation.TableName),
                    "operation");
            }

            var pk = PrimaryKeyAsObject;
            if (null != pk && !PrimaryKeyComparer.SuppliedPrimaryKeyValuesMatch(operation.OwnerMetadata, pk, operation.OwnerPrimaryKeyAsObject))//operation.OwnerPrimaryKey != pk.Value)
            {
                throw new ArgumentException(string.Format(
                    "Primary key mismatch for UPDATE command on table {0}. Expected: {1}. Actual: {2}.",
                    name,
                    pk,
                    operation.OwnerPrimaryKeyAsObject),
                    "operation");
            }

            name = PrimaryKeyColumn;
            if (null != name && operation.OwnerPrimaryKeyColumn != name)
            {
                throw new ArgumentException(string.Format(
                    "Primary key column mismatch for UPDATE command on table {0}. Expected: {1}. Actual: {2}.",
                    TableName,
                    name,
                    operation.OwnerPrimaryKeyColumn),
                    "operation");
            }

            TableName = operation.TableName;
            PrimaryKeyColumn = operation.OwnerPrimaryKeyColumn;

            _operations.Add(operation);
        }

        public IEnumerable<UpdateOperation> Operations { get { return _operations; } }

        public object PrimaryKeyAsObject
        {
            get
            {
                return  _operations == null || _operations.Count == 0
                    ? null
                    : _operations[0].OwnerPrimaryKeyAsObject;
            }
        }
    }
}
