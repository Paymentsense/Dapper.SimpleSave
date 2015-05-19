namespace Dapper.SimpleSave.Impl
{
    public class UpdateOperation
    {
        public string TableName { get; set; }

        public string PrimaryKeyColumn { get; set; }

        public int PrimaryKey { get; set; }

        public string ColumnName { get; set; }

        public object Value { get; set; }
    }
}