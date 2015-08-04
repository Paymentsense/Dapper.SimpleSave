using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Castle.Core.Internal;
using Dapper.SimpleSave.Impl;

namespace Dapper.SimpleSave
{
    public static class SimpleSaveExtensions
    {
        private static readonly DtoMetadataCache _dtoMetadataCache = new DtoMetadataCache();

        public static void Update<T>(
            this IDbConnection connection,
            IEnumerable<Tuple<T, T>> oldAndNewObjects,
            IDbTransaction transaction = null)
        {
            UpdateInternal(connection, oldAndNewObjects, false, transaction);
        }

        public static void Update<T>(
            this IDbConnection connection,
            T oldObject,
            T newObject,
            IDbTransaction transaction = null)
        {
            var target = new List<Tuple<T, T>>();
            target.Add(Tuple.Create(oldObject, newObject));
            Update(connection, target, transaction);
        }

        public static void Create<T>(
            this IDbConnection connection,
            IEnumerable<T> newObjects,
            IDbTransaction transaction = null)
        {
            Update(
                connection,
                newObjects.Select(obj => Tuple.Create(default(T), obj)),
                transaction);
        }

        public static void Create<T>(
            this IDbConnection connection,
            T obj,
            IDbTransaction transaction = null)
        {
            Update(connection, default(T), obj, transaction);
        }

        public static void Delete<T>(
            this IDbConnection connection,
            IEnumerable<T> oldObjects,
            IDbTransaction transaction = null)
        {
            Update(
                connection,
                oldObjects.Select(obj => Tuple.Create(obj, default(T))),
                transaction);
        }

        public static void Delete<T>(
            this IDbConnection connection,
            T obj,
            IDbTransaction transaction = null)
        {
            Update(connection, obj, default(T), transaction);
        }

        public static void SoftDelete<T>(
            this IDbConnection connection,
            IEnumerable<T> objects,
            IDbTransaction transaction = null)
        {
            UpdateInternal(
                connection,
                objects.Select(obj => Tuple.Create(obj, default(T))),
                true,
                transaction);
        }

        public static void SoftDelete<T>(
            this IDbConnection connection,
            T obj,
            IDbTransaction transaction = null)
        {
            SoftDelete(
                connection,
                new [] { obj },
                transaction);
        }

        private static void UpdateInternal<T>(
            IDbConnection connection,
            IEnumerable<Tuple<T, T>> oldAndNewObjects,
            bool softDelete = false,
            IDbTransaction transaction = null)
        {
            var builder = new TransactionBuilder(_dtoMetadataCache);
            IDictionary<Tuple<T, T>, IList<Script>> scripts = new Dictionary<Tuple<T, T>, IList<Script>>();
            foreach (var pair in oldAndNewObjects)
            {
                scripts[pair] = builder.BuildUpdateScripts(pair.Item1, pair.Item2, softDelete);
            }

            if (transaction == null)
            {
                using (var myTransaction = connection.BeginTransaction())
                {
                    try
                    {
                        ExecuteScriptsForTuples(
                            connection,
                            oldAndNewObjects,
                            scripts,
                            softDelete,
                            myTransaction);

                        myTransaction.Commit();
                    } catch (Exception)
                    {
                        myTransaction.Rollback();
                        throw;
                    }
                }
            }
            else
            {
                ExecuteScriptsForTuples(
                    connection,
                    oldAndNewObjects,
                    scripts,
                    softDelete,
                    transaction);
            }
        }

        private static void ExecuteScriptsForTuples<T>(
            IDbConnection connection,
            IEnumerable<Tuple<T, T>> oldAndNewObjects,
            IDictionary<Tuple<T, T>, IList<Script>> scripts,
            bool softDelete,
            IDbTransaction transaction)
        {
            foreach (var pair in oldAndNewObjects)
            {
                ExecuteScripts(
                    connection,
                    scripts[pair],
                    pair.Item1,
                    pair.Item2,
                    softDelete,
                    transaction);
            }
        }

