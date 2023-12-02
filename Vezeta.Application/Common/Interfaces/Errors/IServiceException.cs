using System.Net;

namespace Vezeta.Application.Common.Interfaces.Errors;

public interface IServiceException 
{
    public HttpStatusCode statusCode { get; }
    public string message { get; }

}
