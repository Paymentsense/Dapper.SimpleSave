using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;

namespace Dapper.SimpleSave.Impl
{
    public class CommandBuilder
    {
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
                        ValidateUpdateOperation(update);
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
                        var insert = operation as InsertOperation;
                        ValidateInsertOperation(insert);
                        results.Add(new InsertCommand(insert));
                    }
                    else if (operation is DeleteOperation)
                    {
                        var delete = operation as DeleteOperation;
                        ValidateDeleteOperation(delete);
                        results.Add(new DeleteCommand(delete));
                    }
                }
            }

            if (updates.Count > 0)
            {
                ApplyUpdate(results, updates, ref updateTableName, ref updatePk);
            }

            return results;
        }

        private void ValidateInsertOperation(InsertOperation insert)
        {
            var tableMetadata = insert.ValueMetadata;
            if (null == tableMetadata)
            {
                throw new ArgumentException(
                    "Cannot INSERT without metadata for table because we don't know which table we're INSERTing into. InsertOperation.ValueMetadata must not be null.",
                    "insert");
            }

            // We only need to complain if somebody tries to insert into a top level table at this point.
            // Insertions into child tables will be transformed into inserts into link tables for many to many
            // reference data tables later.
            if (insert.OwnerMetadata == null && tableMetadata.IsReferenceData)
            {
                throw new InvalidOperationException(string.Format(
                    "You cannot INSERT into a reference data table, even if that table contains updateable foreign keys. Attempt was made to INSERT into {0}.",
                    tableMetadata.TableName));
            }
        }

        private void ValidateDeleteOperation(DeleteOperation delete)
        {
            var tableMetadata = delete.ValueMetadata;
            if (null == tableMetadata)
            {
                throw new ArgumentException(
                    "Cannot DELETE without metadata for table because we don't know which table we're DELETE-ing into. DeleteOperation.ValueMetadata must not be null.",
                    "delete");
            }

            // We only need to complain if somebody tries to insert into a top level table at this point.
            // Insertions into child tables will be transformed into inserts into link tables for many to many
            // reference data tables later.
            if (delete.OwnerMetadata == null && tableMetadata.IsReferenceData)
            {
                throw new InvalidOperationException(string.Format(
                    "You cannot DELETE from a reference data table, even if that table contains updateable foreign keys. Attempt was made to DELETE from {0}.",
                    tableMetadata.TableName));
            }
        }

        private void ValidateUpdateOperation(UpdateOperation update)
        {
            var tableMetadata = update.OwnerMetadata;
            if (null != tableMetadata)
            {
                if (tableMetadata.IsReferenceData)
                {
                    var columnMetadata = update.OwnerPropertyMetadata;
                    if (!tableMetadata.HasUpdateableForeignKeys)
                    {
                        throw new InvalidOperationException(string.Format(
                            "You cannot perform UPDATEs on a reference data table with no updateable foreign keys. Attempt was made to UPDATE table {0}, column {1}.",
                            tableMetadata.TableName,
                            null == columnMetadata ? "(unknown column)" : columnMetadata.ColumnName));
                    }

                    if (null != columnMetadata && !columnMetadata.HasAttribute<ForeignKeyReferenceAttribute>())
                    {
                        throw new InvalidOperationException(string.Format(
                            "You cannot UPDATE non-foreign key columns on a reference data table with updateable foreign keys. Attempt was made to UPDATE table {0}, column {1}.",
                            tableMetadata.TableName,
                            columnMetadata.ColumnName));
                    }
                }
            }
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
