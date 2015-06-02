using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection;
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

        public IList<Script> Build(IEnumerable<BaseCommand> commands)
        {
            var scripts = new List<Script>();
            BuildInternal(commands, scripts);
            return scripts;
        }

        public void BuildInternal(IEnumerable<BaseCommand> commands, IList<Script> scripts)
        {
            int parmIndex = 0;
            Script script = null;
            foreach (var command in commands)
            {
                if (null == script)
                {
                    script = new Script();
                    scripts.Add(script);
                }

                if (command is UpdateCommand)
                {
                    AppendUpdateCommand(script, command as UpdateCommand, ref parmIndex);
                }
                else if (command is InsertCommand)
                {
                    AppendInsertCommand(script, command as InsertCommand, ref parmIndex);

                    script.Buffer.Append(@"
SELECT SCOPE_IDENTITY();
");

                    script = null;
                }
                else if (command is DeleteCommand)
                {
                    AppendDeleteCommand(script, command as DeleteCommand, ref parmIndex);
                }
            }
        }

        private static void AppendUpdateCommand(Script script, UpdateCommand command, ref int parmIndex)
        {
            var firstOp = command.Operations.FirstOrDefault();
            if (null == firstOp)
            {
                throw new ArgumentException(
                    "Cannot create UPDATE script for command with no operations.",
                    "command");
            }

            if (null != firstOp.OwnerPropertyMetadata
                && firstOp.OwnerPropertyMetadata.HasAttribute<OneToManyAttribute>()
                && firstOp.ValueMetadata.IsReferenceData
                && firstOp.ValueMetadata.HasUpdateableForeignKeys)
            {
                AppendReverseUpdateCommandForChildTableReferencingParent(script, command, ref parmIndex);
            }
            else
            {
                AppendStandardUpdateCommand(script, command, ref parmIndex);
            }
        }

        private static void AppendReverseUpdateCommandForChildTableReferencingParent(
            Script script,
            UpdateCommand command,
            ref int parmIndex)
        {
            var operation = command.Operations.FirstOrDefault();
            script.Buffer.Append(string.Format(@"UPDATE {0}
SET [{1}] = ",
                operation.ValueMetadata.TableName,
                operation.ValueMetadata.GetForeignKeyColumnFor(operation.OwnerMetadata.DtoType).ColumnName));

            FormatWithParm(script, "{0}", ref parmIndex, new Func<object>(() => command.PrimaryKey));

            script.Buffer.Append(string.Format(@"
WHERE [{0}] = ", operation.ValueMetadata.PrimaryKey.ColumnName));

            FormatWithParm(script, @"{0};
", ref parmIndex, operation.ValueMetadata.GetPrimaryKeyValue(operation.Value));
        }

        private static void AppendStandardUpdateCommand(Script script, UpdateCommand command, ref int parmIndex)
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
                bool useKey = false;

                if (null != operation.ValueMetadata)
                {
                    if ((null != operation.OwnerPropertyMetadata
                     && (operation.OwnerPropertyMetadata.HasAttribute<OneToOneAttribute>()
                         || operation.OwnerPropertyMetadata.HasAttribute<ManyToOneAttribute>())))
                    {
                        useKey = true;
                    }
                    else if (operation.ValueMetadata.HasAttribute<ReferenceDataAttribute>())
                    {
                        useKey = true;
                    }
                }

                if (useKey)
                {
                    FormatWithParm(script, "{0}", ref parmIndex, operation.ValueMetadata.GetPrimaryKeyValue(operation.Value));
                }
                else
                {
                    FormatWithParm(script, "{0}", ref parmIndex, operation.Value);
                }
                ++count;
            }

            script.Buffer.Append(string.Format(@"
WHERE [{0}] = ", command.PrimaryKeyColumn));
            FormatWithParm(script, @"{0};
", ref parmIndex, new Func<object>(() => command.PrimaryKey));
        }

        private static void AppendDeleteCommand(Script script, DeleteCommand command, ref int parmIndex)
        {
            var operation = command.Operation;
            if (operation.ValueMetadata != null)
            {
                if (null != operation.OwnerPropertyMetadata
                    && operation.OwnerPropertyMetadata.HasAttribute<ManyToManyAttribute>())
                {
                    //  Remove record in link table; don't touch either entity table

                    script.Buffer.Append(string.Format(
                        @"DELETE FROM {0}
WHERE [{1}] = ", 
                        operation.OwnerPropertyMetadata.GetAttribute<ManyToManyAttribute>().LinkTableName,
                        operation.OwnerPrimaryKeyColumn));
                    FormatWithParm(script, "{0} AND ", ref parmIndex, operation.OwnerPrimaryKey);
                    script.Buffer.Append(string.Format("[{0}] = ", operation.ValueMetadata.PrimaryKey.Prop.Name));
                    FormatWithParm(script, @"{0};
", ref parmIndex, operation.ValueMetadata.GetPrimaryKeyValue(operation.Value));
                }
                else if (null == operation.OwnerPropertyMetadata
                    || (operation.OwnerPropertyMetadata.HasAttribute<OneToManyAttribute>()
                    && !operation.ValueMetadata.HasAttribute<ReferenceDataAttribute>()))
                {
                    //  DELETE the value from the other table

                    script.Buffer.Append(string.Format(
                        @"DELETE FROM {0}
WHERE [{1}] = ",
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
                if (null != operation.OwnerPropertyMetadata
                    && operation.OwnerPropertyMetadata.HasAttribute<ManyToManyAttribute>()) {
                    //  INSERT record in link table; don't touch either entity table

                    script.Buffer.Append(string.Format(
                        @"INSERT INTO {0} (
    [{1}], [{2}]
) VALUES (
    ",
                        operation.OwnerPropertyMetadata.GetAttribute<ManyToManyAttribute>().LinkTableName,
                        operation.OwnerPrimaryKeyColumn,
                        operation.ValueMetadata.PrimaryKey.Prop.Name));
                        FormatWithParm(script, @"{0}, {1}
);
",
                            ref parmIndex,
                            new Func<object>(() => operation.OwnerPrimaryKey),
                            new Func<object>(() => operation.ValueMetadata.GetPrimaryKeyValue(operation.Value)));
                        //GetPossiblyUnknownPrimaryKeyValue(operation.ValueMetadata.GetPrimaryKeyValue(operation.Value)));
                    }
                else if (null == operation.OwnerPropertyMetadata
                    || (operation.OwnerPropertyMetadata.HasAttribute<OneToManyAttribute>()
                    && !operation.ValueMetadata.HasAttribute<ReferenceDataAttribute>())) 
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
                            continue;   //  TODO: return PK from script and associate with object
                        }

                        var getter = property.Prop.GetGetMethod();

                        if (getter == null
                            || property.HasAttribute<ManyToManyAttribute>()
                            || property.HasAttribute<OneToManyAttribute>()
                            || ! property.IsSaveable)
                        {
                            continue;
                        }

                        AppendPropertyToInsertStatement(colBuff, valBuff, property, ref index, operation, values, getter);
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
                    script.InsertedValue = operation.Value;
                    script.InsertedValueMetadata = operation.ValueMetadata;
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

        private void AppendPropertyToInsertStatement(StringBuilder colBuff, StringBuilder valBuff, PropertyMetadata property,
            ref int index, BaseInsertDeleteOperation operation, ArrayList values, MethodInfo getter)
        {
            if (property.HasAttribute<ForeignKeyReferenceAttribute>()
                && null != operation.OwnerMetadata
                && _dtoMetadataCache.GetMetadataFor(
                    property.GetAttribute<ForeignKeyReferenceAttribute>().ReferencedDto).TableName ==
                operation.OwnerMetadata.TableName)
            {
                values.Add(
                    new Func<object>(() => operation.OwnerPrimaryKey));
                //GetPossiblyUnknownPrimaryKeyValue(operation.OwnerPrimaryKey));
            }
            else if (property.HasAttribute<ManyToOneAttribute>() || property.HasAttribute<OneToOneAttribute>())
            {
                if (property.HasAttribute<OneToOneAttribute>() && !property.HasAttribute<ForeignKeyReferenceAttribute>())
                {
                    //  One to one relationship where child table references parent rather than the other way around.
                    //  This will be saved along with the child object.
                    return;
                }

                object propValue = property.GetValue(operation.Value);
                DtoMetadata propMetadata = _dtoMetadataCache.GetMetadataFor(property.Prop.PropertyType);
                values.Add(
                    new Func<object>(
                        () =>
                            null == propValue || null == propMetadata
                                ? null
                                : propMetadata.GetPrimaryKeyValue(propValue)));
            }
            else
            {
                values.Add(getter.Invoke(operation.Value, new object[0]));
            }

            if (colBuff.Length > 0) {
                colBuff.Append(@", ");
                valBuff.Append(@", ");
            }

            colBuff.Append("[" + property.ColumnName + "]");

            valBuff.Append("{");
            valBuff.Append(index);
            valBuff.Append("}");

            ++index;
        }

        private static void FormatWithParm(
            Script script,
            string formatString,
            ref int parmIndex,
            params object [] parmValues)
        {
            var parmNames = new ArrayList();
            for(int index = 0, count = parmValues.Length; index < count; ++index)
            {
                object parmValue = parmValues[index];
                string parmName = "p" + parmIndex;
                ValidateParmValue(index, parmName, parmValue);
                script.Parameters[parmName] = parmValue;
                parmNames.Add("@" + parmName);
                ++parmIndex;
            }

            script.Buffer.Append(string.Format(formatString, parmNames.ToArray()));
        }

        private static void ValidateParmValue(
            int index,
            string parmName,
            object parmValue)
        {
            if (null == parmValue || parmValue is string) {
                return;
            }

            var type = parmValue.GetType();
            if (type.IsValueType
                || (type.IsConstructedGenericType
                    && type.GetGenericTypeDefinition() == typeof(Func<>))) {
                return;
            }

            throw new ArgumentException(
                string.Format(
                    "Reference types other than string are not permitted as parameter values for generated SQL. Invalid value at index {0} for parameter @{1}: {2}",
                    index,
                    parmName,
                    parmValue),
                "parmValues");
        }
    }
}
