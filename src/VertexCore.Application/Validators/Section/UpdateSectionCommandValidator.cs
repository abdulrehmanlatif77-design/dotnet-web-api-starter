using FluentValidation;
using VertexCore.Application.Commands.Section;

namespace VertexCore.Application.Validators.Section
{
    public class UpdateSectionCommandValidator : AbstractValidator<UpdateSectionCommand>
    {
        public UpdateSectionCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Section ID is required.");

            RuleFor(x => x.SectionNumber)
                .NotEmpty()
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Section number is required.")
                .MaximumLength(50)
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Section number cannot exceed 50 characters.");

            RuleFor(x => x.Semester)
                .NotEmpty()
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Semester is required.")
                .MaximumLength(20)
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Semester cannot exceed 20 characters.");

            RuleFor(x => x.Year)
                .GreaterThanOrEqualTo(2000)
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Year must be a valid year (>= 2000).");

            RuleFor(x => x.MeetingTime)
                .NotNull()
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Meeting time must be specified.");
        }
    }
}
