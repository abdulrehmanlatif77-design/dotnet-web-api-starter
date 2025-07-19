namespace VertexCore.Application.Common.Models
{
    /**
     * Represents the result of an operation with data.
     * Encapsulates success status, optional data, messages, and errors.
     */
    public class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }
        public T? Data { get; private set; }
        public List<Error?> Errors { get; private set; }
        public DateTime Timestamp { get; private set; }

        protected Result(bool isSuccess, T? data, string message, List<Error?> errors)
        {
            IsSuccess = isSuccess;
            Data = data;
            Message = message;
            Errors = errors;
            Timestamp = DateTime.UtcNow;
        }

        // Creates a successful result with data
        public static Result<T> Success(T data, string message = "Operation succeeded") =>
            new(true, data, message, new());

        // Creates a failure result with a single error
        public static Result<T> Failure(string code, string message) =>
            new(false, default, message, new() { new Error { Code = code, Message = message} });

        // Creates a failure result with a list of errors
        public static Result<T> Failure(List<Error> errors, string message = "Operation failed") =>
            new(false, default, message, errors.Cast<Error?>().ToList());

        // Creates a failure result from an exception
        public static Result<T> Failure(Exception ex, string message = "An unexpected error occurred") =>
            new(false, default, message, new() { Error.FromException(ex) });

        // Allows implicit conversion from data to Result<T>
        public static implicit operator Result<T>(T data) =>
            data == null
                ? Failure("DATA_NULL", "Data is null")
                : Success(data);

        // Allows checking result success directly in if-statements
        public static implicit operator bool(Result<T> result) => result.IsSuccess;
    }

    /**
     * Represents the result of an operation without returning data.
     * Suitable for operations like create, delete, or update actions.
     */
    public class Result
    {
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }
        public List<Error> Errors { get; private set; }
        public DateTime Timestamp { get; private set; }

        protected Result(bool isSuccess, string message, List<Error> errors)
        {
            IsSuccess = isSuccess;
            Message = message;
            Errors = errors;
            Timestamp = DateTime.UtcNow;
        }

        // Creates a successful result
        public static Result Success(string message = "Operation succeeded") =>
            new(true, message, new());

        // Creates a failure result with a single error
        public static Result Failure(string code, string message) =>
            new(false, message, new() { new Error { Code = code, Message = message} });

        // Creates a failure result with a list of errors
        public static Result Failure(List<Error> errors, string message = "Operation failed") =>
            new(false, message, errors);

        // Creates a failure result from an exception
        public static Result Failure(Exception ex, string message = "An unexpected error occurred") =>
            new(false, message, new() { Error.FromException(ex) });

        // Allows checking result success directly in if-statements
        public static implicit operator bool(Result result) => result.IsSuccess;
    }
}
