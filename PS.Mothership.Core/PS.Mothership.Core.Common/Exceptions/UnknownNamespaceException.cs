﻿using System;

namespace PS.Mothership.Core.Common.Exceptions
{
    public class UnknownNamespaceException : PsBaseException
    {
        private const string ExceptionMessage = "The namespace of the object could not be determined when attempting to get it via the object's type.";

        public UnknownNamespaceException()
            : base(ExceptionMessage)
        {

        }

        public UnknownNamespaceException(string message)
            : base(message)
        {
            ErrorId = Guid.NewGuid();
        }
    }
}
