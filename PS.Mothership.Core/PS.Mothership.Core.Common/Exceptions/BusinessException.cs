using System;

namespace PS.Mothership.Core.Common.Exceptions
{
    [Serializable]
    public class BusinessException : PsBaseException
    {
        public BusinessException()
            : base()
        {
            ErrorId = Guid.NewGuid();
        }

        public BusinessException(string message) : base(message) 
        {
            ErrorId = Guid.NewGuid();
        }

        public BusinessException(string message, Exception exception)
            : base(message, exception)
        {
            ErrorId = Guid.NewGuid();
        }
    }
}
