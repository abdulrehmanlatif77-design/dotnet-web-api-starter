using FluentValidation;
using VertexCore.Application.Commands.Course;

namespace VertexCore.Application.Validators.Course
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Course title is required.")
                .MaximumLength(100)
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Course title cannot exceed 100 characters.");

            RuleFor(x => x.Credits)
                .GreaterThanOrEqualTo(0)
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Course credits must be a non-negative value.");
        }
    }
}
