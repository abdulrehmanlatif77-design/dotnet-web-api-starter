using FluentValidation;
using VertexCore.Application.Commands.Course;

namespace VertexCore.Application.Validators.Course
{
    public class DeleteCourseCommandValidator : AbstractValidator<DeleteCourseCommand>
    {
        public DeleteCourseCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Course ID is required.");
        }
    }
}
