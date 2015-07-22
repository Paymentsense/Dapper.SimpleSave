using System;

namespace Dapper.SimpleSave.Impl
{
    public static class DtoMetadataValidator
    {
        public static void ValidateAsCompatibleTable(DtoMetadata metadata)
        {
            if (metadata.TableName == null)
            {
                throw new ArgumentException(
                    string.Format(
                        "Type {0} is not marked with a [Table] attribute. You must mark it with "
                        + "[Table(\"[schema].[tableName]\")] to use it with Dapper.SimpleSave.",
                        metadata.DtoType.FullName),
                    "type");
            }

            if (metadata.DtoType.IsEnum)
            {
                return;
            }

            var pkMetadata = metadata.PrimaryKey;
            if (null == pkMetadata)
            {
                throw new ArgumentException(
                    string.Format(
                        "Type {0} does not have a property marked with a [PrimaryKey] attribute. You "
                        + "must mark a property of type int?, long? or Guid? with a [PrimaryKey] attribute.",
                        metadata.DtoType.FullName),
                    "type");
            }

            var pkType = pkMetadata.Prop.PropertyType;
            if (pkType != typeof (int?) && pkType != typeof (long?) && pkType != typeof (Guid?))
            {
                throw new ArgumentException(
                    string.Format(
                        "Primary key properties must be of type int?, long? or Guid? but {0} on {1} "
                        + "is of type {2}. Either change the type of the property or use a different "
                        + "property as the primary key.",
                        pkMetadata.Prop.Name,
                        metadata.DtoType.FullName,
                        pkType.FullName),
                    "type");
            }

            if (pkMetadata.IsReadOnly)
            {
                throw new ArgumentException(
                    string.Format(
                        "Primary key properties must be read-write but {0} on {1} is read-only. "
                        + "Make the property read-write or choose a different primary key property.",
                        pkMetadata.Prop.Name,
                        metadata.DtoType.FullName));
            }
        }
    }
}
