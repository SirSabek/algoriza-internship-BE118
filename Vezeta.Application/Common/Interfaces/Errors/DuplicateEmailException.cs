using System.Net;

namespace Vezeta.Application.Common.Interfaces.Errors
{
    public class DuplicateEmailException : Exception , IServiceException
    {
        public HttpStatusCode statusCode => HttpStatusCode.Conflict;
        public string message => "Email already exists";
    }
    
}