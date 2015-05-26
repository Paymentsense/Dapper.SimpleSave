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
                    case DifferenceType.Insertion:
                        var insertOperation = new InsertOperation
                        {
                            OwnerMetadata = diff.OwnerMetadata,
                            OwnerPropertyMetadata = diff.OwnerPropertyMetadata,
                            OwnerPrimaryKeyColumn = null == diff.OwnerMetadata ? null : diff.OwnerMetadata.PrimaryKey.Prop.Name,
                            OwnerPrimaryKey = diff.OwnerId,
                            TableName = diff.OwnerMetadata == null ? null : diff.OwnerMetadata.TableName,
                            ValueMetadata = diff.ValueMetadata,
                            Value = diff.NewValue
                        };
                        operations.Add(Transform(insertOperation));
                        break;

                    case DifferenceType.Deletion:
                        var removeOperation = new DeleteOperation
                        {
                            OwnerMetadata = diff.OwnerMetadata,
                            OwnerPropertyMetadata = diff.OwnerPropertyMetadata,
                            OwnerPrimaryKeyColumn = null == diff.OwnerMetadata ? null : diff.OwnerMetadata.PrimaryKey.Prop.Name,
                            OwnerPrimaryKey = diff.OwnerId,
                            TableName = diff.OwnerMetadata == null ? null : diff.OwnerMetadata.TableName,
                            ValueMetadata = diff.ValueMetadata,
                            Value = diff.OldValue
                        };
                        operations.Add(Transform(removeOperation));
                        break;

                    case DifferenceType.Update:
                        operations.Add(new UpdateOperation {
                            ColumnName = diff.OwnerPropertyMetadata.ColumnName,
                            ValueMetadata = diff.ValueMetadata,
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

        private BaseOperation Transform(BaseInsertDeleteOperation baseInsertDelete)
        {
            if (baseInsertDelete.ValueMetadata != null)
            {
                if (null == baseInsertDelete.OwnerPropertyMetadata)
                {
                    //  Top level INSERT
                    return baseInsertDelete;
                }

                if (baseInsertDelete.OwnerPropertyMetadata.HasAttribute<ManyToManyAttribute>())
                {
                    //  INSERT or DELETE record in link table; don't touch either entity table
                    return baseInsertDelete;
                }

                if (baseInsertDelete.OwnerPropertyMetadata.HasAttribute<OneToManyAttribute>()
                    && !baseInsertDelete.ValueMetadata.HasAttribute<ReferenceDataAttribute>())
                {
                    //  INSERT or DELETE the value from the other table
                    return baseInsertDelete;
                }
            }

            return new UpdateOperation {
                ColumnName = baseInsertDelete.OwnerPropertyMetadata.ColumnName,
                Value = baseInsertDelete.Value,
                ValueMetadata = baseInsertDelete.ValueMetadata,
                OwnerPrimaryKeyColumn = baseInsertDelete.OwnerPrimaryKeyColumn,
                OwnerPrimaryKey = baseInsertDelete.OwnerPrimaryKey,
                TableName = baseInsertDelete.TableName
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
                else if (operation is DeleteOperation)
                {
                    results.Add(new DeleteCommand(operation as DeleteOperation));
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
            commands.TryGetValue(updateOperation.OwnerPrimaryKey.GetValueOrDefault(), out command);
            if (null == command)
            {
                command = new UpdateCommand();
                commands.Add(updateOperation.OwnerPrimaryKey.GetValueOrDefault(), command);
                results.Add(command);
            }
            command.AddOperation(updateOperation);
        }
    }
}
