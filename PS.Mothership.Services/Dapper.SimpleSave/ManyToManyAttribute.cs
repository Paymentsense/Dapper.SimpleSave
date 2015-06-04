using System;

namespace Dapper.SimpleSave
{
    public class ManyToManyAttribute : Attribute
    {
        public string LinkTableName { get; private set; }

        public ManyToManyAttribute(string linkTableName)
        {
            LinkTableName = linkTableName;
        }
    }
}
