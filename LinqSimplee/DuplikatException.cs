using System;
using System.Runtime.Serialization;

namespace LinqSimplee
{
    [Serializable]
    internal class DuplikatException : ApplicationException
    {
        public DuplikatException()
        {
        }

        public DuplikatException(string message) : base(message)
        {
        }

        public DuplikatException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplikatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}