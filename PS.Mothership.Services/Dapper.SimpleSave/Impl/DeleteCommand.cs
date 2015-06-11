namespace Dapper.SimpleSave.Impl {
    /// <summary>
    /// Represents a SQL <code>DELETE</code> command that deletes a single
    /// row of data from a table.
    /// </summary>
    public class DeleteCommand : BaseInsertDeleteCommand
    {
        public DeleteCommand(DeleteOperation operation) : base(operation)
        {
        }
    }
}
