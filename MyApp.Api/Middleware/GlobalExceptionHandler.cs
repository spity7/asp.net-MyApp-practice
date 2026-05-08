using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Exceptions;
using MyApp.Core.Exceptions;

namespace MyApp.Api.Middleware
{
    public sealed class GlobalExceptionHandler(
        ILogger<GlobalExceptionHandler> logger,
        IHostEnvironment hostEnvironment) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
            CancellationToken cancellationToken)
        {
            if (exception is ApplicationValidationException validationException)
            {
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

                var problem = new ProblemDetails
                {
                    Title = "Validation failed",
                    Status = StatusCodes.Status400BadRequest,
                    Detail = "One or more validation errors occurred.",
                };

                problem.Extensions["errors"] = validationException.Errors;

                await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);

                return true;
            }

            if (exception is ExternalServiceException externalException)
            {
                httpContext.Response.StatusCode = StatusCodes.Status502BadGateway;

                var problem = new ProblemDetails
                {
                    Title = "Upstream service error",
                    Status = StatusCodes.Status502BadGateway,
                    Detail = externalException.Message,
                };

                await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);

                return true;
            }

            logger.LogError(exception, "Unhandled exception");

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var internalProblem = new ProblemDetails
            {
                Title = "Server error",
                Status = StatusCodes.Status500InternalServerError,
                Detail = hostEnvironment.IsDevelopment()
                    ? exception.Message
                    : "An unexpected error occurred.",
            };

            if (hostEnvironment.IsDevelopment())
            {
                internalProblem.Extensions["trace"] = exception.ToString();
            }

            await httpContext.Response.WriteAsJsonAsync(internalProblem, cancellationToken);

            return true;
        }
    }
}
