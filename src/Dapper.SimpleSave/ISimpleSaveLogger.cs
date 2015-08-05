namespace Dapper.SimpleSave
{
    public interface ISimpleSaveLogger
    {
        void LogPreExecution(IScript script);
        void LogPostExecution(IScript script);
    }
}
