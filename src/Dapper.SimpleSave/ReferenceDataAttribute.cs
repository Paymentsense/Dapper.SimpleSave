using System;

namespace Dapper.SimpleSave
{
    public class ReferenceDataAttribute : Attribute
    {
        public ReferenceDataAttribute()
        {
        }

        public ReferenceDataAttribute(bool hasUpdateableForeignKeys)
        {
            HasUpdateableForeignKeys = hasUpdateableForeignKeys;
        }

        public bool HasUpdateableForeignKeys { get; private set; }
    }
}
