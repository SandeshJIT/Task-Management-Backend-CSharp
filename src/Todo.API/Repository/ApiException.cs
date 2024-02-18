using System.Net;
using System.Runtime.Serialization;

namespace Todo.API.Repository
{
    [Serializable]
    internal class ApiException : Exception
    {
        private HttpStatusCode statusCode;
        private string message;

        public ApiException()
        {
        }

        public ApiException(string? message) : base(message)
        {
        }

        public ApiException(HttpStatusCode internalServerError, string message)
        {
            this.statusCode = internalServerError;
            this.message = message;
        }

        public ApiException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}