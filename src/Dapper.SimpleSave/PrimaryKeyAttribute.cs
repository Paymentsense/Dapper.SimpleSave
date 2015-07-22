using System;

namespace Dapper.SimpleSave
{
    public class PrimaryKeyAttribute : Attribute
    {
        public PrimaryKeyAttribute() : this(true)
        {
        }

        public PrimaryKeyAttribute(bool autoAssignedByRdbms)
        {
            AutoAssignedByRdbms = autoAssignedByRdbms;
        }

        public bool AutoAssignedByRdbms { get; private set; }
    }
}
