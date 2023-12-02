using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Vezeta.Application.Common.Interfaces.Errors;

namespace Vezeta.Api.Controllers;

[ApiController]
public class ErrorsController : ControllerBase
{
    [Route("error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode, message) = exception switch
        {
            DuplicateEmailException => (StatusCodes.Status409Conflict, "Email already exists"),
            _ => (StatusCodes.Status500InternalServerError, "An error occurred")
        };
        return Problem(statusCode: statusCode, title: message);
    }
}