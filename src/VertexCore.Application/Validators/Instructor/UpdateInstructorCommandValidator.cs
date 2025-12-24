using FluentValidation;
using VertexCore.Application.Commands.Instructor;

namespace VertexCore.Application.Validators.Instructor
{
    public class UpdateInstructorCommandValidator : AbstractValidator<UpdateInstructorCommand>
    {
        public UpdateInstructorCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Instructor ID is required.");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("First name is required.")
                .MaximumLength(50)
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("First name cannot exceed 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Last name is required.")
                .MaximumLength(50)
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Last name cannot exceed 50 characters.");

            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Email address is required.")
                .MaximumLength(100)
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Email address cannot exceed 100 characters.");

            RuleFor(x => x.Salary)
                .GreaterThanOrEqualTo(0)
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Salary must be a non-negative value.");
        }
    }
}
