using FluentValidation;
using VertexCore.Application.Commands.Department;

namespace VertexCore.Application.Validators.Department
{
    public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
    {
        public UpdateDepartmentCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Department ID is required.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Department name is required.")
                .MaximumLength(150)
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Department name cannot exceed 150 characters.");

            RuleFor(x => x.Location)
                .MaximumLength(200)
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Location cannot exceed 200 characters.");

            RuleFor(x => x.PhoneNumber)
                .MaximumLength(20)
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Phone number cannot exceed 20 characters.");

            RuleFor(x => x.Budget)
                .GreaterThanOrEqualTo(0)
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Budget must be a non-negative value.");
        }
    }
}
