using System;

namespace Dapper.SimpleSave.Impl
{
    internal static class PrimaryKeyComparer
    {
        public static bool HaveSamePrimaryKeyValue(
            DtoMetadata dtoMetadata,
            object object1,
            object object2)
        {
            var primaryKeyPropertyMetadata = dtoMetadata.PrimaryKey;
            CheckHasPrimaryKeyProperty(dtoMetadata, primaryKeyPropertyMetadata);

            return HasSpecifiedPrimaryKeyValue(
                dtoMetadata,
                object1,
                dtoMetadata.GetPrimaryKeyValueAsObject(object2));
        }

        public static bool HasSpecifiedPrimaryKeyValue(
            DtoMetadata dtoMetadata,
            object obj,
            object expectedPrimaryKeyValue)
        {
            var primaryKeyPropertyMetadata = dtoMetadata.PrimaryKey;
            CheckHasPrimaryKeyProperty(dtoMetadata, primaryKeyPropertyMetadata);

            var objPrimaryKeyValue = dtoMetadata.GetPrimaryKeyValueAsObject(obj);

            return SuppliedPrimaryKeyValuesMatch(
                dtoMetadata,
                objPrimaryKeyValue,
                expectedPrimaryKeyValue);
        }

        public static bool SuppliedPrimaryKeyValuesMatch(
            DtoMetadata dtoMetadata,
            object primaryKeyValue1,
            object primaryKeyValue2)
        {
            var primaryKeyPropertyMetadata = dtoMetadata.PrimaryKey;
            CheckHasPrimaryKeyProperty(dtoMetadata, primaryKeyPropertyMetadata);

            var pkType = primaryKeyPropertyMetadata.Prop.PropertyType;
            if (pkType == typeof(int?) || pkType == typeof (int))
            {
                return (int?) primaryKeyValue1 == (int?) primaryKeyValue2;
            }
            
            if (pkType == typeof(long?) || pkType == typeof (long))
            {
                return (long?) primaryKeyValue1 == (long?) primaryKeyValue2;
            }

            if (pkType == typeof(Guid?) || pkType == typeof (Guid))
            {
                return (Guid?) primaryKeyValue1 == (Guid?) primaryKeyValue2;
            }

            throw CreatePrimaryKeyTypeUnsupportedException(primaryKeyPropertyMetadata);
        }

        private static void CheckHasPrimaryKeyProperty(
            DtoMetadata dtoMetadata,
            PropertyMetadata primaryKeyPropertyMetadata)
        {
            if (null == primaryKeyPropertyMetadata)
            {
                throw new ArgumentException(string.Format(
                    "Type {0} cannot be written to the database because it has no primary key defined on it. "
                    + "Add a [PrimaryKey] attribute to the property representing the primary key column. "
                    + "If no primary key is defined on the underlying database table, add a primary key first.",
                    dtoMetadata.DtoType.FullName));
            }
        }

        private static ArgumentException CreatePrimaryKeyTypeUnsupportedException(
            PropertyMetadata primaryKeyPropertyMetadata)
        {
            return new ArgumentException(string.Format(
                "Only nullable ints, longs, or GUIDs can be used as primary key properties. "
                + "Property {0} is not a valid primary key property because it is of type {1}. "
                + "Choose a property of a supported type to mark with the [PrimaryKey] attribute. "
                + "If the underlying database table has a primary key of a different type, you "
                + "must change the primary key definition.",
                primaryKeyPropertyMetadata.Prop.Name,
                primaryKeyPropertyMetadata.Prop.PropertyType.FullName));
        }
    }
}
