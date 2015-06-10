using System;

namespace Dapper.SimpleSave
{
    public class TableAttribute : Attribute
    {
        public string SchemaQualifiedTableName { get; private set; }

        public TableAttribute()
        {
        }

        public TableAttribute(string schemaQualifiedTableName)
        {
            SchemaQualifiedTableName = schemaQualifiedTableName;
        }
    }
}
