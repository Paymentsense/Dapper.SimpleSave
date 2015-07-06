using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace Dapper.SimpleSave.Impl {
    public class ScriptBuilder
    {
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
            int paramIndex = 0;
            Script script = null;
            foreach (var command in commands)
            {
                if (script == null)
                {
                    script = new Script();
                    scripts.Add(script);
                }

                if (command is UpdateCommand)
                {
                    AppendUpdateCommand(script, command as UpdateCommand, ref paramIndex);
                }
                else if (command is InsertCommand)
                {
                    var hasNumericPk = AppendInsertCommand(script, command as InsertCommand, ref paramIndex);

                    if (hasNumericPk)
                    {
                        script.Buffer.Append(@"
SELECT SCOPE_IDENTITY();
");
                    }

                    script = null;
                }
                else if (command is DeleteCommand)
                {
                    AppendDeleteCommand(script, command as DeleteCommand, ref paramIndex);
                }
            }
        }

        private static void AppendUpdateCommand(Script script, UpdateCommand command, ref int paramIndex)
        {
            var firstOp = command.Operations.First();

            if (null != firstOp.OwnerPropertyMetadata
                && firstOp.OwnerPropertyMetadata.HasAttribute<OneToManyAttribute>()
                && firstOp.ValueMetadata.IsReferenceData
                && firstOp.ValueMetadata.HasUpdateableForeignKeys)
            {
                AppendReverseUpdateCommandForChildTableReferencingParent(script, command, ref paramIndex);
            }
            else
            {
                AppendStandardUpdateCommand(script, command, ref paramIndex);
            }
        }

        private static void AppendReverseUpdateCommandForChildTableReferencingParent(
            Script script,
            UpdateCommand command,
            ref int paramIndex)
        {
            var operation = command.Operations.FirstOrDefault();
            script.Buffer.Append(string.Format(@"UPDATE {0}
SET [{1}] = ",
                operation.ValueMetadata.TableName,
                operation.ValueMetadata.GetForeignKeyColumnFor(
                    operation.OwnerMetadata.DtoType).ColumnName));

            FormatWithParameter(
                script,
                "{0}",
                ref paramIndex,
                new Func<object>(() => command.PrimaryKey));

            script.Buffer.Append(string.Format(@"
WHERE [{0}] = ", operation.ValueMetadata.PrimaryKey.ColumnName));

            FormatWithParameter(script, @"{0};
", ref paramIndex, operation.ValueMetadata.GetPrimaryKeyValue(operation.Value));
        }

        private static void AppendStandardUpdateCommand(
            Script script,
            UpdateCommand command,
            ref int paramIndex)
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
                    FormatWithParameter(
                        script,
                        "{0}",
                        ref paramIndex,
                        operation.ValueMetadata.GetPrimaryKeyValue(operation.Value));
                }
                else
                {
                    FormatWithParameter(script, "{0}", ref paramIndex, operation.Value);
                }
                ++count;
            }

            script.Buffer.Append(string.Format(@"
WHERE [{0}] = ", command.PrimaryKeyColumn));
            FormatWithParameter(script, @"{0};
", ref paramIndex, new Func<object>(() => command.PrimaryKey));
        }

        private static void AppendDeleteCommand(Script script, DeleteCommand command, ref int paramIndex)
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
                        operation.OwnerPropertyMetadata.GetAttribute<ManyToManyAttribute>().SchemaQualifiedLinkTableName,
                        operation.OwnerPrimaryKeyColumn));

                    FormatWithParameter(script, "{0} AND ", ref paramIndex, operation.OwnerPrimaryKey);

                    script.Buffer.Append(string.Format("[{0}] = ", operation.ValueMetadata.PrimaryKey.Prop.Name));

                    FormatWithParameter(script, @"{0};
", ref paramIndex, operation.ValueMetadata.GetPrimaryKeyValue(operation.Value));
                }
                else if (operation.OwnerPropertyMetadata == null
                    || (operation.OwnerPropertyMetadata.HasAttribute<OneToManyAttribute>()
                    && !operation.ValueMetadata.HasAttribute<ReferenceDataAttribute>()))
                {
                    //  DELETE the value from the other table

                    script.Buffer.Append(string.Format(
                        @"DELETE FROM {0}
WHERE [{1}] = ",
                        operation.ValueMetadata.TableName,
                        operation.ValueMetadata.PrimaryKey.Prop.Name));
                    FormatWithParameter(script, @"{0};
", ref paramIndex, operation.ValueMetadata.GetPrimaryKeyValue(operation.Value));
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

        private bool AppendInsertCommand(Script script, InsertCommand command, ref int paramIndex)
        {
            PropertyMetadata guidPKColumn = null;
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
                        operation.OwnerPropertyMetadata.GetAttribute<ManyToManyAttribute>().SchemaQualifiedLinkTableName,
                        operation.OwnerPrimaryKeyColumn,
                        operation.ValueMetadata.PrimaryKey.Prop.Name));
                        FormatWithParameter(script, @"{0}, {1}
);
",
                            ref paramIndex,
                            new Func<object>(
                                () => operation.OwnerPrimaryKey),
                            new Func<object>(
                                () => operation.ValueMetadata.GetPrimaryKeyValue(operation.Value)));
                    }
                else if (operation.OwnerPropertyMetadata == null
                    || (operation.OwnerPropertyMetadata.HasAttribute<OneToManyAttribute>()
                    && !operation.ValueMetadata.HasAttribute<ReferenceDataAttribute>())) 
                {
                    //  INSERT the value into the table defined by ValueMetadata
                    
                    var colBuff = new StringBuilder();
                    var valBuff = new StringBuilder();
                    var values = new ArrayList();
                    var index = 0;

                    foreach (var property in operation.ValueMetadata.Properties)
                    {
                        if (property.IsPrimaryKey)
                        {
                            var type = property.Prop.PropertyType;
                            if (type != typeof (int)
                                && type != typeof (int?)
                                && type != typeof (long)
                                && type != typeof (long?))
                            {
                                if (property.Prop.PropertyType == typeof (Guid?)
                                    || property.Prop.PropertyType == typeof (Guid))
                                {
                                    guidPKColumn = property;
                                }
                                else
                                {
                                    throw new ArgumentException(string.Format(
                                        "Unsupported primary key type {0} on entity {1}. Primary keys must be nullable ints, longs or GUIDs.",
                                        type.FullName,
                                        operation.ValueMetadata.DtoType.FullName));
                                }
                            }

                            continue;
                        }

                        var getter = property.Prop.GetGetMethod();

                        if (getter == null
                            || property.HasAttribute<ManyToManyAttribute>()
                            || property.HasAttribute<OneToManyAttribute>()
                            || ! property.IsSaveable)
                        {
                            continue;
                        }

                        AppendPropertyToInsertStatement(
                            colBuff, valBuff, property, ref index, operation, values, getter);
                    }

                    script.Buffer.Append(string.Format(
                    @"INSERT INTO {0} (
    {1}
)",
                        operation.ValueMetadata.TableName,
                        colBuff));

                    if (guidPKColumn != null)
                    {
                        script.Buffer.Append(string.Format(@"
OUTPUT inserted.[{0}]
",
                            guidPKColumn.ColumnName));
                    }

                    script.Buffer.Append(@" VALUES (
    ");

                    FormatWithParameter(script, valBuff.ToString(), ref paramIndex, values.ToArray());
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

            return guidPKColumn == null;
        }

        private void AppendPropertyToInsertStatement(
            StringBuilder colBuff, StringBuilder valBuff, PropertyMetadata property,
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
                            propValue == null || propMetadata == null
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

        private static void FormatWithParameter(
            Script script,
            string formatString,
            ref int paramIndex,
            params object [] paramValues)
        {
            var paramNames = new ArrayList();
            for(int index = 0, count = paramValues.Length; index < count; ++index)
            {
                object paramValue = paramValues[index];
                string paramName = "p" + paramIndex;
                ValidateParameterValue(index, paramName, paramValue);
                script.Parameters[paramName] = paramValue;
                paramNames.Add("@" + paramName);
                ++paramIndex;
            }

            script.Buffer.Append(string.Format(formatString, paramNames.ToArray()));
        }

        private static void ValidateParameterValue(
            int index,
            string paramName,
            object paramValue)
        {
            if (paramValue == null || paramValue is string)
            {
                return;
            }

            var type = paramValue.GetType();
            if (type.IsValueType
                || (type.IsConstructedGenericType
                    && type.GetGenericTypeDefinition() == typeof(Func<>))) {
                return;
            }

            throw new ArgumentException(
                string.Format(
                    "Reference types other than string are not permitted as parameter values for generated SQL. "
                    + "Invalid value at index {0} for parameter @{1}: {2}",
                    index,
                    paramName,
                    paramValue),
                "paramValue");
        }
    }
}
