using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VertexCore.Application.Common.Models;

namespace VertexCore.WebAPI.Extensions
{
    /**
     * Provides extension methods to convert application-layer Result types
     * into proper HTTP responses (IActionResult).
     */
    public static class ResultExtensions
    {
        // Converts a Result<T> into an IActionResult
        public static IActionResult ToActionResult<T>(this Result<T> result)
        {
            var response = new
            {
                isSuccess = result.IsSuccess,
                message = result.Message,
                data = result.Data,
                errors = result.Errors,
                timestamp = result.Timestamp,
                requestId = GetRequestId()
            };

            return new ObjectResult(response)
            {
                StatusCode = result.IsSuccess
                    ? StatusCodes.Status200OK
                    : MapErrorCodeToStatusCode(result.Errors.FirstOrDefault()?.Code)
            };
        }

        // Converts a Result (non-generic) into an IActionResult
        public static IActionResult ToActionResult(this Result result)
        {
            var response = new
            {
                isSuccess = result.IsSuccess,
                message = result.Message,
                data = (object?)null, // boş da olsa ortak yapı için gerekli
                errors = result.Errors,
                timestamp = result.Timestamp,
                requestId = GetRequestId()
            };

            return new ObjectResult(response)
            {
                StatusCode = result.IsSuccess
                    ? StatusCodes.Status200OK
                    : MapErrorCodeToStatusCode(result.Errors.FirstOrDefault()?.Code)
            };
        }

        // Maps custom error codes to HTTP status codes
        private static int MapErrorCodeToStatusCode(string? code) =>
            code?.ToUpperInvariant() switch
            {
                // Validation errors
                "VALIDATION_ERROR" => StatusCodes.Status400BadRequest,
                "INVALID_ARGUMENT" => StatusCodes.Status400BadRequest,
                "INVALID_OPERATION" => StatusCodes.Status400BadRequest,
                "BAD_REQUEST" => StatusCodes.Status400BadRequest,
                
                // Authentication & Authorization
                "UNAUTHORIZED" => StatusCodes.Status401Unauthorized,
                "FORBIDDEN" => StatusCodes.Status403Forbidden,
                "LOGIN_FAILED" => StatusCodes.Status401Unauthorized,
                "INVALID_CREDENTIALS" => StatusCodes.Status401Unauthorized,
                "TOKEN_EXPIRED" => StatusCodes.Status401Unauthorized,
                "TOKEN_INVALID" => StatusCodes.Status401Unauthorized,
                
                // Not found errors
                "NOT_FOUND" => StatusCodes.Status404NotFound,
                "USER_NOT_FOUND" => StatusCodes.Status404NotFound,
                "RESOURCE_NOT_FOUND" => StatusCodes.Status404NotFound,
                
                // Conflict errors
                "CONFLICT" => StatusCodes.Status409Conflict,
                "DUPLICATE_ENTRY" => StatusCodes.Status409Conflict,
                "USER_ALREADY_EXISTS" => StatusCodes.Status409Conflict,
                "EMAIL_ALREADY_EXISTS" => StatusCodes.Status409Conflict,
                
                // Business logic errors
                "PASSWORD_MISMATCH" => StatusCodes.Status400BadRequest,
                "USER_CREATION_FAILED" => StatusCodes.Status500InternalServerError,
                "INSUFFICIENT_PERMISSIONS" => StatusCodes.Status403Forbidden,
                "ACCOUNT_LOCKED" => StatusCodes.Status423Locked,
                "ACCOUNT_DISABLED" => StatusCodes.Status423Locked,
                
                // Server errors
                "INTERNAL_SERVER_ERROR" => StatusCodes.Status500InternalServerError,
                "DATABASE_ERROR" => StatusCodes.Status500InternalServerError,
                "EXTERNAL_SERVICE_ERROR" => StatusCodes.Status502BadGateway,
                "SERVICE_UNAVAILABLE" => StatusCodes.Status503ServiceUnavailable,
                
                // Default
                _ => StatusCodes.Status500InternalServerError
            };

        // Helper method to get request ID for tracking
        private static string GetRequestId()
        {
            // In a real application, you might want to use a correlation ID from the request context
            // For now, we'll use a simple timestamp-based ID
            return DateTime.UtcNow.Ticks.ToString();
        }
    }
}
