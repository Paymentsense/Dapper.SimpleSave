namespace Dapper.SimpleSave.Impl
{
    /// <summary>
    /// Represents an update operation to carry out on a single column in a table. Multiple
    /// such operations may be coalesced together into a single <see cref="UpdateCommand"/>,
    /// which results in the generation of a single <code>UPDATE</code> SQL statement
    /// that updates multiple columns.
    /// </summary>
    public class UpdateOperation : BaseOperation
    {
        public string ColumnName { get; set; }

    }
}