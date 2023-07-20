using System.Net;

namespace Application.Common.Errors
{
    public class ValidationExeption : Exception, IServiceException
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.Conflict;

        public string ErrorMessage { get; set; } = "Email already exists..";
    }
}