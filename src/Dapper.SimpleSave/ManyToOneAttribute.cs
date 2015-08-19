using System;

namespace Dapper.SimpleSave
{
    public class ManyToOneAttribute : Attribute
    {
        public ManyToOneAttribute()
        {
        }

        public ManyToOneAttribute(string foreignKeyTargetColumnName)
        {
            ForeignKeyTargetColumnName = foreignKeyTargetColumnName;
        }

        public string ForeignKeyTargetColumnName { get; private set; }
    }
}
