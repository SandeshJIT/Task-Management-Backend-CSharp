using System.Net;

namespace Todo.API
{
    internal class ErrorResponse
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}