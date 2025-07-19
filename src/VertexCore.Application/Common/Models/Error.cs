namespace VertexCore.Application.Common.Models
{
    /**
     * Represents a standardized error model used within operation results.
     */
    public class Error
    {
        public string Code { get; set; } = default!;
        public string Message { get; set; } = default!;
        public string? Details { get; set; }
        public string? Field { get; set; }
        public string? Source { get; set; }

        // Factory method to create an error from an exception
        public static Error FromException(Exception ex) =>
            new()
            {
                Code = ex.GetType().Name,
                Message = ex.Message,
                Details = ex.StackTrace,
                Source = ex.Source ?? ex.GetType().Name
            };

        // Factory method to create a validation error
        public static Error ValidationError(string field, string message, string? details = null) =>
            new()
            {
                Code = "VALIDATION_ERROR",
                Message = message,
                Field = field,
                Details = details
            };

        // Factory method to create a business logic error
        public static Error BusinessError(string code, string message, string? details = null) =>
            new()
            {
                Code = code,
                Message = message,
                Details = details
            };

        // Factory method to create a not found error
        public static Error NotFound(string resource, string? details = null) =>
            new()
            {
                Code = "NOT_FOUND",
                Message = $"{resource} not found",
                Details = details
            };

        // Factory method to create an unauthorized error
        public static Error Unauthorized(string message = "Unauthorized access", string? details = null) =>
            new()
            {
                Code = "UNAUTHORIZED",
                Message = message,
                Details = details
            };

        // Factory method to create a forbidden error
        public static Error Forbidden(string message = "Access forbidden", string? details = null) =>
            new()
            {
                Code = "FORBIDDEN",
                Message = message,
                Details = details
            };
    }
}