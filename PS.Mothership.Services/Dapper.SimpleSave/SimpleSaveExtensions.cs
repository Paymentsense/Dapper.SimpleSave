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
            var commands = operationBuilder.Coalesce(operations);

            var scriptBuilder = new ScriptBuilder(_dtoMetadataCache);
            var script = scriptBuilder.Build(commands);

            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    var commandDefinition = new CommandDefinition(
                        script.Buffer.ToString(),
                        script.Parameters,
                        transaction,
                        30,
                        CommandType.Text,
                        CommandFlags.Buffered | CommandFlags.NoCache);
                    connection.Execute(commandDefinition);
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
            Create<T>(connection, new [] { obj });
        }

        public static void Create<T>(this IDbConnection connection, IEnumerable<T> collection)
        {
            throw new NotImplementedException();
        }
    }
}
