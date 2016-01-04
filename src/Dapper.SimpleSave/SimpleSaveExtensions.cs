using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Transactions;
using Castle.Core.Internal;
using Dapper.SimpleSave.Impl;

namespace Dapper.SimpleSave
{
    public static class SimpleSaveExtensions
    {
        public static readonly DtoMetadataCache MetadataCache = new DtoMetadataCache();

        private static ISimpleSaveLogger _logger = new BasicSimpleSaveLogger();

        static SimpleSaveExtensions()
        {
            LogBuiltScripts = false;
            LogScriptsPreExecution = true;
            LogScriptsPostExecution = false;
            ExecutionTimeWarningEmitThresholdMilliseconds = 100;
            ThrowOnMultipleWriteablePropertiesAgainstSameColumn = true;
            IsRdbmsCaseSensitive = false;
            IsExplicitBackReferenceResolutionEnabled = true;
        }

        public static ISimpleSaveLogger Logger
        {
            get { return _logger; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(
                        "value",
                        "Specifying a null ISimpleSaveLogger is not permitted.");
                }
                _logger = value;
            }
        }

        public static bool LogBuiltScripts { get; set; }
        public static bool LogScriptsPreExecution { get; set; }
        public static bool LogScriptsPostExecution { get; set; }
        public static long ExecutionTimeWarningEmitThresholdMilliseconds { get; set; }
        public static bool ThrowOnMultipleWriteablePropertiesAgainstSameColumn { get; set; }
        public static bool IsRdbmsCaseSensitive { get; set; }
        public static bool IsExplicitBackReferenceResolutionEnabled { get; set; }

        public static event EventHandler<DifferenceEventArgs> DifferenceProcessed;

        internal static void OnDifferenceProcessed(DifferenceEventArgs args)
        {
            var handlers = DifferenceProcessed;
            if (handlers != null)
            {
                handlers(typeof(SimpleSaveExtensions), args);
            }
        }

        public static void UpdateAll<T>(
            this IDbConnection connection,
            IList<T> oldObjects,
            IList<T> newObjects,
            IDbTransaction transaction = null)
        {
            if (oldObjects.Count != newObjects.Count)
            {
                throw new ArgumentException(string.Format(
                    "Mismatch between length of old object list ({0}) and length of new object list."));
            }

            var target = oldObjects.Zip(newObjects, Tuple.Create);
            UpdateAll(connection, target, transaction);
        }

        public static void UpdateAll<T>(
            this IDbConnection connection,
            IEnumerable<Tuple<T, T>> oldAndNewObjects,
            IDbTransaction transaction = null)
        {
            UpdateInternal(connection, oldAndNewObjects, false, transaction);
        }

        public static void UpdateAll<T>(
            this IDbConnection connection,
            IEnumerable<T> newObjects,
            Func<T, T> mapNewObjectToOldObject,
            IDbTransaction transaction = null)
        {
            UpdateAll(
                connection,
                newObjects.Select(
                    newObject => Tuple.Create(mapNewObjectToOldObject(newObject), newObject)),
                transaction);
        }

        public static void UpdateAllMappingFromOldObjects<T>(
            this IDbConnection connection,
            IEnumerable<T> oldObjects,
            Func<T, T> mapOldObjectToNewObject,
            IDbTransaction transaction = null)
        {
            UpdateAll(
                connection,
                oldObjects.Select(
                    oldObject => Tuple.Create(oldObject, mapOldObjectToNewObject(oldObject))),
                transaction);
        }

        public static void Update<T>(
            this IDbConnection connection,
            T oldObject,
            T newObject,
            IDbTransaction transaction = null)
        {
            UpdateAll(
                connection,
                new [] {Tuple.Create(oldObject, newObject)},
                transaction);
        }

