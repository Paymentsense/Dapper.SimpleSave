using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Dapper.SimpleSave.Impl
{
    public class PropertyMetadata : BaseMetadata
    {

        public PropertyInfo Prop { get; set; }

        public PropertyMetadata(PropertyInfo prop) : base(prop)
        {
            Prop = prop;
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
    }
}