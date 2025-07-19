using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using VertexCore.Application.Commands.Auth;

namespace VertexCore.Application.Validators.Auth
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .MaximumLength(50)
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("First name cannot exceed 50 characters.");

            RuleFor(x => x.LastName)
                .MaximumLength(50)
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Last name cannot exceed 50 characters.");

            RuleFor(x => x.UserName)
                .MaximumLength(50)
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Username cannot exceed 50 characters.");

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
                .WithMessage("Password is required.")
                .MinimumLength(6)
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Password must be at least 6 characters long.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)")
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Password must contain at least one uppercase letter, one lowercase letter, and one number.");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .WithErrorCode("VALIDATION_ERROR")
                .WithMessage("Confirm password is required.")
                .Equal(x => x.Password)
                .WithErrorCode("PASSWORD_MISMATCH")
                .WithMessage("Passwords do not match.");
        }
    }
}