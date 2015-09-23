using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.Core.Internal;

namespace Dapper.SimpleSave.Impl
{
    public class Differ
    {
        private readonly DtoMetadataCache _dtoMetadataCache;

        public Differ(DtoMetadataCache dtoMetadataCache)
        {
            _dtoMetadataCache = dtoMetadataCache;
        }

        /// <summary>
        /// Deep diffs the two supplied objects. Either or both can be null. For <code>INSERT</code>s
        /// it's expected that <code>oldObject</code> would be <code>null</code>. Vice versa
        /// for <code>DELETE</code>s. For <code>UPDATE</code> obviously neither should be null but
        /// expect to be yelled at with an <see cref="ArgumentException"/> if the two objects in
        /// question don't represent the same row (i.e., their primary key columns have different
        /// values).
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="oldObject">Old version of object, which is expected to be <code>null</code> for
        /// <code>INSERT</code>s.</param>
        /// <param name="newObject">New version of object, which is expected to be <code>null</code> for
        /// <code>DELETE</code>s.</param>
        /// <param name="softDelete">Indicates whether any deletion at the root level should be treated
        /// as a soft delete. If so, the soft delete will be performed, and no further changes will
        /// be made.</param>
        /// <returns>List of differences between supplied objects, if any.</returns>
        public IList<Difference> Diff<T>(T oldObject, T newObject, bool softDelete = false)
        {
            return Diff(oldObject, newObject, typeof (T), softDelete);
        }

        private IList<Difference> Diff(object oldObject, object newObject, Type handleAsType, bool softDelete)
        {
            var differences = new List<Difference>();
            Diff(null, null, null, null, oldObject, newObject, handleAsType, differences, softDelete);
            return differences;
        }

        private void Diff(
            object oldOwner,
            object newOwner,
            DtoMetadata ownerMetadata,
            PropertyMetadata property,
            object oldObject,
            object newObject,
            Type handleAsType,
            IList<Difference> target,
            bool softDelete)
        {
            var metadata = _dtoMetadataCache.GetValidatedMetadataFor(handleAsType);
            var doReferenceShortcut = false;
            if (oldObject == null)
            {
                if (newObject == null)
                {
                    return;
                }

                doReferenceShortcut = true;
            }
            else if (newObject == null)
            {
                if (softDelete)
                {
                    var propertyMetaData = SoftDeleteValidator.GetValidatedSoftDeleteProperty(metadata);

                    var trueIndicatesDeleted =
                        propertyMetaData.GetAttribute<SoftDeleteColumnAttribute>().TrueIndicatesDeleted;

                    target.Add(new Difference()
                    {
                        DifferenceType = DifferenceType.Update,
                        OldValue = !trueIndicatesDeleted,
                        NewValue = trueIndicatesDeleted,
                        ValueMetadata = null,
                        OwnerMetadata = metadata,
                        OwnerPropertyMetadata = propertyMetaData,
                        OldOwner = oldObject,
                        NewOwner = oldObject
                    });
                    return;
                }
                doReferenceShortcut = true;
            }

            if (doReferenceShortcut)
            {
                DiffReferenceType(oldObject, newObject, null, target, metadata);
            }
            else
            {
                if (!PrimaryKeyComparer.HaveSamePrimaryKeyValue(metadata, oldObject, newObject))//objKey != metadata.GetPrimaryKeyValue(newObject))
                {
                    if (property == null)
                    {
                        throw new ArgumentException(string.Format(
                            "Cannot diff two objects that do not represent the same row. "
                            + "{0}: primary key does not match - for {1} does not match {2}",
                            handleAsType,
                            metadata.GetPrimaryKeyValueAsObject(oldObject),
                            metadata.GetPrimaryKeyValueAsObject(newObject)));
                    }

                    target.Add(new Difference
                    {
                        OldOwner = oldOwner,
                        NewOwner = newOwner,
                        DifferenceType = DifferenceType.Update,
                        OldValue = oldObject,
                        NewValue = newObject,
                        ValueMetadata = metadata,
                        OwnerPropertyMetadata = property,
                        OwnerMetadata = ownerMetadata,
                    });
                }
                else
                {
                    DiffProperties(metadata, oldObject, newObject, target, property);                    
                }
            }
        }

