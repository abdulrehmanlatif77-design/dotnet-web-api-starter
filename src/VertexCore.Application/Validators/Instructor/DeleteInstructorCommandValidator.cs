using FluentValidation;
using VertexCore.Application.Commands.Instructor;

namespace VertexCore.Application.Validators.Instructor
{
    public class DeleteInstructorCommandValidator : AbstractValidator<DeleteInstructorCommand>
    {
        public DeleteInstructorCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Instructor ID is required.");
        }
    }
}
