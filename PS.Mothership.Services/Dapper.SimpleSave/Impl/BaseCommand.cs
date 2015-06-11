namespace Dapper.SimpleSave.Impl
{
    public abstract class BaseCommand
    {
        public string TableName { get; protected set; }

        public abstract int? PrimaryKey { get;}

        public string PrimaryKeyColumn { get; protected set; }
    }
}
