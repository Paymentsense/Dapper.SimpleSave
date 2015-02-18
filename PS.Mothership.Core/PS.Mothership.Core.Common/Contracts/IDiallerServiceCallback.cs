using System;

namespace PS.Mothership.Core.Common.Contracts
{
    public interface IDiallerServiceCallback
    {
        bool CheckUserAvailability(Guid userGuid);
    }
}
