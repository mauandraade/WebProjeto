using System;
using System.Runtime.Serialization;

namespace SalesWebMvcc.Controllers
{
    [Serializable]
    internal class NotFoundExcepetion : Exception
    {
        public NotFoundExcepetion()
        {
        }

        public NotFoundExcepetion(string message) : base(message)
        {
        }

        public NotFoundExcepetion(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundExcepetion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}