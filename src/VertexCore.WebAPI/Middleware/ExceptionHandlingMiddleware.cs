using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using VertexCore.Application.Common.Exceptions;
using VertexCore.Application.Common.Models;

namespace VertexCore.WebAPI.Middleware
{
    /* Middleware to handle exceptions globally */
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
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
                _logger.LogError(ex, "Unhandled exception");

                var (result, statusCode) = MapExceptionToResult(ex);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;

                var json = JsonSerializer.Serialize(new
                {
                    message = result.Message,
                    errors = result.Errors,
                    timestamp = result.Timestamp
                });

                await context.Response.WriteAsync(json);
            }
        }

        private (Result result, int statusCode) MapExceptionToResult(Exception ex)
        {
            return ex switch
            {
                ValidationException ve => (
                    Result.Failure(ve.Errors, ve.Message),
                    StatusCodes.Status400BadRequest
                ),

                UnauthorizedAccessException => (
                    Result.Failure("UNAUTHORIZED", "You are not authorized."),
                    StatusCodes.Status401Unauthorized
                ),

                ForbiddenAccessException fe => (
                    Result.Failure("FORBIDDEN", fe.Message),
                    StatusCodes.Status403Forbidden
                ),

                NotFoundException nf => (
                    Result.Failure("USR404", nf.Message),
                    StatusCodes.Status404NotFound
                ),

                ConflictException ce => (
                    Result.Failure("CONFLICT", ce.Message),
                    StatusCodes.Status409Conflict
                ),

                _ => (
                    Result.Failure(ex),
                    StatusCodes.Status500InternalServerError
                )
            };
        }

    }
}