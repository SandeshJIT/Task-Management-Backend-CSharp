using Microsoft.AspNetCore.Http;
using System.Net;
using System.Runtime.Serialization;

namespace Todo.API.Exceptions
{
    [Serializable]
    public class ApiException : Exception
    {
        private HttpStatusCode statusCode;
        private string message;

        public ApiException(HttpStatusCode statusCode, string message) :
        base($"Request to API failed with status code {statusCode}: {message}")
        {
            statusCode = statusCode;
            message = message;
        }


    }
}