        private static void ExecuteScripts<T>(
            IDbConnection connection,
            IList<Script> scripts,
            T oldRootObject,
            T newRootObject,
            bool softDelete,
            IDbTransaction transaction)
        {
            for (int index = 0, count = scripts.Count; index < count; ++index)
            {
                var script = scripts[index];

                ResolvePrimaryKeyValues<T>(script);

                ExecuteCommandForScript<T>(
                    connection,
                    oldRootObject,
                    newRootObject,
                    softDelete,
                    transaction,
                    script);
            }
        }

        private static void ExecuteCommandForScript<T>(
            IDbConnection connection,
            T oldRootObject,
            T newRootObject,
            bool softDelete,
            IDbTransaction transaction,
            Script script)
        {
            PropertyMetadata softDeletePropertyMetadata = GetMarkerPropertyMetadataIfSoftDeleting(
                oldRootObject, newRootObject, softDelete);

            var commandDefinition = new CommandDefinition(
                script.Buffer.ToString(),
                script.Parameters,
                transaction,
                30,
                CommandType.Text,
                CommandFlags.Buffered | CommandFlags.NoCache);

            var insertedPk = connection.ExecuteScalar(commandDefinition);
            if (null != insertedPk
                && null != script.InsertedValue)
            {
                //  Allows primary key of INSERTed row to be resolved
                //  in subsequent scripts.
                SetPrimaryKeyForInsertedRowOnCorrespondingObject(
                    script,
                    insertedPk);
            }

            SetSoftDeletePropertyValue(oldRootObject, softDeletePropertyMetadata);
        }

        private static PropertyMetadata GetMarkerPropertyMetadataIfSoftDeleting<T>(
            T oldRootObject,
            T newRootObject,
            bool softDelete)
        {
            PropertyMetadata softDeletePropertyMetadata = null;
            if (softDelete)
            {
                var metadata = _dtoMetadataCache.GetMetadataFor<T>();
                if (newRootObject == null && oldRootObject != null)
                {
                    softDeletePropertyMetadata = SoftDeleteValidator.GetValidatedSoftDeleteProperty(metadata);
                }
                else
                {
                    throw new ArgumentException(
                        string.Format(
                            "Setting the soft delete flag on an INSERT or UPDATE is invalid. Attempt made to soft "
                            + "delete on an INSERT or UPDATE of object type {0} is not permitted. You must execute "
                            + "the SoftDelete<T>(...) method, or manually set the value of the soft "
                            + "delete market property yourself to execute an UPDATE, instead.",
                            metadata.DtoType.FullName),
                        "newRootObject");
                }
            }
            return softDeletePropertyMetadata;
        }

        private static void SetSoftDeletePropertyValue<T>(T oldRootObject, PropertyMetadata softDeletePropertyMetadata)
        {
            if (softDeletePropertyMetadata != null)
            {
                var attr = softDeletePropertyMetadata.GetAttribute<SoftDeleteColumnAttribute>();
                softDeletePropertyMetadata.Prop.SetValue(oldRootObject, attr.TrueIndicatesDeleted);
            }
        }

        private static void SetPrimaryKeyForInsertedRowOnCorrespondingObject(
            Script script,
            object insertedPk)
        {
            var metadata = script.InsertedValueMetadata;
            var type = metadata.PrimaryKey.Prop.PropertyType;
            if (type == typeof(int?) || type == typeof(int))
            {
                metadata.SetPrimaryKey(
                    script.InsertedValue,
                    Decimal.ToInt32((decimal) insertedPk));
            }
            else if (type == typeof (long?) || type == typeof (long))
            {
                metadata.SetPrimaryKey(
                    script.InsertedValue,
                    Decimal.ToInt64((decimal) insertedPk));
            }
            else
            {
                metadata.SetPrimaryKey(
                    script.InsertedValue,
                    insertedPk);
            }
        }

        private static void ResolvePrimaryKeyValues<T>(Script script)
        {
            // ToArray() dodges exception due to concurrent modification
            foreach (string key in script.Parameters.Keys.ToArray())
            {
                var value = script.Parameters [key];
                if (value is Func<object>)
                {
                    script.Parameters [key] = (value as Func<object>)();
                }
            }
        }
    }
}
