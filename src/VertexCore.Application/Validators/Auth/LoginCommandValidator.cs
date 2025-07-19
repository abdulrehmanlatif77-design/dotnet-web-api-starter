using FluentValidation;
using VertexCore.Application.Commands.Auth;

namespace VertexCore.Application.Validators.Auth
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Password is required.");
        }
    }
} 