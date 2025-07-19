using MediatR;
using Microsoft.AspNetCore.Identity;
using VertexCore.Application.Common.Models;
using VertexCore.Infrastructure.Identity;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Commands.Auth
{
    public class CreateUserCommand : IRequest<Result>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
    {
        private readonly IAuthService _authService;
        private readonly IPasswordHasher<AppUser> _passwordHasher;

        public CreateUserCommandHandler(IAuthService authService, IPasswordHasher<AppUser> passwordHasher)
        {
            _authService = authService;
            _passwordHasher = passwordHasher;
        }

        public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingUser = await _authService.FindUserByEmailAsync(request.Email);
                if (existingUser != null)
                {
                    return Result.Failure(
                    [
                        Error.BusinessError("USER_ALREADY_EXISTS", "A user with this email already exists.") 
                    ], "User creation failed");
                }

                var user = new AppUser
                {
                    FirstName = request.FirstName ?? null,
                    LastName = request.LastName ?? null,
                    UserName = request.UserName,
                    Email = request.Email,
                };

                var result = await _authService.CreateUserAsync(user, request.Password);
                
                if (result == null)
                {
                    return Result.Failure(
                    [
                        Error.BusinessError("USER_CREATION_FAILED", "Failed to create user. Please try again.")
                    ], "User creation failed");
                }

                return Result.Success("User created successfully");
            }
            catch (ArgumentException aex)
            {
                return Result.Failure(
                [
                    Error.BusinessError("INVALID_ARGUMENT", aex.Message, aex.ParamName) 
                ], "Invalid user data provided");
            }
            catch (Exception ex)
            {
                return Result.Failure(ex, "User creation failed");
            }
        }
    }
}