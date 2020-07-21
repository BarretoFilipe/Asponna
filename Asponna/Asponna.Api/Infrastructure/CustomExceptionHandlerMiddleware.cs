using Asponna.Application.Common.Exceptions;
using Asponna.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Asponna.Api.Infrastructure
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public CustomExceptionHandlerMiddleware(RequestDelegate next, ILogger<CustomExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        //■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var error = new Error();
            var errorLog = new Error();

            error.Exception = "Unabled to process the request";
            errorLog.Exception = exception.Message;
            var innerException = exception.InnerException;
            errorLog.InnerException = innerException?.InnerException?.Message ?? innerException?.Message;

            try
            {
                switch (exception)
                {
                    case ValidationException validationException:
                        code = HttpStatusCode.BadRequest;
                        error.Exception = "One or more validation failures have occurred.";
                        error.InnerException = string.Join("\n", validationException.Failures.SelectMany(errors => errors.Value));
                        break;

                    case ArgumentNullException _:
                        code = HttpStatusCode.BadRequest;
                        error.Exception = "Parameters not expected";

                        _logger.LogInformation("Argument Null: {Message}", errorLog.InnerException ?? errorLog.Exception);
                        break;

                    case DomainException _:
                        _logger.LogInformation("Bad Request: {Message}", errorLog.InnerException ?? errorLog.Exception);
                        break;

                    default:
                        _logger.LogError(exception, "ERROR Unhandled exception request");
                        break;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR Unhandled exception thrown at exception handler");
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(error));
        }
    }
}