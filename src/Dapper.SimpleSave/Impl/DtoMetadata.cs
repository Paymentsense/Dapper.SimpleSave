﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace Dapper.SimpleSave.Impl
{
    public class DtoMetadata : BaseMetadata
    {
        public DtoMetadata(Type type) : base(type)
        {
            DtoType = type;
            InitProperties();
            InitTableName();
        }

        public Type DtoType { get; set; }

        public string TableName { get; set; }

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

        public IEnumerable<PropertyMetadata> Properties { get; set; }

        public PropertyMetadata GetForeignKeyColumnFor(Type dtoType)
        {
            foreach (var property in Properties)
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
            var target = new List<PropertyMetadata>();
            foreach (var prop in DtoType.GetProperties(
                BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance))
            {
                var propMeta = new PropertyMetadata(prop);
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

                target.Add(propMeta);
            }

            Properties = target;
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