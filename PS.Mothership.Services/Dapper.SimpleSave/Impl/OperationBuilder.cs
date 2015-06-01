using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;

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
                            Owner = diff.Owner,
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
                            Owner = diff.Owner,
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
                            Owner = diff.Owner,
                            OwnerMetadata = diff.OwnerMetadata,
                            OwnerPropertyMetadata = diff.OwnerPropertyMetadata,
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
                Owner = baseInsertDelete.Owner,
                OwnerMetadata = baseInsertDelete.OwnerMetadata,
                OwnerPropertyMetadata = baseInsertDelete.OwnerPropertyMetadata,
                TableName = baseInsertDelete.TableName
            };
        }

        public IEnumerable<BaseCommand> Coalesce(IEnumerable<BaseOperation> operations)
        {
            var results = new List<BaseCommand>();
            string updateTableName = null;
            int? updatePk = null;
            var updates = new List<UpdateOperation>();

            foreach (var operation in operations)
            {
                if (operation is UpdateOperation)
                {
                    var update = operation as UpdateOperation;
                    if (updateTableName != update.TableName || updatePk != update.OwnerPrimaryKey)
                    {
                        if (null != updateTableName)
                        {
                            ApplyUpdate(results, updates, ref updateTableName, ref updatePk);
                        }

                        updateTableName = update.TableName;
                        updatePk = update.OwnerPrimaryKey;
                    }
                    updates.Add(update);
                }
                else
                {
                    ApplyUpdate(results, updates, ref updateTableName, ref updatePk);

                    if (operation is InsertOperation)
                    {
                        results.Add(new InsertCommand(operation as InsertOperation));
                    } else if (operation is DeleteOperation) {
                        results.Add(new DeleteCommand(operation as DeleteOperation));
                    }
                }
            }

            if (updates.Count > 0)
            {
                ApplyUpdate(results, updates, ref updateTableName, ref updatePk);
            }

            return results;
        }

        private void ApplyUpdate(IList<BaseCommand> results, IList<UpdateOperation> updates, ref string updateTableName, ref int? updatePk)
        {
            if (updates.Count == 0)
            {
                return;
            }
            var command = new UpdateCommand();
            updates.ForEach(update => command.AddOperation(update));
            results.Add(command);
            updates.Clear();
            updateTableName = null;
            updatePk = null;
        }
    }
}
