using System;

namespace PS.Mothership.Core.Common.Exceptions
{
    /// <summary>
    /// Use this class so we 
    /// </summary>
    public class CriticalException : PsBaseException
    {        
            public CriticalException()
                : base()
            {
                ErrorId = Guid.NewGuid();
            }

            public CriticalException(string message) : base(message) 
            {
                ErrorId = Guid.NewGuid();
            }

            public CriticalException(string message, Exception exception)
                : base(message, exception)
            {
                ErrorId = Guid.NewGuid();
            }
    }
}
