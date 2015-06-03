using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Castle.Core.Logging;

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
                        AppendInsertOperation(operations, diff);
                        break;

                    case DifferenceType.Deletion:
                        AppendDeleteOperation(operations, diff);
                        break;

                    case DifferenceType.Update:
                        AppendUpdateOperation(operations, diff);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(string.Format(
                            "Invalid DifferenceType: {0}",
                            diff.DifferenceType));
                }
            }

            return operations;
        }

        private void AppendInsertOperation(IList<BaseOperation> operations, Difference diff)
        {
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

            if (!FilterOutInsert(insertOperation))
            {
                operations.Add(Transform(insertOperation));
            }
        }

        private bool FilterOutInsert(InsertOperation insertOperation)
        {
            return insertOperation.OwnerPropertyMetadata != null
                   && insertOperation.OwnerPropertyMetadata.IsManyToOneRelationship;
        }

        private void AppendDeleteOperation(IList<BaseOperation> operations, Difference diff)
        {
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
        }

        private void AppendUpdateOperation(IList<BaseOperation> operations, Difference diff)
        {
            operations.Add(new UpdateOperation
            {
                ColumnName = diff.OwnerPropertyMetadata.ColumnName,
                ValueMetadata = diff.ValueMetadata,
                Value = diff.NewValue,
                OwnerPrimaryKeyColumn = diff.OwnerMetadata.PrimaryKey.Prop.Name,
                Owner = diff.Owner,
                OwnerMetadata = diff.OwnerMetadata,
                OwnerPropertyMetadata = diff.OwnerPropertyMetadata,
                TableName = diff.OwnerMetadata.TableName
            });
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

                if (baseInsertDelete.OwnerPropertyMetadata.HasAttribute<OneToManyAttribute>())
                {
                    if (!baseInsertDelete.ValueMetadata.HasAttribute<ReferenceDataAttribute>())
                    {
                        //  INSERT or DELETE the value from the other table
                        return baseInsertDelete;
                    }
                    
                    if (!baseInsertDelete.ValueMetadata.HasUpdateableForeignKeys)
                    {
                        throw new InvalidOperationException(string.Format(
                            "You cannot INSERT into a reference data child table in a one to many relationship between a parent table and a child table where the child table does not have updateable foreign keys. Attempted to INSERT into table {0}.",
                            baseInsertDelete.ValueMetadata.TableName));
                    }
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
    }
}