        public static void CreateAll<T>(
            this IDbConnection connection,
            IEnumerable<T> newObjects,
            IDbTransaction transaction = null)
        {
            UpdateAll(
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

        public static void DeleteAll<T>(
            this IDbConnection connection,
            IEnumerable<T> oldObjects,
            IDbTransaction transaction = null)
        {
            UpdateAll(
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

        public static void SoftDeleteAll<T>(
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
            var builder = new TransactionBuilder(MetadataCache);
            IDictionary<Tuple<T, T>, IList<IScript>> scripts = new Dictionary<Tuple<T, T>, IList<IScript>>();
            foreach (var pair in oldAndNewObjects)
            {
                scripts[pair] = builder.BuildUpdateScripts(pair.Item1, pair.Item2, softDelete);
            }

            Transaction ambient = null;
            if (transaction == null)
            {
                ambient = Transaction.Current;
            }

            if (transaction == null && ambient == null)
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
                    }
                    catch (Exception ex)
                    {
                        if (Logger.Wrapped.IsErrorEnabled)
                        {
                            Logger.Wrapped.Error(new
                            {
                                message = "Error executing internal transaction",
                                exception = ex,
                                scripts
                            });
                        }
                        myTransaction.Rollback();
                        throw;
                    }
                }
            }
            else
            {
                try
                {
                    ExecuteScriptsForTuples(
                        connection,
                        oldAndNewObjects,
                        scripts,
                        softDelete,
                        transaction);
                }
                catch (Exception ex)
                {
                    if (Logger.Wrapped.IsErrorEnabled)
                    {
                        Logger.Wrapped.Error(new
                        {
                            message = "Error executing external transaction",
                            exception = ex,
                            scripts
                        });
                    }
                    throw;
                }
            }
        }

        private static void ExecuteScriptsForTuples<T>(
            IDbConnection connection,
            IEnumerable<Tuple<T, T>> oldAndNewObjects,
            IDictionary<Tuple<T, T>, IList<IScript>> scripts,
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
            IList<IScript> scripts,
            T oldRootObject,
            T newRootObject,
            bool softDelete,
            IDbTransaction transaction)
        {
            var wireUpActions = new List<Action>();
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

                wireUpActions.AddRange(script.WireUpActions);
            }

            foreach (var action in wireUpActions)
            {
                action();
            }

            if (IsExplicitBackReferenceResolutionEnabled)
            {
                var resolver = new ExplicitTransitiveBackReferenceResolver(MetadataCache);
                resolver.Resolve(newRootObject);
            }
        }

        private static void ExecuteCommandForScript<T>(
            IDbConnection connection,
            T oldRootObject,
            T newRootObject,
            bool softDelete,
            IDbTransaction transaction,
            IScript script)
        {
            _logger.LogPreExecution(script);


            PropertyMetadata softDeletePropertyMetadata = GetMarkerPropertyMetadataIfSoftDeleting(
                oldRootObject, newRootObject, softDelete);

            var commandDefinition = new CommandDefinition(
                script.Buffer.ToString(),
                script.Parameters,
                transaction,
                30,
                CommandType.Text,
                CommandFlags.Buffered | CommandFlags.NoCache);

            var startTime = DateTime.Now.Ticks;
            var insertedPk = connection.ExecuteScalar(commandDefinition);
            var totalTime = (DateTime.Now.Ticks - startTime) / TimeSpan.TicksPerMillisecond;

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

            _logger.LogPostExecution(script);
            _logger.LogExecutionTime(totalTime);
        }

        private static PropertyMetadata GetMarkerPropertyMetadataIfSoftDeleting<T>(
            T oldRootObject,
            T newRootObject,
            bool softDelete)
        {
            PropertyMetadata softDeletePropertyMetadata = null;
            if (softDelete)
            {
                var metadata = MetadataCache.GetMetadataFor<T>();
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
            IScript script,
            object insertedPk)
        {
            var metadata = script.InsertedValueMetadata;
            if (_logger.Wrapped.IsDebugEnabled)
            {
                _logger.Wrapped.Debug(string.Format(
                    "Setting {0} primary key value of expected type {1} to type {2}, value {3}",
                    metadata.DtoType,
                    metadata.PrimaryKey.Prop.PropertyType,
                    insertedPk == null ? "NULL" : insertedPk.GetType().ToString(),
                    insertedPk));
            }

            var type = metadata.PrimaryKey.Prop.PropertyType;
            if (type == typeof(int?) || type == typeof(int))
            {
                insertedPk = CoerceNumericPkToDecimal(insertedPk);
                metadata.SetPrimaryKey(
                    script.InsertedValue,
                    Decimal.ToInt32((decimal) insertedPk));
            }
            else if (type == typeof (long?) || type == typeof (long))
            {
                insertedPk = CoerceNumericPkToDecimal(insertedPk);
                metadata.SetPrimaryKey(
                    script.InsertedValue,
                    Decimal.ToInt64((decimal) insertedPk));
            }
            else
            {
                metadata.SetPrimaryKey(
                    script.InsertedValue,
                    TryToCoerceGuidPkToGuid(insertedPk));
            }
        }

        private static object CoerceNumericPkToDecimal(object insertedPk)
        {
            if (insertedPk is int)
            {
                insertedPk = (decimal) (int) insertedPk;
            }
            else if (insertedPk is long)
            {
                insertedPk = (decimal) (long) insertedPk;
            }
            else if (insertedPk != null && insertedPk is string)
            {
                insertedPk = decimal.Parse(insertedPk.ToString());
            }
            return insertedPk;
        }

        private static object TryToCoerceGuidPkToGuid(object insertedPk)
        {
            if (insertedPk == null || insertedPk is Guid || insertedPk is Guid?)
            {
                return insertedPk;
            }

            try
            {
                return Guid.Parse(insertedPk.ToString());
            }
            catch (FormatException)
            {
                return insertedPk;
            }
        }

        private static void ResolvePrimaryKeyValues<T>(IScript script)
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
