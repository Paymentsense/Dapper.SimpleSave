using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Impl {
    public class ScriptBuilder {

        public string Build(IEnumerable<UpdateCommand> commands)
        {
            var buff = new StringBuilder();
            BuildInternal(commands, buff);
            return buff.ToString();
        }

        public string BuildTransaction(IEnumerable<UpdateCommand> commands)
        {
            var buff = new StringBuilder();
            buff.Append(@"SET XACT_ABORT ON;
BEGIN TRANSACTION;

");

            BuildInternal(commands, buff);

            buff.Append(@"

COMMIT TRANSACTION;");
            return buff.ToString();
        }

        public void BuildInternal(IEnumerable<UpdateCommand> commands, StringBuilder buff)
        {
            foreach (var command in commands)
            {
                buff.Append(string.Format(@"UPDATE {0}", command.TableName));
                
                foreach (var operation in command.Operations)
                {
                    buff.Append(string.Format(@"SET [{0}] = '{1}', ", operation.ColumnName, operation.Value));
                }

                buff.Append(string.Format(@"WHERE {0} = '{1}'", command.PrimaryKeyColumn, command.PrimaryKey));
                buff.Append("\r\n");
            }
        }
    }
}
