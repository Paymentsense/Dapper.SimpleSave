namespace PS.Mothership.Core.Common.Correlation
{
    public interface ICorrelationKeyFactory
    {
        CorrelationKey GetCorrelationKey();
    }
}