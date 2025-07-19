using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VertexCore.Infrastructure.Identity;

namespace VertexCore.Infrastructure.Interfaces.Services
{
    public interface IAuthService
    {
        Task<AppUser?> CreateUserAsync(AppUser user, string password);
        Task<AppUser?> LoginAsync(string email, string password);
        Task<AppUser?> FindUserByEmailAsync(string email);
        Task<AppUser?> FindUserByIdAsync(string userId);
    }
}