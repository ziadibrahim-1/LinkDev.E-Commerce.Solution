
using LinkDev.ECommerce.APIs.Controllers.Error;
using LinkDev.ECommerce.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace LinkDev.ECommerce.APIs.Midlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, IWebHostEnvironment environment, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _environment = environment;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                #region Logging Exception
                if (_environment.IsDevelopment())
                {
                    _logger.LogError(ex, ex.Message, ex.StackTrace!.ToString());
                }
                else
                {
                    // log the exception to a file or database
                }
                #endregion

                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            ApiResponse response;
            switch (ex)
            {
                case NotFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    response = new ApiResponse((int)HttpStatusCode.NotFound, ex.Message);
                    break;
                case BadRequstException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response = new ApiResponse((int)HttpStatusCode.BadRequest, ex.Message);
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response = _environment.IsDevelopment() ? new ApiExceptionResponse((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace?.ToString())
                    : new ApiExceptionResponse((int)HttpStatusCode.InternalServerError, ex.Message);
                    break;
            }

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(response.ToString());
        }
    }
}
