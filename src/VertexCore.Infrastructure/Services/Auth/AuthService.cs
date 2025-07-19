using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using VertexCore.Infrastructure.Identity;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Infrastructure.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public Task<AppUser?> CreateUserAsync(AppUser user, string password)
        {
            var result = _userManager.CreateAsync(user, password);
            if (result.Result.Succeeded)
            {
                return Task.FromResult<AppUser?>(user);
            }
            return Task.FromResult<AppUser?>(null);
        }

        public Task<AppUser?> FindUserByEmailAsync(string email)
        {
            return _userManager.FindByEmailAsync(email) ?? Task.FromResult<AppUser?>(null);
        }

        public Task<AppUser?> FindUserByIdAsync(string userId)
        {
            return _userManager.FindByIdAsync(userId) ?? Task.FromResult<AppUser?>(null);
        }

        public Task<AppUser?> LoginAsync(string email, string password)
        {
            var result = _userManager.FindByEmailAsync(email);

            if (result.Result != null)
            {
                var signInResult = _signInManager.PasswordSignInAsync(result.Result, password, false, false);
                if (signInResult.Result.Succeeded)
                {
                    return Task.FromResult<AppUser?>(result.Result);
                }
            }
            return Task.FromResult<AppUser?>(null);
        }
    }
}