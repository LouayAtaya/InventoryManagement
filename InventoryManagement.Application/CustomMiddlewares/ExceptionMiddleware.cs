using InventoryManagement.Application.Contracts;
using InventoryManagement.Domain.Exceptions;
using InventoryManagement.Domain.Exceptions.Abstractions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.CustomMiddlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _loggerManager;
        public ExceptionMiddleware(RequestDelegate next, ILoggerManager loggerManager)
        {
            _loggerManager = loggerManager;

            //function delegate that can process our HTTP requests.
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (ResourceNotFoundException ne)
            {
                _loggerManager.LogError($"{httpContext.Request.Method} {httpContext.Request.Path}" +
                    $" A new Resource Not Found exception has been thrown: {ne}");
                await HandleExceptionAsync(httpContext, ne, ne.StatusCode);
            }
            catch (BadRequestException be)
            {
                _loggerManager.LogError($"{httpContext.Request.Method} {httpContext.Request.Path}" +
                    $" A new BadReqest exception has been thrown: {be}");
                await HandleExceptionAsync(httpContext, be, be.StatusCode);
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"{httpContext.Request.Method} {httpContext.Request.Path}" +
                    $" Something went wrong: {e}");
                await HandleExceptionAsync(httpContext, e, (int)HttpStatusCode.InternalServerError);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception, int statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var message = exception switch
            {
                ResourceNotFoundException => exception.Message,
                BadRequestException=> exception.Message,
                _ => "Internal Server Error."
            };

            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = message,
                details = $"{exception}"
            }.ToString());
        }
        
    }
}
