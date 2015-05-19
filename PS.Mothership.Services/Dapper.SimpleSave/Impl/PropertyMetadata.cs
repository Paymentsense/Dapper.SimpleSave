using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Dapper.SimpleSave.Impl
{
    public class PropertyMetadata
    {

        private IDictionary<Type, Attribute> _attributes = new Dictionary<Type, Attribute>(); 

        public PropertyInfo Prop { get; set; }

        public PropertyMetadata(PropertyInfo prop)
        {
            Prop = prop;
            InitAttributes();
        }

        public bool HasAttribute<T>()
        {
            return _attributes.ContainsKey(typeof (T));
        }

        public Attribute GetAttribute<T>()
        {
            Attribute attr;
            _attributes.TryGetValue(typeof (T), out attr);
            return attr;
        }

        public bool IsPrimaryKey
        {
            get { return HasAttribute<PrimaryKeyAttribute>();}
        }

        public bool IsManyToManyRelationship
        {
            get {  return HasAttribute<ManyToManyAttribute>(); }
        }

        public bool IsReadOnly
        {
            get { return HasAttribute<ReadOnlyAttribute>() || ! Prop.CanWrite;}
        }

        public bool IsPublic
        {
            get { return Prop.GetGetMethod().IsPublic; }
        }

        public bool IsSaveable
        {
            get { return !IsReadOnly && IsPublic; }
        }

        public object GetValue(object source)
        {
            return Prop.GetGetMethod().Invoke(source, new object[0]);
        }

        private void InitAttributes()
        {
            foreach (var attr in Prop.GetCustomAttributes(true).OfType<Attribute>())
            {
                _attributes [attr.GetType()] = attr;
            }
        }
    }
}