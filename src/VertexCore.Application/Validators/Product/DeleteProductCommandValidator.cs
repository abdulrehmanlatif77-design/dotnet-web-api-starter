using FluentValidation;
using VertexCore.Application.Commands.Product;

namespace VertexCore.Application.Validators.Product
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id)
           .NotEmpty()
           .WithErrorCode("VALIDATION_ERROR")
           .WithMessage("Product ID is required.");
        }
    }
}
