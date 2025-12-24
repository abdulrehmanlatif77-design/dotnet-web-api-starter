using FluentValidation;
using VertexCore.Application.Commands.Section;

namespace VertexCore.Application.Validators.Section
{
    public class DeleteSectionCommandValidator : AbstractValidator<DeleteSectionCommand>
    {
        public DeleteSectionCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Section ID is required.");
        }
    }
}
