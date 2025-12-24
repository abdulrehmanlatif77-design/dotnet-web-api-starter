using FluentValidation;
using VertexCore.Application.Commands.Student;

namespace VertexCore.Application.Validators.Student
{
    public class DeleteStudentCommandValidator : AbstractValidator<DeleteStudentCommand>
    {
        public DeleteStudentCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Student ID is required.");
        }
    }
}
