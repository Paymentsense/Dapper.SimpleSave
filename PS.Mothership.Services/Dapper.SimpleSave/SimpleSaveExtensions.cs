using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper.SimpleSave.Impl;

namespace Dapper.SimpleSave
{
    public static class SimpleSaveExtensions
    {

        private static readonly DtoMetadataCache _dtoMetadataCache = new DtoMetadataCache();

        public static void Update<T>(
            this IDbConnection connection,
            T oldObject,
            T newObject)
        {
            var scripts = BuildUpdateScripts(oldObject, newObject);

            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    for (int index = 0, count = scripts.Count; index < count; ++index)
                    {
                        var script = scripts[index];

                        ResolvePrimaryKeyValues<T>(script);

                        ExecuteCommandForScript<T>(
                            connection,
                            transaction,
                            script,
                            index < count - 1);
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public static void Create<T>(this IDbConnection connection, T obj)
        {
            Update(connection, default(T), obj);
        }

        public static void Delete<T>(this IDbConnection connection, T obj)
        {
            Update(connection, obj, default(T));
        }

        private static IList<Script> BuildUpdateScripts<T>(T oldObject, T newObject)
        {
            var differ = new Differ(_dtoMetadataCache);
            var differences = differ.Diff(oldObject, newObject);

            var operationBuilder = new OperationBuilder();
            var operations = operationBuilder.Build(differences);

            var commandBuilder = new CommandBuilder();
            var commands = commandBuilder.Coalesce(operations);

            var scriptBuilder = new ScriptBuilder(_dtoMetadataCache);
            var scripts = scriptBuilder.Build(commands);
            return scripts;
        }

        private static void ExecuteCommandForScript<T>(
            IDbConnection connection,
            IDbTransaction transaction,
            Script script,
            bool isFinalScript)
        {
            var commandDefinition = new CommandDefinition(
                script.Buffer.ToString(),
                script.Parameters,
                transaction,
                30,
                CommandType.Text,
                CommandFlags.Buffered | CommandFlags.NoCache);
            if (!isFinalScript)
            {
                var insertedPk = connection.ExecuteScalar(commandDefinition);
                if (null != insertedPk
                    && insertedPk is decimal
                    && null != script.InsertedValue)
                {
                    //  Allows primary key of INSERTed row to be resolved
                    //  in subsequent scripts.
                    script.InsertedValueMetadata.SetPrimaryKey(
                        script.InsertedValue,
                        Decimal.ToInt32((decimal)insertedPk));
                }
            }
            else
            {
                connection.Execute(commandDefinition);
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
