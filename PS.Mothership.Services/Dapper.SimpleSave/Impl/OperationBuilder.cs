using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Impl {
    public class OperationBuilder {
        public IEnumerable<BaseOperation> Build(IEnumerable<Difference> differences)
        {
            var operations = new List<BaseOperation>();

            foreach (var diff in differences)
            {
                switch (diff.DifferenceType)
                {
                    case DifferenceType.Added:
                        var insertOperation = new InsertOperation
                        {
                            OwnerMetadata = diff.OwnerMetadata,
                            OwnerPropertyMetadata = diff.OwnerPropertyMetadata,
                            OwnerPrimaryKeyColumn = diff.OwnerMetadata.PrimaryKey.Prop.Name,
                            OwnerPrimaryKey = diff.OwnerId,
                            TableName = diff.OwnerMetadata.TableName,
                            ValueMetadata = diff.ValueMetadata,
                            Value = diff.NewValue
                        };
                        operations.Add(TransformInsertOrRemove(insertOperation));
                        break;

                    case DifferenceType.Removed:
                        var removeOperation = new RemoveOperation
                        {
                            OwnerMetadata = diff.OwnerMetadata,
                            OwnerPropertyMetadata = diff.OwnerPropertyMetadata,
                            OwnerPrimaryKeyColumn = diff.OwnerMetadata.PrimaryKey.Prop.Name,
                            OwnerPrimaryKey = diff.OwnerId,
                            TableName = diff.OwnerMetadata.TableName,
                            ValueMetadata = diff.ValueMetadata,
                            Value = diff.OldValue
                        };
                        operations.Add(TransformInsertOrRemove(removeOperation));
                        break;

                    case DifferenceType.Changed:
                        operations.Add(new UpdateOperation {
                            ColumnName = diff.OwnerPropertyMetadata.Prop.Name,
                            Value = diff.NewValue,
                            OwnerPrimaryKeyColumn = diff.OwnerMetadata.PrimaryKey.Prop.Name,
                            OwnerPrimaryKey = diff.OwnerId,
                            TableName = diff.OwnerMetadata.TableName
                        });
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return operations;
        }

        private BaseOperation TransformInsertOrRemove(RemoveOperation insertOrRemoveOperation)
        {
            if (insertOrRemoveOperation.ValueMetadata != null)
            {
                if (insertOrRemoveOperation.OwnerPropertyMetadata.HasAttribute<ManyToManyAttribute>())
                {
                    //  Remove record in link table; don't touch either entity table
                    return insertOrRemoveOperation;
                }

                if (insertOrRemoveOperation.OwnerPropertyMetadata.HasAttribute<OneToManyAttribute>()
                    && !insertOrRemoveOperation.ValueMetadata.HasAttribute<ReferenceDataAttribute>())
                {
                    //  DELETE the value from the other table
                    return insertOrRemoveOperation;
                }
            }

            return new UpdateOperation {
                ColumnName = insertOrRemoveOperation.OwnerPropertyMetadata.Prop.Name,
                Value = insertOrRemoveOperation.Value,
                OwnerPrimaryKeyColumn = insertOrRemoveOperation.OwnerPrimaryKeyColumn,
                OwnerPrimaryKey = insertOrRemoveOperation.OwnerPrimaryKey,
                TableName = insertOrRemoveOperation.TableName
            };
        }

        public IEnumerable<BaseCommand> Coalesce(IEnumerable<BaseOperation> operations)
        {
            var results = new List<BaseCommand>();
            var tablesToUpdates = new Dictionary<string, IDictionary<int, UpdateCommand>>();

            foreach (var operation in operations)
            {
                if (operation is UpdateOperation)
                {
                    CoalesceUpdates(operation, tablesToUpdates, results);
                }
                else if (operation is InsertOperation)
                {
                    results.Add(new InsertCommand(operation as InsertOperation));
                }
                else if (operation is RemoveOperation)
                {
                    results.Add(new DeleteCommand(operation as RemoveOperation));
                }
            }

            return results;
        }

        private static void CoalesceUpdates(BaseOperation operation, Dictionary<string, IDictionary<int, UpdateCommand>> tablesToUpdates, List<BaseCommand> results)
        {
            var updateOperation = operation as UpdateOperation;
            IDictionary<int, UpdateCommand> commands;
            tablesToUpdates.TryGetValue(updateOperation.TableName, out commands);
            if (null == commands)
            {
                commands = new Dictionary<int, UpdateCommand>();
                tablesToUpdates.Add(updateOperation.TableName, commands);
            }

            UpdateCommand command;
            commands.TryGetValue(updateOperation.OwnerPrimaryKey, out command);
            if (null == command)
            {
                command = new UpdateCommand();
                commands.Add(updateOperation.OwnerPrimaryKey, command);
                results.Add(command);
            }
            command.AddOperation(updateOperation);
        }
    }
}
