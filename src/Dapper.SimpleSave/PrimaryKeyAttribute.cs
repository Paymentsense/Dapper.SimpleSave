using System;

namespace Dapper.SimpleSave
{
    public class PrimaryKeyAttribute : Attribute
    {
        public PrimaryKeyAttribute() : this(false)
        {
        }

        public PrimaryKeyAttribute(bool isUserAssigned)
        {
            IsUserAssigned = isUserAssigned;
        }

        public bool IsUserAssigned { get; private set; }
    }
}
