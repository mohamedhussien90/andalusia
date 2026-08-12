using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApplication2.Exceptions;

namespace WebApplication2.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
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

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int statusCode;
            string title;
            string detail = exception.Message;

            switch (exception)
            {
                case NotFoundException _:
                    statusCode = StatusCodes.Status404NotFound;
                    title = "Not Found";
                    break;
                case ConflictException _:
                    statusCode = StatusCodes.Status409Conflict;
                    title = "Conflict";
                    break;
                default:
                    statusCode = StatusCodes.Status500InternalServerError;
                    title = "Internal Server Error";
                    detail = "An unexpected error occurred.";
                    break;
            }

            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = statusCode;

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Detail = detail,
                Instance = context.Request.Path
            };

            var json = JsonSerializer.Serialize(problemDetails);
            return context.Response.WriteAsync(json);
        }
    }
}
