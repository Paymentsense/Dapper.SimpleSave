using System;
using System.CodeDom;
using System.Collections;
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

        public Script Build(IEnumerable<BaseCommand> commands)
        {
            var script = new Script();
            BuildInternal(commands, script);
            return script;
        }

        public void BuildInternal(IEnumerable<BaseCommand> commands, Script script)
        {
            int parmIndex = 0;
            foreach (var command in commands)
            {
                if (command is UpdateCommand)
                {
                    AppendUpdateCommand(script, command as UpdateCommand, ref parmIndex);
                }
                else if (command is InsertCommand)
                {
                    AppendInsertCommand(script, command as InsertCommand, ref parmIndex);
                }
                else if (command is DeleteCommand)
                {
                    AppendDeleteCommand(script, command as DeleteCommand, ref parmIndex);
                }
            }
        }

        private static void AppendUpdateCommand(Script script, UpdateCommand command, ref int parmIndex)
        {
            script.Buffer.Append(string.Format(@"UPDATE {0}
SET ", command.TableName));

            int count = 0;
            foreach (var operation in command.Operations)
            {
                if (count > 0)
                {
                    script.Buffer.Append(@",
    ");
                }
                script.Buffer.Append(string.Format(@"[{0}] = ", operation.ColumnName));
                FormatWithParm(script, "{0}", ref parmIndex, operation.Value);
                ++count;
            }

            script.Buffer.Append(string.Format(@"
WHERE {0} = ", command.PrimaryKeyColumn));
            FormatWithParm(script, @"{0};
", ref parmIndex, command.PrimaryKey);
        }

        private static void AppendDeleteCommand(Script script, DeleteCommand command, ref int parmIndex)
        {
            var operation = command.Operation;
            if (operation.ValueMetadata != null)
            {
                if (operation.OwnerPropertyMetadata.HasAttribute<ManyToManyAttribute>())
                {
                    //  Remove record in link table; don't touch either entity table

                    script.Buffer.Append(string.Format(
                        @"DELETE FROM {0}
WHERE {1} = ", 
                        operation.OwnerPropertyMetadata.GetAttribute<ManyToManyAttribute>().LinkTableName,
                        operation.OwnerPrimaryKeyColumn));
                    FormatWithParm(script, "{0} AND ", ref parmIndex, operation.OwnerPrimaryKey);
                    script.Buffer.Append(string.Format("{0} = ", operation.ValueMetadata.PrimaryKey.Prop.Name));
                    FormatWithParm(script, @"{0};
", ref parmIndex, operation.ValueMetadata.GetPrimaryKeyValue(operation.Value));
                }
                else if (operation.OwnerPropertyMetadata.HasAttribute<OneToManyAttribute>()
                    && !operation.ValueMetadata.HasAttribute<ReferenceDataAttribute>())
                {
                    //  DELETE the value from the other table

                    script.Buffer.Append(string.Format(
                        @"DELETE FROM {0}
WHERE {1} = ",
                        operation.ValueMetadata.TableName,
                        operation.ValueMetadata.PrimaryKey.Prop.Name));
                    FormatWithParm(script, @"{0};
", ref parmIndex, operation.ValueMetadata.GetPrimaryKeyValue(operation.Value));
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

        private void AppendInsertCommand(Script script, InsertCommand command, ref int parmIndex) {
            var operation = command.Operation;
            if (operation.ValueMetadata != null) {
                if (operation.OwnerPropertyMetadata.HasAttribute<ManyToManyAttribute>()) {
                    //  INSERT record in link table; don't touch either entity table

                    script.Buffer.Append(string.Format(
                        @"INSERT INTO {0} (
    {1}, {2}
) VALUES (
    ",
                        operation.OwnerPropertyMetadata.GetAttribute<ManyToManyAttribute>().LinkTableName,
                        operation.OwnerPrimaryKeyColumn,
                        operation.ValueMetadata.PrimaryKey.Prop.Name));
                    FormatWithParm(script, @"{0}, {1}
);
", ref parmIndex, operation.OwnerPrimaryKey, operation.ValueMetadata.GetPrimaryKeyValue(operation.Value));
                }
                else if (operation.OwnerPropertyMetadata.HasAttribute<OneToManyAttribute>()
                    && !operation.ValueMetadata.HasAttribute<ReferenceDataAttribute>()) 
                {
                    //  INSERT the value into the other table
                    
                    var colBuff = new StringBuilder();
                    var valBuff = new StringBuilder();
                    var values = new ArrayList();
                    var index = 0;

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

                        valBuff.Append("{");
                        valBuff.Append(index);
                        valBuff.Append("}");

                        if (property.HasAttribute<ForeignKeyReferenceAttribute>()
                            && _dtoMetadataCache.GetMetadataFor(
                                property.GetAttribute<ForeignKeyReferenceAttribute>().ReferencedDto).TableName == operation.OwnerMetadata.TableName)
                        {
                            values.Add(operation.OwnerPrimaryKey);
                        }
                        else
                        {
                            values.Add(getter.Invoke(operation.Value, new object[0]));
                        }

                        ++index;
                    }

                    script.Buffer.Append(string.Format(
                    @"INSERT INTO {0} (
    {1}
) VALUES (
    ",
                        operation.ValueMetadata.TableName,
                        colBuff));
                    FormatWithParm(script, valBuff.ToString(), ref parmIndex, values.ToArray());
                    script.Buffer.Append(@"
);
");
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

        private static void FormatWithParm(
            Script script,
            string formatString,
            ref int parmIndex,
            params object [] parmValues)
        {
            var parmNames = new ArrayList();
            foreach (object parmValue in parmValues)
            {
                string parmName = "p" + parmIndex;
                script.Parameters[parmName] = parmValue;
                parmNames.Add("@" + parmName);
                ++parmIndex;
            }

            script.Buffer.Append(string.Format(formatString, parmNames.ToArray()));
        }
    }
}
