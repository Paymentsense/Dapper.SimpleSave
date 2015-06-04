using System;

namespace Dapper.SimpleSave
{
    public class TableAttribute : Attribute
    {
        public string Name { get; private set; }

        public TableAttribute()
        {
        }

        public TableAttribute(string name)
        {
            Name = name;
        }
    }
}
