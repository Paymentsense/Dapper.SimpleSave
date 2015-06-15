namespace Dapper.SimpleSave.Impl {
    /// <summary>
    /// Represents a SQL <code>INSERT</code> command that inserts a single
    /// row of data into a table.
    /// </summary>
    public class InsertCommand : BaseInsertDeleteCommand
    {
        public InsertCommand(InsertOperation operation) : base(operation)
        {
        }
    }
}
