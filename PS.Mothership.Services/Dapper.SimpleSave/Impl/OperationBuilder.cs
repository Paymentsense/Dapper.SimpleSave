using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Impl {
    public class OperationBuilder {

        public IEnumerable<UpdateOperation> Build(IEnumerable<Difference> differences)
        {
            return differences.Select(diff => new UpdateOperation
            {
                ColumnName = diff.Property.Prop.Name,
                Value = diff.NewValue,
                PrimaryKeyColumn = diff.TypeMetadata.PrimaryKey.Prop.Name,
                PrimaryKey = diff.Id,
                TableName = diff.TypeMetadata.TableName
            });
        }

        public IEnumerable<UpdateCommand> Coalesce(IEnumerable<UpdateOperation> operations)
        {
            var results = new List<UpdateCommand>();
            var tablesToUpdates = new Dictionary<string, IDictionary<int, UpdateCommand>>();

            foreach (var operation in operations)
            {
                IDictionary<int, UpdateCommand> commands;
                tablesToUpdates.TryGetValue(operation.TableName, out commands);
                if (null == commands)
                {
                    commands = new Dictionary<int, UpdateCommand>();
                    tablesToUpdates.Add(operation.TableName, commands);
                }

                UpdateCommand command;
                commands.TryGetValue(operation.PrimaryKey, out command);
                if (null == command)
                {
                    command = new UpdateCommand();
                    commands.Add(operation.PrimaryKey, command);
                    results.Add(command);
                }
                command.AddOperation(operation);
            }

            return results;
        } 
    }
}
