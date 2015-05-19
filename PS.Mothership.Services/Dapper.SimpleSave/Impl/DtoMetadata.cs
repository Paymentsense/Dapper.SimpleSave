using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Impl {
    public class DtoMetadata
    {
        public DtoMetadata(Type type)
        {
            DtoType = type;
            InitProperties();
        }

        public Type DtoType { get; set; }

        public string TableName { get; set; }
        public PropertyMetadata PrimaryKey { get; set; }
        public IEnumerable<PropertyMetadata> Properties { get; set; }

        public int GetPrimaryKeyValue(object obj)
        {
            return (int) PrimaryKey.GetValue(obj);
        }

        private void InitProperties()
        {
            var target = new List<PropertyMetadata>();
            foreach (var prop in DtoType.GetProperties(
                BindingFlags.FlattenHierarchy | BindingFlags.Public)) {
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
    }
}
