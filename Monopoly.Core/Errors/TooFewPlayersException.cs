using System;
using System.Runtime.Serialization;

namespace Monopoly.Core.Errors
{
    [Serializable]
    public class TooFewPlayersException : Exception
    {
        public TooFewPlayersException()
        {
        }

        public TooFewPlayersException(string message) : base(message)
        {
        }

        public TooFewPlayersException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TooFewPlayersException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
