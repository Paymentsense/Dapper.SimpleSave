using System;

namespace Dapper.SimpleSave.Impl
{
    public static class SoftDeleteValidator
    {
        public static PropertyMetadata GetValidatedSoftDeleteProperty(DtoMetadata metadata)
        {
            if (metadata == null)
            {
                throw new ArgumentNullException(
                    "metadata",
                    "Cannot retrieve soft delete marker property for null type metadata.");
            }

            if (!metadata.HasSoftDeleteSupport)
            {
                throw new ArgumentException(
                    string.Format(
                        "Cannot soft delete object of type {0} because the type does not support "
                        + "soft deletion. To support soft deletion add the [SoftDeleteColumn] "
                        + "attribute to a boolean property that indicates whether or not the row "
                        + "corresponding to the object has been soft deleted from the database. "
                        + "You can use either true or false to indicate deletion, depending on "
                        + "value of the optional parameter you supply to [SoftDeleteColumn]. If "
                        + "no value is supplied the default is that false indicates the row has "
                        + "been soft deleted."),
                    "metadata");
            }

            var propertyMetadata = metadata.SoftDeleteProperty;

            if (propertyMetadata.IsReadOnly)
            {
                throw new ArgumentException(
                    string.Format(
                        "Cannot soft delete object of type {0} because the soft delete marker property {1} is not writeable.",
                        metadata.DtoType.FullName,
                        propertyMetadata.Prop.Name),
                    "metadata");
            }

            if (propertyMetadata.Prop.PropertyType != typeof (bool))
            {
                throw new ArgumentException(
                    string.Format(
                        "Cannot soft delete object of type {0} because the soft delete marker "
                        + "property {1} is of type {2}. This property can only be of type bool. "
                        + "Either change the property type or choose a different property as the "
                        + "soft delete marker.",
                        metadata.DtoType.FullName,
                        propertyMetadata.Prop.Name,
                        propertyMetadata.Prop.PropertyType.FullName),
                    "metadata");
            }

            return propertyMetadata;
        }
    }
}
