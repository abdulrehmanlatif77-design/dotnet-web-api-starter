using FluentValidation;
using VertexCore.Application.Commands.Product;

namespace VertexCore.Application.Validators.Product
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Product ID is required.");
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Product name is required.")
                .MaximumLength(100)
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Product name cannot exceed 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Product description cannot exceed 500 characters.");
            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0)
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Product price must be a non-negative value.");
            RuleFor(RuleFor => RuleFor.IsActive)
                .NotNull()
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Product active status must be specified.");

        }
    }
}
