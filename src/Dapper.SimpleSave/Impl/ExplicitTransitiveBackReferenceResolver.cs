using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Impl
{
    public class ExplicitTransitiveBackReferenceResolver
    {
        private readonly DtoMetadataCache _cache;

        public ExplicitTransitiveBackReferenceResolver(DtoMetadataCache cache)
        {
            _cache = cache;
        }

        public void Resolve(object rootObject)
        {
            var ancestors = new List<Tuple<object, DtoMetadata>>();
            var ancestorsFastLookup = new HashSet<object>();

            Resolve(rootObject, ancestors, ancestorsFastLookup);
        }

        private void Resolve(object obj, IList<Tuple<object, DtoMetadata>> ancestors, ISet<object> ancestorsFastLookup)
        {
            if (obj == null || obj is string || ancestorsFastLookup.Contains(obj))
            {
                return;
            }

            var metadata = _cache.GetMetadataFor(obj.GetType());
            if (metadata == null)
            {
                return;
            }

            var refData = metadata.GetAttribute<ReferenceDataAttribute>();
            if (refData != null && !refData.HasUpdateableForeignKeys)
            {
                return;
            }

            ancestors.Add(new Tuple<object, DtoMetadata>(obj, metadata));
            ancestorsFastLookup.Add(obj);
            foreach (var property in metadata.WriteableProperties)
            {
                if (property.HasAttribute<SimpleSaveIgnoreAttribute>() || property.HasAttribute<DoNotAutoWireExplicitTransitiveBackReferenceAttribute>())
                {
                    continue;
                }

                refData = property.GetAttribute<ReferenceDataAttribute>();
                if (refData != null && !refData.HasUpdateableForeignKeys)
                {
                    continue;
                }

                var fkAttribute = property.GetAttribute<ForeignKeyReferenceAttribute>();
                var drill = true;
                if (fkAttribute != null)
                {
                    var propertyType = property.Prop.PropertyType;
                    if (propertyType.IsValueType)
                    {
                        AssignAnyMismatchedExplicitTransitiveForeignKeyValues(obj, ancestors, fkAttribute, propertyType, property);
                        drill = false;
                    }
                }
                else if (property.IsValueType || property.IsString)
                {
                    drill = false;
                }

                if (drill)
                {
                    if (property.IsEnumerable)
                    {
                        var children = property.GetValue(obj) as IEnumerable;
                        if (children != null)
                        {
                            foreach (var child in children)
                            {
                                Resolve(child, ancestors, ancestorsFastLookup);
                            }
                        }
                    }
                    else
                    {
                        Resolve(property.GetValue(obj), ancestors, ancestorsFastLookup);
                    }
                }
            }

            ancestors.RemoveAt(ancestors.Count - 1);
            ancestorsFastLookup.Remove(obj);
        }

        private static void AssignAnyMismatchedExplicitTransitiveForeignKeyValues(object obj, IList<Tuple<object, DtoMetadata>> ancestors,
            ForeignKeyReferenceAttribute fkAttribute, Type propertyType, PropertyMetadata property)
        {
            var targetObjectType = fkAttribute.ReferencedDto;

            //  We don't look at the immediate ancestor because such links should already
            //  have been wired up; we're only looking for possible target types further
            //  back up the chain of ancestors.
            if (ancestors.Count > 2)
            {
                for (var index = ancestors.Count - 3; index >= 0; --index)
                {
                    var ancestor = ancestors[index];
                    var ancestorMetadata = ancestor.Item2;
                    if (ancestorMetadata.DtoType != targetObjectType)
                    {
                        continue;
                    }

                    var ancestorPkColumn = ancestorMetadata.PrimaryKey;
                    if (ancestorPkColumn == null)
                    {
                        //  There's nothing we can assign to the foreign key value for any
                        //  ancestor of the expected type.
                        break;
                    }

                    if (!propertyType.IsAssignableFrom(ancestorPkColumn.Prop.PropertyType))
                    {
                        continue;
                    }

                    var pkValue = ancestorMetadata.GetPrimaryKeyValueAsObject(ancestor);
                    var fkValue = property.Prop.GetValue(obj);

                    if (pkValue != fkValue
                        && (pkValue == null || fkValue == null || !pkValue.Equals(fkValue)))
                    {
                        property.SetValue(obj, pkValue);
                    }
                }
            }
        }
    }
}
