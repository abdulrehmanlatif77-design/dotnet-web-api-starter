using FluentValidation;
using MediatR;
using VertexCore.Application.Common.Models;

namespace VertexCore.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) :
    IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
            return await next(cancellationToken);

        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .SelectMany(r => r.Errors)
            .Where(f => f != null)
            .ToList();

        if (failures.Count != 0)
        {
            // Convert FluentValidation failures to our Error model
            var errors = failures.Select(failure => Error.ValidationError(
                failure.PropertyName,
                failure.ErrorMessage,
                failure.ErrorCode ?? "VALIDATION_ERROR"
            )).ToList();

            // Create a more detailed validation exception
            var validationException = new ValidationException(failures);
            validationException.Data["CustomErrors"] = errors;
            
            throw validationException;
        }

        return await next(cancellationToken);
    }
}