        private void DiffProperties(
            DtoMetadata metadata,
            object oldObject,
            object newObject,
            IList<Difference> target,
            PropertyMetadata parentPropertyMetadata = null)
        {
            if ((metadata.IsReferenceData && !metadata.HasUpdateableForeignKeys)
                || (parentPropertyMetadata != null
                    && parentPropertyMetadata.HasAttribute<ReferenceDataAttribute>()
                    && !parentPropertyMetadata.GetAttribute<ReferenceDataAttribute>().HasUpdateableForeignKeys))
            {
                return;
            }

            foreach (var prop in metadata.WriteableProperties)
            {
                if (metadata.IsReferenceData && !prop.HasAttribute<ForeignKeyReferenceAttribute>())
                {
                    continue;
                }

                if (parentPropertyMetadata != null
                    && parentPropertyMetadata.HasAttribute<ReferenceDataAttribute>() &&
                    !prop.HasAttribute<ForeignKeyReferenceAttribute>())
                {
                    continue;
                }

                if (prop.IsString || prop.IsNumericType || prop.IsEnum)
                {
                    DiffSimpleValue(oldObject, newObject, prop, target, metadata);
                }
                else if (prop.IsGenericDictionary)
                {
                    DiffDictionary(oldObject, newObject, prop, target, metadata);
                }
                else if (prop.IsEnumerable)
                {
                    DiffEnumerable(oldObject, newObject, prop, target, metadata);
                }
                else if (prop.IsReferenceType)
                {
                    DiffReferenceType(oldObject, newObject, prop, target, metadata);
                }
                else
                {
                    DiffSimpleValue(oldObject, newObject, prop, target, metadata);
                }
            }
        }

        private void DiffDictionary(
            object oldObject,
            object newObject,
            PropertyMetadata prop,
            IList<Difference> differences,
            DtoMetadata metadata)
        {
            var dictType = prop.Prop.PropertyType;
            var args = dictType.GetGenericArguments();
            if (args.Length != 2)
            {
                return;
            }

            var itemType = args [1];

            var values = dictType.GetProperty("Values");
            if (values == null)
            {
                return;
            }

            var getter = values.GetGetMethod();
            if (getter == null)
            {
                return;
            }

            DiffEnumerable(
                oldObject,
                newObject,
                oldObject == null ? new ArrayList() : getter.Invoke(oldObject, new object[0]),
                newObject == null ? new ArrayList() : getter.Invoke(newObject, new object[0]),
                prop,
                differences,
                metadata,
                itemType);
        }

        private void DiffEnumerable<T>(
            T oldObject,
            T newObject,
            PropertyMetadata prop,
            IList<Difference> differences,
            DtoMetadata metadata)
        {
            var itemType = GetEnumerableItemType(prop);
            if (itemType == null)
            {
                return;
            }

            var getter = prop.Prop.GetGetMethod();
            if (getter == null)
            {
                return;
            }

            DiffEnumerable(
                oldObject,
                newObject,
                oldObject == null ? new ArrayList() : getter.Invoke(oldObject, new object[0]),
                newObject == null ? new ArrayList() : getter.Invoke(newObject, new object[0]),
                prop,
                differences,
                metadata,
                itemType);
        }

        private Type GetEnumerableItemType(PropertyMetadata prop)
        {
            if (prop.Prop.PropertyType.IsConstructedGenericType)
            {
                var args = prop.Prop.PropertyType.GetGenericArguments();
                if (args.Length == 1)
                {
                    return args [0];
                }
            }
            else if (prop.Prop.PropertyType.IsArray)
            {
                return prop.Prop.PropertyType.GetElementType();
            }

            return null;
        }

