namespace Dapper.SimpleSave
{
    public interface ISimpleSaveLogger
    {
        void LogBuilt(IScript script);
        void LogPreExecution(IScript script);
        void LogPostExecution(IScript script);
    }
}
