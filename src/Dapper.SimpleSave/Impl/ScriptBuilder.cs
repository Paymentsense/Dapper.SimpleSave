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
                    var isPkAssignedByRdbms = AppendInsertCommand(script, command as InsertCommand, ref paramIndex);

                    if (isPkAssignedByRdbms)    //  Don't need to terminate batch with user assigned PK
                    {
                        SimpleSaveExtensions.Logger.LogBuilt(script);
                        script = null;
                    }
                }
                else if (command is DeleteCommand)
                {
                    AppendDeleteCommand(script, command as DeleteCommand, ref paramIndex);
                }
            }

            if (script != null)
            {
                SimpleSaveExtensions.Logger.LogBuilt(script);
            }
        }

        private static void AppendUpdateCommand(Script script, UpdateCommand command, ref int paramIndex)
        {
            if (ReverseUpdateHelper.IsReverseUpdateWithChildReferencingParent(command.Operations.First()))
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
                new Func<object>(() => command.PrimaryKeyAsObject));

            script.Buffer.Append(string.Format(@"
WHERE [{0}] = ", operation.ValueMetadata.PrimaryKey.ColumnName));

            FormatWithParameter(script, @"{0};
", ref paramIndex, new Func<object>(() => operation.ValueMetadata.GetPrimaryKeyValueAsObject(operation.Value)));
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
                string fkTargetColumn = null;

                if (null != operation.ValueMetadata)
                {
                    if ((null != operation.OwnerPropertyMetadata
                     && (operation.OwnerPropertyMetadata.HasAttribute<OneToOneAttribute>()
                         || operation.OwnerPropertyMetadata.HasAttribute<ManyToOneAttribute>()
                         || operation.OwnerPropertyMetadata.HasAttribute<ReferenceDataAttribute>())))
                    {
                        var manyToOne = operation.OwnerPropertyMetadata.GetAttribute<ManyToOneAttribute>();
                        if (manyToOne != null && manyToOne.ForeignKeyTargetColumnName != null)
                        {
                            fkTargetColumn = manyToOne.ForeignKeyTargetColumnName;
                        }
                        else
                        {
                            useKey = true;
                        }
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
                        operation.Value == null
                            ? (object) DBNull.Value
                            : new Func<object>(() => operation.ValueMetadata.GetPrimaryKeyValueAsObject(operation.Value)));
                }
                else if (fkTargetColumn != null)
                {

                    var property = operation.ValueMetadata[fkTargetColumn];
                    if (property == null)
                    {
                        throw new ArgumentException(string.Format(
                            "Cannot UPDATE foreign key relationship for non existent target column '{0}'"
                            + " specified from column '{1}' on type '{2}'.",
                            fkTargetColumn,
                            operation.OwnerPropertyMetadata.ColumnName,
                            operation.ValueMetadata.DtoType));
                    }

                    FormatWithParameter(
                        script,
                        "{0}",
                        ref paramIndex,
                        operation.Value == null
                            ? (object) DBNull.Value
                            : new Func<object>(() => property.GetValue(operation.Value)));
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
", ref paramIndex, new Func<object>(() => command.PrimaryKeyAsObject));
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

                    FormatWithParameter(script, "{0} AND ", ref paramIndex, new Func<object>(() => operation.OwnerPrimaryKeyAsObject));

                    script.Buffer.Append(string.Format("[{0}] = ", operation.ValueMetadata.PrimaryKey.Prop.Name));

                    FormatWithParameter(script, @"{0};
", ref paramIndex, new Func<object>(() => operation.ValueMetadata.GetPrimaryKeyValueAsObject(operation.Value)));
                }
                else if (operation.OwnerPropertyMetadata == null
                    || ((operation.OwnerPropertyMetadata.HasAttribute<OneToManyAttribute>()
                        || operation.OwnerPropertyMetadata.HasAttribute<OneToOneAttribute>())
                    && !operation.ValueMetadata.HasAttribute<ReferenceDataAttribute>()
                    && !operation.OwnerPropertyMetadata.HasAttribute<ReferenceDataAttribute>()))
                {
                    //  DELETE the value from the other table

                    script.Buffer.Append(string.Format(
                        @"DELETE FROM {0}
WHERE [{1}] = ",
                        operation.ValueMetadata.TableName,
                        operation.ValueMetadata.PrimaryKey.Prop.Name));
                    FormatWithParameter(script, @"{0};
", ref paramIndex, new Func<object>(() => operation.ValueMetadata.GetPrimaryKeyValueAsObject(operation.Value)));
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
            bool isPkAssignedByRdbms = true;
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
                                () => operation.OwnerPrimaryKeyAsObject),
                            new Func<object>(
                                () => operation.ValueMetadata.GetPrimaryKeyValueAsObject(operation.Value)));
                    }
                else if (operation.OwnerPropertyMetadata == null
                    || ((operation.OwnerPropertyMetadata.HasAttribute<OneToManyAttribute>()
                        || operation.OwnerPropertyMetadata.HasAttribute<OneToOneAttribute>())//IsOneToOneRelationshipWithFkOnParent(operation)) //  Because 1:1 with FK on child is like 1:N, and we already handle 1:1 with FK on parent anyway
                        && !operation.ValueMetadata.HasAttribute<ReferenceDataAttribute>()
                        && !operation.OwnerPropertyMetadata.HasAttribute<ReferenceDataAttribute>())) 
                {
                    //  INSERT the value into the table defined by ValueMetadata
                    
                    var colBuff = new StringBuilder();
                    var valBuff = new StringBuilder();
                    var values = new ArrayList();
                    var index = 0;

                    foreach (var property in operation.ValueMetadata.WriteableProperties)
                    {
                        if (property.IsPrimaryKey)
                        {
                            isPkAssignedByRdbms = !property.GetAttribute<PrimaryKeyAttribute>().IsUserAssigned;
                            if (isPkAssignedByRdbms)
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

                    if (guidPKColumn != null && isPkAssignedByRdbms)
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

            if (guidPKColumn == null && isPkAssignedByRdbms)
            {
                script.Buffer.Append(@"
SELECT SCOPE_IDENTITY();
");
            }

            return isPkAssignedByRdbms;
        }

        //  TODO: I'm wondering whether to reinstate this check purely for the purpose of validation
        //  and similarly to add one for the situation where the FK column is on the child table.
        private static bool IsOneToOneRelationshipWithFkOnParent(BaseInsertDeleteOperation operation)
        {
            if (operation.OwnerPropertyMetadata.HasAttribute<OneToOneAttribute>()
                    && operation.OwnerPropertyMetadata.HasAttribute<ForeignKeyReferenceAttribute>())
            {
                if (operation.OwnerPropertyMetadata.GetAttribute<ForeignKeyReferenceAttribute>().ReferencedDto
                    == operation.ValueMetadata.DtoType)
                {
                    return true;
                }

                throw new ArgumentException(string.Format(
                    "Invalid one to one relationship defined between parent {0} and child {1} "
                    + "on property {2} of parent. "
                    + "Parent has one to one relationship with [ForeignKeyReference] attribute "
                    + "but type specified in [ForeignKeyReference] does not match child type. "
                    + "Instead it is {3}. Change the type referenced by [ForeignKeyReference] "
                    + "or change the type of the property to match that specified in "
                    + "[ForeignKeyReference].",
                    operation.OwnerMetadata.DtoType.FullName,
                    operation.ValueMetadata.DtoType.FullName,
                    operation.OwnerPropertyMetadata.Prop.Name,
                    operation.OwnerPropertyMetadata.GetAttribute<ForeignKeyReferenceAttribute>().ReferencedDto.FullName),
                "operation");
            }
            return false;
        }

        private void AppendPropertyToInsertStatement(
            StringBuilder colBuff, StringBuilder valBuff, PropertyMetadata property,
            ref int index, BaseInsertDeleteOperation operation, ArrayList values, MethodInfo getter)
        {
            if (property.HasAttribute<ForeignKeyReferenceAttribute>()
                && null != operation.OwnerMetadata
                && _dtoMetadataCache.GetValidatedMetadataFor(
                    property.GetAttribute<ForeignKeyReferenceAttribute>().ReferencedDto).TableName ==
                operation.OwnerMetadata.TableName)
            {
                values.Add(
                    new Func<object>(() => operation.OwnerPrimaryKeyAsObject));
            }
            else if (property.HasAttribute<ManyToOneAttribute>() && property.GetAttribute<ManyToOneAttribute>().ForeignKeyTargetColumnName != null)
            {
                var propValue = property.GetValue(operation.Value);
                var propTypeMetadata = _dtoMetadataCache.GetValidatedMetadataFor(property.Prop.PropertyType);
                if (null != propValue && null != propTypeMetadata)
                {
                    var targetName = property.GetAttribute<ManyToOneAttribute>().ForeignKeyTargetColumnName;
                    var fkTargetProperty = propTypeMetadata[targetName];
                    if (fkTargetProperty == null)
                    {
                        throw new ArgumentException(string.Format(
                            "Cannot INSERT foreign key value for non existent target column '{0}'"
                            + " specified from column '{1}'.",
                            targetName,
                            property.ColumnName));
                    }

                    values.Add(new Func<object>(() => fkTargetProperty.GetValue(propValue)));
                }
                else
                {
                    values.Add(new Func<object>(() => null));
                }
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
                DtoMetadata propMetadata = _dtoMetadataCache.GetValidatedMetadataFor(property.Prop.PropertyType);
                values.Add(
                    new Func<object>(
                        () =>
                            propValue == null || propMetadata == null
                                ? null
                                : propMetadata.GetPrimaryKeyValueAsObject(propValue)));
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
            if (paramValue == null || paramValue is string || paramValue is DBNull)
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
