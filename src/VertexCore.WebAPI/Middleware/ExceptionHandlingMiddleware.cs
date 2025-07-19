using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using VertexCore.Application.Common.Models;
using VertexCore.WebAPI.Extensions;

namespace VertexCore.WebAPI.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly IWebHostEnvironment _environment;

        public ExceptionHandlingMiddleware(
            RequestDelegate next, 
            ILogger<ExceptionHandlingMiddleware> logger,
            IWebHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException vex)
            {
                await HandleValidationExceptionAsync(context, vex);
            }
            catch (UnauthorizedAccessException uex)
            {
                await HandleUnauthorizedExceptionAsync(context, uex);
            }
            catch (ArgumentException aex)
            {
                await HandleArgumentExceptionAsync(context, aex);
            }
            catch (InvalidOperationException ioex)
            {
                await HandleInvalidOperationExceptionAsync(context, ioex);
            }
            catch (Exception ex)
            {
                await HandleGenericExceptionAsync(context, ex);
            }
        }

        private async Task HandleValidationExceptionAsync(HttpContext context, ValidationException vex)
        {
            _logger.LogWarning(vex, "Validation error occurred for request: {RequestPath}", context.Request.Path);

            var errors = vex.Errors
                .Select(e => Error.ValidationError(
                    e.PropertyName, 
                    e.ErrorMessage, 
                    e.ErrorCode))
                .ToList();

            var result = Result.Failure(errors, "Validation failed");
            await WriteErrorResponseAsync(context, result, HttpStatusCode.BadRequest);
        }

        private async Task HandleUnauthorizedExceptionAsync(HttpContext context, UnauthorizedAccessException uex)
        {
            _logger.LogWarning(uex, "Unauthorized access attempt: {RequestPath}", context.Request.Path);

            var error = Error.Unauthorized(uex.Message);
            var result = Result.Failure(new List<Error> { error }, "Access denied");
            await WriteErrorResponseAsync(context, result, HttpStatusCode.Unauthorized);
        }

        private async Task HandleArgumentExceptionAsync(HttpContext context, ArgumentException aex)
        {
            _logger.LogWarning(aex, "Invalid argument provided: {RequestPath}", context.Request.Path);

            var error = Error.BusinessError("INVALID_ARGUMENT", aex.Message, aex.ParamName);
            var result = Result.Failure([error], "Invalid request");
            await WriteErrorResponseAsync(context, result, HttpStatusCode.BadRequest);
        }

        private async Task HandleInvalidOperationExceptionAsync(HttpContext context, InvalidOperationException ioex)
        {
            _logger.LogWarning(ioex, "Invalid operation attempted: {RequestPath}", context.Request.Path);

            var error = Error.BusinessError("INVALID_OPERATION", ioex.Message);
            var result = Result.Failure([error], "Operation not allowed");
            await WriteErrorResponseAsync(context, result, HttpStatusCode.BadRequest);
        }

        private async Task HandleGenericExceptionAsync(HttpContext context, Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred for request: {RequestPath}", context.Request.Path);

            var errorMessage = _environment.IsDevelopment() 
                ? ex.Message 
                : "An unexpected error occurred. Please try again later.";

            var errorDetails = _environment.IsDevelopment() 
                ? ex.StackTrace 
                : null;

            var error = new Error
            {
                Code = "INTERNAL_SERVER_ERROR",
                Message = errorMessage,
                Details = errorDetails,
                Source = ex.Source
            };

            var result = Result.Failure(new List<Error> { error }, "Internal Server Error");
            await WriteErrorResponseAsync(context, result, HttpStatusCode.InternalServerError);
        }

        private static async Task WriteErrorResponseAsync(HttpContext context, Result result, HttpStatusCode statusCode)
        {
            var response = result.ToActionResult();
            
            // Cast to ObjectResult to access the Value property
            if (response is ObjectResult objectResult)
            {
                var json = JsonSerializer.Serialize(objectResult.Value, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = false,
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
                });

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)statusCode;

                await context.Response.WriteAsync(json);
            }
            else
            {
                // Fallback for other result types
                context.Response.StatusCode = (int)statusCode;
                await context.Response.WriteAsync("{\"error\":\"Internal server error\"}");
            }
        }
    }
}
