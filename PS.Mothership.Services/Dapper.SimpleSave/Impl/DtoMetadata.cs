using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Impl {
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
            get { return IsReferenceData && GetAttribute<ReferenceDataAttribute>().HasUpdateableForeignKeys;  }
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

        public int? GetPrimaryKeyValue(object obj)
        {
            return obj is Enum ? (int) obj : (int?) PrimaryKey.GetValue(obj);
        }

        public void SetPrimaryKey(object obj, int? value)
        {
            PrimaryKey.SetValue(obj, value);
        }

        private void InitProperties()
        {
            var target = new List<PropertyMetadata>();
            foreach (var prop in DtoType.GetProperties(
                BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance)) {
                var propMeta = new PropertyMetadata(prop);
                if (!propMeta.IsSaveable)
                {
                    continue;
                }

                if (propMeta.IsPrimaryKey)
                {
                    PrimaryKey = propMeta;
                }

                target.Add(propMeta);
            }

            Properties = target;
        }

        private void InitTableName()
        {
            var attr = GetAttribute<TableAttribute>();
            var name = null == attr ? null : attr.Name;
            if (null == name)
            {
                //  TODO: generate names for enums and DTOs without any name specified
            }
            TableName = name;
        }

    }
}
