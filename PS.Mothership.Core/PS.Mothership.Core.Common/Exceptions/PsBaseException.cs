using System;

namespace PS.Mothership.Core.Common.Exceptions
{
	public abstract class PsBaseException : ApplicationException
	{
		public PsBaseException()
			: base()
		{
			ErrorId = Guid.NewGuid();
		}

		public PsBaseException(string message)
			: base(message)
		{
			ErrorId = Guid.NewGuid();
		}

		public PsBaseException(string message, Exception exception)
			: base(message, exception)
		{
			ErrorId = Guid.NewGuid();
		}

		public Guid ErrorId { get; set; }
	}
}
