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
        private readonly DtoMetadataCache _dtoMetadataCache;

        public ScriptBuilder(DtoMetadataCache dtoMetadataCache)
        {
            _dtoMetadataCache = dtoMetadataCache;
        }

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

COMMIT TRANSACTION;
SET XACT_ABORT OFF;
");
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
                else if (command is InsertCommand)
                {
                    AppendInsertCommand(buff, command as InsertCommand);
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
WHERE {1} = {2} AND {3} = {4};
", 
                        operation.OwnerPropertyMetadata.GetAttribute<ManyToManyAttribute>().LinkTableName,
                        operation.OwnerPrimaryKeyColumn,
                        operation.OwnerPrimaryKey,
                        operation.ValueMetadata.PrimaryKey.Prop.Name,
                        operation.ValueMetadata.GetPrimaryKeyValue(operation.Value)));
                }
                else if (operation.OwnerPropertyMetadata.HasAttribute<OneToManyAttribute>()
                    && !operation.ValueMetadata.HasAttribute<ReferenceDataAttribute>())
                {
                    //  DELETE the value from the other table
                    buff.Append(string.Format(
                        @"DELETE FROM {0}
WHERE {1} = {2};
",
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

        private void AppendInsertCommand(StringBuilder buff, InsertCommand command) {
            var operation = command.Operation;
            if (operation.ValueMetadata != null) {
                if (operation.OwnerPropertyMetadata.HasAttribute<ManyToManyAttribute>()) {
                    //  Remove record in link table; don't touch either entity table

                    buff.Append(string.Format(
                        @"INSERT INTO {0} (
    {1}, {3}
) VALUES (
    {2}, {4}
);
",
                        operation.OwnerPropertyMetadata.GetAttribute<ManyToManyAttribute>().LinkTableName,
                        operation.OwnerPrimaryKeyColumn,
                        operation.OwnerPrimaryKey,
                        operation.ValueMetadata.PrimaryKey.Prop.Name,
                        operation.ValueMetadata.GetPrimaryKeyValue(operation.Value)));
                }
                else if (operation.OwnerPropertyMetadata.HasAttribute<OneToManyAttribute>()
                    && !operation.ValueMetadata.HasAttribute<ReferenceDataAttribute>()) 
                {
                        //  INSERT the value from the other table
                    
                    var colBuff = new StringBuilder();
                    var valBuff = new StringBuilder();

                    foreach (var property in operation.ValueMetadata.Properties)
                    {
                        if (property.IsPrimaryKey)
                        {
                            continue;
                        }

                        var getter = property.Prop.GetGetMethod();

                        if (getter == null)
                        {
                            continue;
                        }

                        if (colBuff.Length > 0)
                        {
                            colBuff.Append(@", ");
                            valBuff.Append(@", ");
                        }

                        colBuff.Append(property.Prop.Name);

                        if (property.HasAttribute<ForeignKeyReferenceAttribute>()
                            && _dtoMetadataCache.GetMetadataFor(
                                property.GetAttribute<ForeignKeyReferenceAttribute>().ReferencedDto).TableName == operation.OwnerMetadata.TableName)
                        {
                            valBuff.Append(operation.OwnerPrimaryKey);
                        }
                        else
                        {
                            valBuff.Append(getter.Invoke(operation.Value, new object[0]));
                        }
                    }

                    buff.Append(string.Format(
                    @"INSERT INTO {0} (
    {1}
) VALUES (
    {2}
);
",
                        operation.ValueMetadata.TableName,
                        colBuff,
                        valBuff));

                }
            }
            else
            {
                throw new ArgumentException(
                    string.Format(
                        "Invalid INSERT command: {0}",
                        JsonConvert.SerializeObject(command)),
                    "command");
            }
        }
    }
}
