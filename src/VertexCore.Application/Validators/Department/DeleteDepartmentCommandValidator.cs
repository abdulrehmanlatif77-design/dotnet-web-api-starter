using FluentValidation;
using VertexCore.Application.Commands.Department;

namespace VertexCore.Application.Validators.Department
{
    public class DeleteDepartmentCommandValidator : AbstractValidator<DeleteDepartmentCommand>
    {
        public DeleteDepartmentCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Department ID is required.");
        }
    }
}
