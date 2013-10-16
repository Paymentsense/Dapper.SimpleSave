using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.WcfErrorHandling
{
    [Serializable]
    public class WcfException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public WcfException()
        {
        }

        public WcfException(string message, string uniqueKey) : base(message)
        {
            UniqueKey = uniqueKey;
        }

        public WcfException(string message, string uniqueKey, Exception inner) : base(message, inner)
        {
            UniqueKey = uniqueKey;
        }

        protected WcfException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
            if (info != null)
                UniqueKey = info.GetString("UniqueKey");
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("UniqueKey",UniqueKey);
        }

        public string UniqueKey { get; set; }
    }
}