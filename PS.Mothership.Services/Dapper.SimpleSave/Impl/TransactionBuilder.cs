using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Impl
{
    public class TransactionBuilder
    {

        private readonly DtoMetadataCache _dtoMetadataCache;

        public TransactionBuilder(DtoMetadataCache dtoMetadataCache)
        {
            _dtoMetadataCache = dtoMetadataCache;
        }

        public IList<Script> BuildUpdateScripts<T>(T oldObject, T newObject, bool softDelete = false)
        {
            var differ = new Differ(_dtoMetadataCache);
            var differences = differ.Diff(oldObject, newObject, softDelete);

            var operationBuilder = new OperationBuilder();
            var operations = operationBuilder.Build(differences);

            var commandBuilder = new CommandBuilder();
            var commands = commandBuilder.Coalesce(operations);

            var scriptBuilder = new ScriptBuilder(_dtoMetadataCache);
            var scripts = scriptBuilder.Build(commands);
            return scripts;
        }
    }
}
