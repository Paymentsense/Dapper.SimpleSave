using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.SimpleSave.Impl;

namespace Dapper.SimpleSave {
    public static class SimpleSaveExtensions
    {

        private static readonly DtoMetadataCache _dtoMetadataCache = new DtoMetadataCache();

        public static void Update<T>(this IDbConnection connection, T oldObject, T newObject)
        {
            var differ = new Differ(_dtoMetadataCache);
            var differences = differ.Diff(oldObject, newObject);

            var operationBuilder = new OperationBuilder();
            var operations = operationBuilder.Build(differences);

            var commandBuilder = new CommandBuilder();
            var commands = commandBuilder.Coalesce(operations);

            var scriptBuilder = new ScriptBuilder(_dtoMetadataCache);
            var scripts = scriptBuilder.Build(commands);

            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    object insertedPk = null;
                    for (int index = 0, count = scripts.Count; index < count; ++index)
                    {
                        var script = scripts[index];

                        //  Resolve PKs (and dodge concurrent modification exception).
                        foreach (string key in script.Parameters.Keys.ToArray())
                        {
                            var value = script.Parameters[key];
                            if (value is Func<object>)
                            {
                                script.Parameters[key] = (value as Func<object>)();
                            }
                        }

                        var commandDefinition = new CommandDefinition(
                            script.Buffer.ToString(),
                            script.Parameters,
                            transaction,
                            30,
                            CommandType.Text,
                            CommandFlags.Buffered | CommandFlags.NoCache);
                        if (index < count - 1)
                        {
                            insertedPk = connection.ExecuteScalar(commandDefinition);
                            if (null != insertedPk && insertedPk is decimal && null != script.InsertedValue)
                            {
                                script.InsertedValueMetadata.SetPrimaryKey(
                                    script.InsertedValue,
                                    Decimal.ToInt32((decimal) insertedPk));
                            }
                        }
                        else
                        {
                            connection.Execute(commandDefinition);                            
                        }
                    
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
    }
}
