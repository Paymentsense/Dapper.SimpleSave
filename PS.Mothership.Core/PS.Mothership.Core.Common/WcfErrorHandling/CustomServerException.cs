using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.WcfErrorHandling
{
    [Serializable]
    public class CustomServerException : Exception
    {
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public CustomServerException()
        {
        }

        public CustomServerException(string message)
            : base(message)
        {
        }

        public CustomServerException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}