        private void DiffEnumerable(
            object oldOwner,
            object newOwner,
            object oldEnumerable,
            object newEnumerable,
            PropertyMetadata prop,
            IList<Difference> differences,
            DtoMetadata metadata,
            Type itemType)
        {
            var itemTypeMeta = _dtoMetadataCache.GetMetadataFor(itemType);
            var pk = itemTypeMeta.PrimaryKey;
            if (pk == null)
            {
                return;
            }

            DtoMetadataValidator.ValidateAsCompatibleTable(itemTypeMeta);

            var oldItems = GetItemDictionary(oldEnumerable as IEnumerable, pk);
            var newItems = GetItemDictionary(newEnumerable as IEnumerable, pk);

            //  We clear this because if an old item has no PK value then it's
            //  clearly never been saved to the database in the first place, so we
            //  don't want to write SQL to UPDATE or DELETE it. If it exists in
            //  the new items collection, on the other hand, we want to INSERT it.
            oldItems.ItemsWithNoPkValue.Clear();
            AddDifferencesForItemsInOnlyOneCollection(
                oldOwner, newOwner, metadata, prop, oldItems,
                newItems, itemTypeMeta, DifferenceType.Deletion, differences);
            
            AddDifferencesForItemsInOnlyOneCollection(
                oldOwner, newOwner, metadata, prop, newItems,
                oldItems, itemTypeMeta, DifferenceType.Insertion, differences);

            AddDifferencesForChangedItems(oldItems, newItems, itemType, differences);
        }

        private void AddDifferencesForItemsInOnlyOneCollection(
            object oldOwner,
            object newOwner,
            DtoMetadata metadata,
            PropertyMetadata prop,
            ItemLookup items1,
            ItemLookup items2,
            DtoMetadata itemTypeMeta,
            DifferenceType differenceType,
            IList<Difference> differences)
        {
            var removed = FindRemovedItems(items1, items2);

            Action<object> addDifference = item => differences.Add(new Difference
            {
                OldOwner = oldOwner,
                NewOwner = newOwner,
                DifferenceType = differenceType,
                OwnerPropertyMetadata = prop,
                OwnerMetadata = metadata,
                ValueMetadata = itemTypeMeta,
                NewValue = DifferenceType.Insertion == differenceType ? item : null,
                OldValue = DifferenceType.Deletion == differenceType ? item : null
            });

            foreach (var item in removed.ItemsById.Values)
            {
                addDifference(item);
            }

            foreach (var item in removed.ItemsWithNoPkValue)
            {
                addDifference(item);
            }
        }

        private ItemLookup GetItemDictionary(IEnumerable enumerable, PropertyMetadata pkProp)
        {
            var results = new ItemLookup();
            if (enumerable != null)
            {
                var getter = pkProp.Prop.GetGetMethod();
                foreach (var item in enumerable)
                {
                    var pk = getter.Invoke(item, new object[0]);
                    if (pk == null)
                    {
                        results.ItemsWithNoPkValue.Add(item);
                    }
                    else
                    {
                        results.ItemsById[pk] = item;
                    }
                }
            }
            return results;
        }

        private class ItemLookup
        {

            public ItemLookup()
            {
                ItemsById = new Dictionary<object, object>();
                ItemsWithNoPkValue = new List<object>();
            }

            public IDictionary<object, object> ItemsById { get; private set; }
            public IList<object> ItemsWithNoPkValue { get; private set; } 
        }

        private ItemLookup FindRemovedItems(
            ItemLookup lookup1,
            ItemLookup lookup2)
        {
            if (lookup1 == null)
            {
                return new ItemLookup();
            }

            if (lookup2 == null)
            {
                return lookup1;
            }

            var results = new ItemLookup();
            foreach (var key in lookup1.ItemsById.Keys.Where(key => !lookup2.ItemsById.ContainsKey(key)))
            {
                results.ItemsById[key] = lookup1.ItemsById[key];
            }

            lookup1.ItemsWithNoPkValue.ForEach(item => results.ItemsWithNoPkValue.Add(item));
            return results;
        }

        private void AddDifferencesForChangedItems(
            ItemLookup oldItems,
            ItemLookup newItems,
            Type handleAsType,
            IList<Difference> differences)
        {
            foreach (var key in oldItems.ItemsById.Keys)
            {
                if (newItems.ItemsById.ContainsKey(key))
                {
                    foreach (var diff in Diff(oldItems.ItemsById[key], newItems.ItemsById[key], handleAsType, false))
                    {
                        differences.Add(diff);
                    }
                }
            }
        }

