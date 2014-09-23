using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Exceptions
{
    [Serializable]
    public abstract class PsBaseException : ApplicationException
    {
        public PsBaseException()
            : base()
        {
            ErrorId = Guid.NewGuid();
        }

        public PsBaseException(string message) : base(message) 
        {
            ErrorId = Guid.NewGuid();
        }

        public PsBaseException(string message, Exception exception)
            : base(message, exception)
        {
            ErrorId = Guid.NewGuid();
        }

        public Guid ErrorId { get; set; }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("ErrorId", ErrorId);
        }
    }
}
