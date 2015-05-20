using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Dapper.SimpleSave.Impl {
    public class ScriptBuilder {

        public string Build(IEnumerable<BaseCommand> commands)
        {
            var buff = new StringBuilder();
            BuildInternal(commands, buff);
            return buff.ToString();
        }

        public string BuildTransaction(IEnumerable<BaseCommand> commands)
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

        public void BuildInternal(IEnumerable<BaseCommand> commands, StringBuilder buff)
        {
            foreach (var command in commands)
            {
                if (command is UpdateCommand)
                {
                    AppendUpdateCommand(buff, command as UpdateCommand);
                }
                else if (command is DeleteCommand)
                {
                    AppendDeleteCommand(buff, command as DeleteCommand);
                }
            }
        }

        private static void AppendUpdateCommand(StringBuilder buff, UpdateCommand command)
        {
            buff.Append(string.Format(@"UPDATE {0}
        SET ", command.TableName));

            int count = 0;
            foreach (var operation in command.Operations)
            {
                if (count > 0)
                {
                    buff.Append(@",
            ");
                }
                buff.Append(string.Format(@"[{0}] = '{1}'", operation.ColumnName, operation.Value));
                ++count;
            }

            buff.Append(string.Format(@"
WHERE {0} = '{1}';
", command.PrimaryKeyColumn, command.PrimaryKey));
        }

        private static void AppendDeleteCommand(StringBuilder buff, DeleteCommand command)
        {
            var operation = command.Operation;
            if (operation.ValueMetadata != null)
            {
                if (operation.OwnerPropertyMetadata.HasAttribute<ManyToManyAttribute>())
                {
                    //  Remove record in link table; don't touch either entity table

                    buff.Append(string.Format(
                        @"DELETE FROM {0}
WHERE {1} = {2} AND {3} = {4};", 
                        operation.OwnerPropertyMetadata.GetAttribute<ManyToManyAttribute>().LinkTableName,
                        operation.OwnerPrimaryKeyColumn,
                        operation.OwnerPrimaryKey,
                        operation.ValueMetadata.PrimaryKey.Prop.Name,
                        operation.ValueMetadata.GetPrimaryKeyValue(operation.Value)));
                }

                if (operation.OwnerPropertyMetadata.HasAttribute<OneToManyAttribute>()
                    && !operation.ValueMetadata.HasAttribute<ReferenceDataAttribute>())
                {
                    //  DELETE the value from the other table
                    buff.Append(string.Format(
                        @"DELETE FROM {0}
WHERE {1} = {2};",
                        operation.ValueMetadata.TableName,
                        operation.ValueMetadata.PrimaryKey.Prop.Name,
                        operation.ValueMetadata.GetPrimaryKeyValue(operation.Value)));
                }
            }
            else
            {
                throw new ArgumentException(
                    string.Format(
                        "Invalid DELETE command: {0}",
                        JsonConvert.SerializeObject(command)),
                    "command");
            }
        }
    }
}
