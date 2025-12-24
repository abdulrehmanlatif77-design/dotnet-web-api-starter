using FluentValidation;
using VertexCore.Application.Commands.Student;

namespace VertexCore.Application.Validators.Student
{
    public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Student ID is required.");

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

            RuleFor(x => x.GPA)
                .InclusiveBetween(0, 4)
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("GPA must be between 0 and 4.");

            RuleFor(x => x.DateOfBirth)
                .LessThan(System.DateTime.Now)
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Date of birth must be in the past.");
        }
    }
}
