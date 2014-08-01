namespace PS.Mothership.Core.Common.Contracts
{
    public interface ISearchService
    {
        TOutput QuickSearch<TInput, TOutput>(TInput searchInput);
    }
}
