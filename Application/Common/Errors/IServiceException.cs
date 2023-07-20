using System.Net;

namespace Application.Common.Errors
{
    public interface IServiceException
    {
        HttpStatusCode StatusCode { get; set; }

        string ErrorMessage { get; set; }
    }
}