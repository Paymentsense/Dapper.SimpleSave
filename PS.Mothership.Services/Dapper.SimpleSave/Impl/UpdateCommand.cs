using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Impl {
    public class UpdateCommand {

        private readonly IList<UpdateOperation> _operations = new List<UpdateOperation>();

        public string TableName
        {
            get { return _operations.Count > 0 ? _operations[0].TableName : null; }
        }

        public int? PrimaryKey
        {
            get { return _operations.Count > 0 ? (int?) _operations[0].PrimaryKey : null; }
        }

        public string PrimaryKeyColumn
        {
            get { return _operations.Count > 0 ? _operations[0].PrimaryKeyColumn : null; }
        }
 
        public void AddOperation(UpdateOperation operation)
        {
            var name = TableName;
            if (null != name && operation.TableName != name)
            {
                throw new ArgumentException(string.Format(
                    "Table name mismatch for UPDATE command. Expected: {0}. Actual: {1}.",
                    name,
                    operation.TableName));
            }

            var pk = PrimaryKey;
            if (null != pk && operation.PrimaryKey != pk.Value)
            {
                throw new ArgumentException(string.Format(
                    "Primary key mismatch for UPDATE command on table {0}. Expected: {1}. Actual: {2}.",
                    name,
                    pk,
                    operation.PrimaryKey));
            }

            name = PrimaryKeyColumn;
            if (null != name && operation.PrimaryKeyColumn != name)
            {
                throw new ArgumentException(string.Format(
                    "Primary key column mismatch for UPDATE command on table {0}. Expected: {1}. Actual: {2}.",
                    TableName,
                    name,
                    operation.PrimaryKeyColumn));
            }

            _operations.Add(operation);
        }

        public IEnumerable<UpdateOperation> Operations { get { return _operations; } } 
    }
}
