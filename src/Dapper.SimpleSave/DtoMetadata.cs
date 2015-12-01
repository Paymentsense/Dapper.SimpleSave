using System;
using System.Collections.Generic;
using System.Reflection;
using Dapper.SimpleSave.Impl;
using log4net;

namespace Dapper.SimpleSave
{
    public class DtoMetadata : BaseMetadata
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(DtoMetadata));

        private IDictionary<string, PropertyMetadata> _propertiesByCaseInsensitiveColumnName = new Dictionary<string, PropertyMetadata>(StringComparer.CurrentCultureIgnoreCase);

        public DtoMetadata(Type type) : base(type)
        {
            DtoType = type;
            InitProperties();
            InitTableName();
        }

        public Type DtoType { get; set; }

        public string TableName { get; private set; }

        public bool IsReferenceData
        {
            get { return GetAttribute<ReferenceDataAttribute>() != null; }
        }

        public bool HasUpdateableForeignKeys
        {
            get
            {
                return IsReferenceData
                    && GetAttribute<ReferenceDataAttribute>().HasUpdateableForeignKeys;
            }
        }

        public PropertyMetadata PrimaryKey { get; set; }

        public IEnumerable<PropertyMetadata> WriteableProperties { get; set; }

        public IEnumerable<PropertyMetadata> AllProperties { get; set; } 

        public PropertyMetadata this[string propertyColumnNameCaseInsensitive]
        {
            get
            {
                PropertyMetadata property;
                _propertiesByCaseInsensitiveColumnName.TryGetValue(propertyColumnNameCaseInsensitive, out property);
                return property;
            }
        }

        public PropertyMetadata GetForeignKeyColumnFor(Type dtoType)
        {
            foreach (var property in WriteableProperties)
            {
                var fk = property.GetAttribute<ForeignKeyReferenceAttribute>();
                if (null != fk && fk.ReferencedDto == dtoType)
                {
                    return property;
                }
            }
            return null;
        }

        public object GetPrimaryKeyValueAsObject(object obj)
        {
            return obj is Enum ? (int) obj : PrimaryKey.GetValue(obj);
        }

        public int? GetPrimaryKeyValueAsInt(object obj)
        {
            return obj is Enum ? (int) obj : (int?) PrimaryKey.GetValue(obj);
        }

        public long? GetPrimaryKeyValueAsLong(object obj)
        {
            return obj is Enum ? (long) obj : (long?) PrimaryKey.GetValue(obj);
        }

        public Guid? GetPrimaryKeyValueAsGuid(object obj)
        {
            return (Guid?) PrimaryKey.GetValue(obj);
        }

        public void SetPrimaryKey(object obj, object value)
        {
            PrimaryKey.SetValue(obj, value);
        }

        public bool HasSoftDeleteSupport { get { return SoftDeleteProperty != null; } }

        public PropertyMetadata SoftDeleteProperty { get; private set; }

        private void InitProperties()
        {
            IList<PropertyMetadata> writeable = new List<PropertyMetadata>();
            var all = new List<PropertyMetadata>();
            foreach (var prop in DtoType.GetProperties(
                BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance))
            {
                var propMeta = new PropertyMetadata(prop);
                all.Add(propMeta);
                _propertiesByCaseInsensitiveColumnName[propMeta.ColumnName] = propMeta;

                if (!propMeta.IsSaveable)
                {
                    continue;
                }

                if (propMeta.IsPrimaryKey)
                {
                    PrimaryKey = propMeta;
                }

                if (propMeta.HasAttribute<SoftDeleteColumnAttribute>())
                {
                    SoftDeleteProperty = propMeta;
                }

                writeable.Add(propMeta);
            }

            writeable = DeduplicateWriteableProperties(writeable);
            WriteableProperties = writeable;
            AllProperties = all;
        }

        private IList<PropertyMetadata> DeduplicateWriteableProperties(IList<PropertyMetadata> source)
        {
            var byName = new Dictionary<string, PropertyMetadata>();
            for (var index = source.Count - 1; index >= 0; --index)
            {
                var metadata = source[index];
                var name = metadata.ColumnName;
                if (byName.ContainsKey(name))
                {
                    var stored = byName[name];
                    var storedDeclaringType = stored.Prop.DeclaringType;
                    var myDeclaringType = metadata.Prop.DeclaringType;
                    if (storedDeclaringType != myDeclaringType)
                    {
                        if (storedDeclaringType.IsAssignableFrom(myDeclaringType))
                        {
                            //  Stored type is the base class; let's replace the property,
                            //  and warn.
                            byName[name] = metadata;
                            FireWarningOrExceptionOnDuplicate(string.Format(
                                "Types {0} and {1} both contain properties mapped to column '{2}'. Properties "
                                + "are '{3}' and '{4}' respectively. SimpleSave will use the most specific "
                                + "definition: {1}.{4}",
                                storedDeclaringType,
                                myDeclaringType,
                                name,
                                stored.Prop.Name,
                                metadata.Prop.Name));
                        }
                        else if (myDeclaringType.IsAssignableFrom(storedDeclaringType))
                        {
                            //  We've already stored the subclass, but we've found a duplicate
                            //  (duplicate is the base class), so let's log a warning.
                            FireWarningOrExceptionOnDuplicate(string.Format(
                                "Types {0} and {1} both contain properties mapped to column '{2}'. Properties "
                                + "are '{3}' and '{4}' respectively. SimpleSave will use the most specific "
                                + "definition: {1}.{4}",
                                myDeclaringType,
                                storedDeclaringType,
                                name,
                                metadata.Prop.Name,
                                stored.Prop.Name));
                        }
                        else
                        {
                            //  This is a weird situation that might occur with interface inheritance, or if
                            //  two completely different properties have been mapped to the same column. Again,
                            //  let's just warn. Really we're just picking one of the properties at random here
                            //  (i.e., the first one we run into, and the order isn't guaranteed).
                            FireWarningOrExceptionOnDuplicate(string.Format(
                                "Types {0} and {1} both contain properties mapped to column '{2}'. Properties "
                                + "are '{3}' and '{4}' respectively. SimpleSave will use: {1}.{4}",
                                myDeclaringType,
                                storedDeclaringType,
                                name,
                                metadata.Prop.Name,
                                stored.Prop.Name));
                        }
                    }
                    else
                    {
                        //  Very much belt and braces - same property, same declaring type, but why's
                        //  it duplicated?
                        source.RemoveAt(index);
                    }
                }
                else
                {
                    byName.Add(name, metadata);
                }
            }

            //  We do all this because I don't want to reorder the properties in the source collection.
            var deduped = new HashSet<PropertyMetadata>(byName.Values);
            for (var index = source.Count - 1; index >= 0; --index)
            {
                if (!deduped.Contains(source[index]))
                {
                    source.RemoveAt(index);
                }
            }

            return source;
        }

        private static void FireWarningOrExceptionOnDuplicate(string message)
        {
            message += " You should either [SimpleSaveIgnore], or remove, one of the properties.";

            if (SimpleSaveExtensions.ThrowOnMultipleWriteablePropertiesAgainstSameColumn)
            {
                throw new InvalidOperationException(message);
            }
            else if (Logger.IsWarnEnabled)
            {
                message += " If you don't, unexpected or undesirable behaviour may result. For example, "
                        + "if the values of these two properties are different, only one will be saved to "
                        + "the database. You should not rely on which one it will be.";
                Logger.Warn(message);
            }
        }

        private void InitTableName()
        {
            var attr = GetAttribute<TableAttribute>();
            var name = attr == null ? null : attr.SchemaQualifiedTableName;
            //if (name == null)
            //{
            //    //  TODO: generate names for enums and DTOs without any name specified
            //    //  Hmm... looks like possibly we may not need this.
            //}
            TableName = name;
        }
    }
}
