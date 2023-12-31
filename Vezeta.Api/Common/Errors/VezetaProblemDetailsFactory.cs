using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

namespace Vezeta.Api.Common.Errors;

public class VezetaProblemDetailsFactory : ProblemDetailsFactory
{
    private readonly ApiBehaviorOptions _options;

    public VezetaProblemDetailsFactory(IOptions<ApiBehaviorOptions> options)
    {
        _options = options?.Value ?? throw new System.ArgumentNullException(nameof(options));
    }

    public override ProblemDetails CreateProblemDetails(
        HttpContext httpContext,
        int? statusCode = null,
        string? title = null,
        string? type = null,
        string? detail = null,
        string? instance = null)
    {
        statusCode ??= 500;

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Type = type,
            Detail = detail,
            Instance = instance
        };

        if(title !=null)
        {
            problemDetails.Title = title;
        }

        ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);
        return problemDetails;
    }

    private void ApplyProblemDetailsDefaults(HttpContext httpContext, ProblemDetails problemDetails, int statusCode)
    {
        problemDetails.Status ??= statusCode;

        if(_options.ClientErrorMapping.TryGetValue(statusCode, out var clientErrorData))
        {
            problemDetails.Title ??= clientErrorData.Title;
            problemDetails.Type ??= clientErrorData.Link;
        }

        var traceId = Activity.Current?.Id ?? httpContext?.TraceIdentifier;

        if(traceId != null)
        {
            problemDetails.Extensions["traceId"] = traceId;
        }

        problemDetails.Extensions.Add("CustomError", "Custom Error Message");

    }

    public override ValidationProblemDetails CreateValidationProblemDetails(
        HttpContext httpContext, 
        ModelStateDictionary modelStateDictionary, 
        int? statusCode = null, 
        string? title = null, 
        string? type = null, 
        string? detail = null, 
        string? instance = null)
    {
        var problemDetails = new ValidationProblemDetails(modelStateDictionary)
        {
            Type = type,
            Detail = detail,
            Instance = instance
        };

        if(title != null)
        {
            problemDetails.Title = title;
        }

        ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode ?? 400);
        return problemDetails;
    }
}
