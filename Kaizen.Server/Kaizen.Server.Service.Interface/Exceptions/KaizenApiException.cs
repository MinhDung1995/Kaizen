using System;
using System.Runtime.Serialization;

namespace Kaizen.Server.Service.Interface.Excpetions
{
    [Serializable]
    public class KaizenApiException : Exception
    {
        public KaizenApiException()
        {
        }

        public KaizenApiException(string message) : base(message)
        {
        }

        public KaizenApiException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected KaizenApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}