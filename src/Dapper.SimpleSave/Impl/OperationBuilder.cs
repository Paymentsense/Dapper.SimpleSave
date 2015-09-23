﻿using System;
using System.Collections.Generic;

namespace Dapper.SimpleSave.Impl
{
    public class OperationBuilder
    {
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
                OwnerPrimaryKeyColumn = diff.OwnerMetadata == null ? null : diff.OwnerMetadata.PrimaryKey.Prop.Name,
                Owner = diff.Owner,
                TableName = diff.OwnerMetadata == null ? null : diff.OwnerMetadata.TableName,
                ValueMetadata = diff.ValueMetadata,
                Value = diff.NewValue
            };

            if (IsViableParentUpdateOnManyToOneRelationship(insertOperation, diff))
            {
                AddUpdateOnParentTableForInsertDeleteOfManyToOneChildRow(operations, diff, insertOperation);
            }
            else if (IsViableParentUpdateOnOneToOneWithFkInParent(insertOperation, diff))
            {
                AddUpdateOnParentTableForInsertDeleteOfOneToOneChildRow(operations, diff, insertOperation);
            }
            else if (!ShouldFilterOutForParticularCardinalitiesBecauseFkOnParent(insertOperation))
            {
                AddInsertToListAtCorrectLocation(operations, insertOperation);
            }
        }

        private void AddInsertToListAtCorrectLocation(IList<BaseOperation> operations, InsertOperation insertOperation)
        {
            var transformed = Transform(insertOperation);
            if (transformed == insertOperation)
            {
                if (null != insertOperation.OwnerPropertyMetadata
                    && insertOperation.OwnerPropertyMetadata.IsOneToOneRelationship
                    && (!insertOperation.ValueMetadata.IsReferenceData && !insertOperation.OwnerPropertyMetadata.HasAttribute<ReferenceDataAttribute>())
                    && insertOperation.OwnerPropertyMetadata.HasAttribute<ForeignKeyReferenceAttribute>())
                {
                    PrependInsertBeforeParentTableInsert(operations, insertOperation);
                }
                else
                {
                    operations.Add(transformed);
                }
            }
            else
            {
                operations.Add(transformed);
            }
        }

        private static void PrependInsertBeforeParentTableInsert(
            IList<BaseOperation> operations,
            InsertOperation insertOperation)
        {
            int index = operations.Count - 1;
            while (index >= 0)
            {
                var possibleMatch = operations[index] as InsertOperation;
                if (null != possibleMatch && possibleMatch.ValueMetadata == insertOperation.OwnerMetadata)
                {
                    operations.Insert(index, insertOperation);
                    break;
                }
                --index;
            }

            if (index < 0)
            {
                operations.Add(insertOperation);
            }
        }

        private void AppendDeleteOperation(IList<BaseOperation> operations, Difference diff)
        {
            var deleteOperation = new DeleteOperation
            {
                OwnerMetadata = diff.OwnerMetadata,
                OwnerPropertyMetadata = diff.OwnerPropertyMetadata,
                OwnerPrimaryKeyColumn = diff.OwnerMetadata == null ? null : diff.OwnerMetadata.PrimaryKey.Prop.Name,
                Owner = diff.Owner,
                TableName = diff.OwnerMetadata == null ? null : diff.OwnerMetadata.TableName,
                ValueMetadata = diff.ValueMetadata,
                Value = diff.OldValue
            };

            if (IsViableParentUpdateOnManyToOneRelationship(deleteOperation, diff))
            {
               AddUpdateOnParentTableForInsertDeleteOfManyToOneChildRow(operations, diff, deleteOperation);
            }
            else if (IsViableParentUpdateOnOneToOneWithFkInParent(deleteOperation, diff))
            {
                AddUpdateOnParentTableForInsertDeleteOfOneToOneChildRow(operations, diff, deleteOperation);
            }
            else if (!ShouldFilterOutForParticularCardinalitiesBecauseFkOnParent(deleteOperation))
            {
                AddDeleteToListAtCorrectLocation(operations, deleteOperation);
            }
        }

        private static void AddUpdateOnParentTableForInsertDeleteOfManyToOneChildRow(
            IList<BaseOperation> operations,
            Difference diff,
            BaseInsertDeleteOperation insertOperation)
        {
            var updateOperation = new UpdateOperation
            {
                OwnerMetadata = insertOperation.OwnerMetadata,
                OwnerPropertyMetadata = insertOperation.OwnerPropertyMetadata,
                OwnerPrimaryKeyColumn = insertOperation.OwnerPrimaryKeyColumn,
                Owner = insertOperation.Owner,
                TableName = insertOperation.TableName,
                ColumnName = diff.OwnerPropertyMetadata.ColumnName,
                ValueMetadata = diff.ValueMetadata,
                Value = diff.NewValue
            };
            operations.Add(updateOperation);
        }

        private static void AddUpdateOnParentTableForInsertDeleteOfOneToOneChildRow(IList<BaseOperation> operations, Difference diff,
            BaseInsertDeleteOperation insertDeleteOperation)
        {
            var updateOperation = new UpdateOperation
            {
                OwnerMetadata = insertDeleteOperation.OwnerMetadata,
                OwnerPropertyMetadata = insertDeleteOperation.OwnerPropertyMetadata,
                OwnerPrimaryKeyColumn = insertDeleteOperation.OwnerPrimaryKeyColumn,
                Owner = insertDeleteOperation.Owner,
                TableName = insertDeleteOperation.OwnerMetadata.TableName,
                ColumnName = diff.OwnerPropertyMetadata.ColumnName,
                ValueMetadata = diff.ValueMetadata,
                Value = diff.NewValue
            };

            if (insertDeleteOperation is DeleteOperation)
            {
                operations.Add(updateOperation);
            }

            if (!insertDeleteOperation.ValueMetadata.IsReferenceData && !insertDeleteOperation.OwnerPropertyMetadata.HasAttribute<ReferenceDataAttribute>())
            {
                operations.Add(insertDeleteOperation);
            }

            //  If it's an INSERT add the update here
            if (insertDeleteOperation is InsertOperation)
            {
                operations.Add(updateOperation);
            }
        }

        private void AddDeleteToListAtCorrectLocation(IList<BaseOperation> operations, DeleteOperation deleteOperation)
        {
            var transformed = Transform(deleteOperation);
            if (transformed == deleteOperation)
            {
                if (HasAnyOneToOneChildrenWithFKOnParent(deleteOperation))
                {
                    PrependDeleteBeforeReferencedChildTableDelete(operations, deleteOperation);
                }
                else
                {
                    operations.Add(transformed);
                }
            }
            else
            {
                operations.Add(transformed);
            }
        }

        private bool HasAnyOneToOneChildrenWithFKOnParent(DeleteOperation deleteOperation)
        {
            foreach (var property in deleteOperation.ValueMetadata.WriteableProperties)
            {
                if (property.IsOneToOneRelationship && property.HasAttribute<ForeignKeyReferenceAttribute>())
                {
                    return true;
                }
            }
            return false;
        }

        private static void PrependDeleteBeforeReferencedChildTableDelete(
            IList<BaseOperation> operations,
            DeleteOperation deleteOperation)
        {
            var firstIndex = -1;
            int index = operations.Count - 1;
            while (index >= 0)
            {
                var possibleMatch = operations [index] as DeleteOperation;
                if (null != possibleMatch
                    && possibleMatch.OwnerMetadata == deleteOperation.ValueMetadata
                    && possibleMatch.OwnerPropertyMetadata != null
                    && possibleMatch.OwnerPropertyMetadata.IsOneToOneRelationship
                    && possibleMatch.OwnerPropertyMetadata.HasAttribute<ForeignKeyReferenceAttribute>())
                {
                    firstIndex = index;
                    break;
                }
                --index;
            }

            if (firstIndex < 0)
            {
                operations.Add(deleteOperation);
            }
            else
            {
                operations.Insert(firstIndex, deleteOperation);
            }
        }

        private bool IsViableParentUpdateOnManyToOneRelationship(
            BaseInsertDeleteOperation insertDeleteOperation,
            Difference diff)
        {
            return insertDeleteOperation.OwnerMetadata != null
                   && insertDeleteOperation.OwnerPropertyMetadata.IsManyToOneRelationship
                   && diff.OldOwner != null
                   && diff.NewOwner != null;
        }

        private bool IsViableParentUpdateOnOneToOneWithFkInParent(
            BaseInsertDeleteOperation insertDeleteOperation,
            Difference diff)
        {
            return insertDeleteOperation.OwnerPropertyMetadata != null
                   && diff.OldOwner != null
                   && diff.NewOwner != null
                   && (insertDeleteOperation.OwnerPropertyMetadata.IsOneToOneRelationship
                        && insertDeleteOperation.OwnerPropertyMetadata.HasAttribute<ForeignKeyReferenceAttribute>());
        }

        private bool ShouldFilterOutForParticularCardinalitiesBecauseFkOnParent(BaseInsertDeleteOperation insertDeleteOperation)
        {
            return insertDeleteOperation.OwnerPropertyMetadata != null
                   && (insertDeleteOperation.OwnerPropertyMetadata.IsManyToOneRelationship
                        || (insertDeleteOperation.OwnerPropertyMetadata.IsOneToOneRelationship
                            && insertDeleteOperation.OwnerPropertyMetadata.HasAttribute<ForeignKeyReferenceAttribute>()
                            && (insertDeleteOperation.ValueMetadata.IsReferenceData || insertDeleteOperation.OwnerPropertyMetadata.HasAttribute<ReferenceDataAttribute>())
                            && ! insertDeleteOperation.ValueMetadata.HasUpdateableForeignKeys));
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
                if (baseInsertDelete.OwnerPropertyMetadata == null)
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
                    if (!baseInsertDelete.ValueMetadata.HasAttribute<ReferenceDataAttribute>()
                        && !baseInsertDelete.OwnerPropertyMetadata.HasAttribute<ReferenceDataAttribute>())
                    {
                        //  INSERT or DELETE the value from the other table
                        return baseInsertDelete;
                    }
                    
                    if ((baseInsertDelete.ValueMetadata.HasAttribute<ReferenceDataAttribute>()
                            && !baseInsertDelete.ValueMetadata.HasUpdateableForeignKeys)
                        || (baseInsertDelete.OwnerPropertyMetadata.HasAttribute<ReferenceDataAttribute>()
                            && !baseInsertDelete.OwnerPropertyMetadata.GetAttribute<ReferenceDataAttribute>().HasUpdateableForeignKeys))
                    {
                        throw new InvalidOperationException(string.Format(
                            "You cannot INSERT into a reference data child table in a one to many relationship between a parent table and a child table where the child table does not have updateable foreign keys. (Note that any INSERT satisfying these conditions would be transformed into an UPDATE on the target row in the child table.) Attempted to INSERT into table {0}.",
                            baseInsertDelete.ValueMetadata.TableName));
                    }
                }

                if (baseInsertDelete.OwnerPropertyMetadata.HasAttribute<OneToOneAttribute>())
                {
                    if (!baseInsertDelete.ValueMetadata.HasAttribute<ReferenceDataAttribute>()
                        && !baseInsertDelete.OwnerPropertyMetadata.HasAttribute<ReferenceDataAttribute>())
                    {
                        return baseInsertDelete;
                    }

                    if (((baseInsertDelete.ValueMetadata.HasAttribute<ReferenceDataAttribute>()
                            && !baseInsertDelete.ValueMetadata.HasUpdateableForeignKeys)
                        || (baseInsertDelete.OwnerPropertyMetadata.HasAttribute<ReferenceDataAttribute>()
                            && !baseInsertDelete.OwnerPropertyMetadata.GetAttribute<ReferenceDataAttribute>().HasUpdateableForeignKeys))
                        && !baseInsertDelete.OwnerPropertyMetadata.HasAttribute<ForeignKeyReferenceAttribute>())
                    {
                        throw new InvalidOperationException(string.Format(
                            "You cannot INSERT into a reference data child table in a one to one relationship between a parent table and a child table where te child table does not have updateable foreign keys. (Note that any INSERT satisfying these conditions would be transformed into an UPDATE on the target row in the child table.) Attempted to INSERT into table {0}.",
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
