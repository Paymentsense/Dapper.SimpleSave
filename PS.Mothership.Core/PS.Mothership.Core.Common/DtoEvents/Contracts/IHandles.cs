using System.ServiceModel;
using PS.Mothership.Core.Common.Dto;

namespace PS.Mothership.Core.Common.Contracts
{
    public interface IHandles<in T> where T : IDtoEvent
    {
        void Handle(T args);
    }
}