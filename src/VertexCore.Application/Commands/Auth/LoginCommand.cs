using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using VertexCore.Application.Common.Models;
using VertexCore.Domain.DTOs;
using VertexCore.Domain.Interfaces.Services;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Commands.Auth
{
    public class LoginCommand : IRequest<Result<LoginResultDto>>
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginResultDto>>
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;

        public LoginCommandHandler(IAuthService authService, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _authService = authService;
        }

        public async Task<Result<LoginResultDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var loginResult = await _authService.LoginAsync(request.Email, request.Password);
                if (loginResult == null)
                {
                    return Result<LoginResultDto>.Failure(
                    [
                        Error.BusinessError("INVALID_CREDENTIALS", "Invalid email or password.") 
                    ], "Login failed");
                }

                var tokenUser = new TokenUserDto
                {
                    UserId = loginResult.Id,
                    Username = loginResult.UserName,
                    Email = loginResult.Email,
                    Roles = []
                };

                var loginData = new LoginResultDto
                {
                    Email = loginResult.Email,
                    Token = _tokenService.GenerateToken(tokenUser)
                };

                return Result<LoginResultDto>.Success(loginData, "Login successful");
            }
            catch (Exception ex)
            {
                return Result<LoginResultDto>.Failure(ex, "Login failed");
            }
        }
    }
}