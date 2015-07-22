using System;

namespace Dapper.SimpleSave.Impl
{
    public abstract class BaseCommand
    {
        public string TableName { get; protected set; }

        public string PrimaryKeyColumn { get; protected set; }
    }
}