        private void DiffReferenceType<T>(
            T oldObject,
            T newObject,
            PropertyMetadata prop,
            IList<Difference> differences,
            DtoMetadata metadata)
        {
            MethodInfo getter = null;

           if (null != prop)
           {
               getter = prop.Prop.GetGetMethod();
               if (getter == null)
               {
                   return;
               }
           }
           
           var oldPropValue = GetPropertyValueFrom(oldObject, getter);
           var newPropValue = GetPropertyValueFrom(newObject, getter);

           if (oldPropValue == null)
           {
               if (newPropValue == null)
               {
                   return;
               }

               differences.Add(new Difference
               {
                   OldOwner = oldObject,
                   NewOwner = ReferenceEquals(newObject, newPropValue)
                       ? (object) null
                       : newObject,
                   DifferenceType = DifferenceType.Insertion,
                   OwnerPropertyMetadata = prop,
                   OwnerMetadata = prop == null ? null : metadata,
                   ValueMetadata = prop == null
                       ? metadata
                       : _dtoMetadataCache.GetMetadataFor(prop.Prop.PropertyType),
                   OldValue = null,
                   NewValue = newPropValue
               });

               DiffProperties(
                   ReferenceEquals(newObject, newPropValue)
                       ? metadata
                       : _dtoMetadataCache.GetMetadataFor(prop.Prop.PropertyType),
                   ReferenceEquals(newObject, newPropValue)
                       ? oldObject
                       : oldPropValue,
                   ReferenceEquals(newObject, newPropValue)
                       ? newObject
                       : newPropValue,
                   differences,
                   prop);
           }
           else if (newPropValue == null)
           {
               DiffProperties(
                   ReferenceEquals(oldObject, oldPropValue)
                       ? metadata :
                       _dtoMetadataCache.GetMetadataFor(prop.Prop.PropertyType),
                   ReferenceEquals(oldObject, oldPropValue)
                       ? oldObject
                       : oldPropValue,
                   newPropValue,
                   differences,
                   prop);

               differences.Add(new Difference
               {
                   OldOwner = ReferenceEquals(oldObject, oldPropValue)
                       ? (object) null
                       : oldObject,
                   NewOwner = newObject,
                   DifferenceType = DifferenceType.Deletion,
                   OwnerPropertyMetadata = prop,
                   OwnerMetadata = prop == null ? null : metadata,
                   ValueMetadata = prop == null
                       ? metadata
                       : _dtoMetadataCache.GetMetadataFor(prop.Prop.PropertyType),
                   OldValue = oldPropValue,
                   NewValue = null
               });
           }
           else
           {
               Diff(
                   ReferenceEquals(oldObject, oldPropValue) ? (object) null : oldObject,
                   ReferenceEquals(newObject, newPropValue) ? (object) null : newObject,
                   metadata,
                   prop,
                   oldPropValue,
                   newPropValue,
                   prop.Prop.PropertyType,
                   differences,
                   false);
           }
        }

        private static object GetPropertyValueFrom<T>(T oldObject, MethodInfo getter)
        {
            return oldObject == null
                ? null
                : getter == null ? oldObject : getter.Invoke(oldObject, new object[0]);
        }

        private void DiffSimpleValue<T>(
            T oldObject,
            T newObject,
            PropertyMetadata prop,
            IList<Difference> differences,
            DtoMetadata metadata)
        {
            if (oldObject == null || newObject == null)
            {
                //  Don't need to diff simple values where an object has been created or deleted.
                return;
            }

            var oldValue = prop.GetValue(oldObject);
            var newValue = prop.GetValue(newObject);

            if (AreEqual(oldValue, newValue))
            {
                return;
            }

            differences.Add(new Difference
            {
                OldOwner = oldObject,
                NewOwner = newObject,
                OwnerPropertyMetadata = prop,
                DifferenceType = DifferenceType.Update,
                OwnerMetadata = metadata,
                NewValue = newValue,
                OldValue = oldValue
            });
        }

        private static bool AreEqual(object value1, object value2)
        {
            if (value1 == value2)
            {
                return true;
            }
            
            if (value1 == null || value2 == null)
            {
                return false;
            }

            return value1.Equals(value2);
        }
    }
}