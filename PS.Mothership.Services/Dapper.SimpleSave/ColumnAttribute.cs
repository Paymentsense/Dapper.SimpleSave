using System;

namespace Dapper.SimpleSave
{
    public class ColumnAttribute : Attribute
    {
        public string Name { get; private set; }
        public ColumnAttribute(string name)
        {
            Name = name;
        }
    }
}
