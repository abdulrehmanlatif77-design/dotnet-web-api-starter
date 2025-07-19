using Microsoft.AspNetCore.Identity;
using VertexCore.Infrastructure.Identity;

namespace VertexCore.Application.Helpers
{
    /**
     * PasswordHasher class provides methods to hash and verify passwords.
     * It uses ASP.NET Core Identity's PasswordHasher for secure password handling.
     */
    public class PasswordHasher : IPasswordHasher<AppUser>
    {
        // Hashes a password for the given user.
        // Returns the hashed password as a string.
        public string HashPassword(AppUser user, string password)
        {
            var hasher = new PasswordHasher<AppUser>();
            return hasher.HashPassword(user, password);
        }

        // Verifies a hashed password against a provided password.
        // Returns PasswordVerificationResult indicating success or failure.
        public PasswordVerificationResult VerifyHashedPassword(AppUser user, string hashedPassword, string providedPassword)
        {
            var hasher = new PasswordHasher<AppUser>();
            return hasher.VerifyHashedPassword(user, hashedPassword, providedPassword);
        }
    }
}