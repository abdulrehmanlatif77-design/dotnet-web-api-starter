using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace VertexCore.Infrastructure.Interfaces
{
    /**
     * This interface defines methods for parsing tokens.
     * It provides functionality to extract user information from a token,
     * such as claims, user ID, username, email, and roles.
     */
    public interface ITokenParser
    {
        ClaimsPrincipal? GetClaimsPrincipalFromToken(string token);
        string? GetUserIdFromToken(string token);
        string? GetUsernameFromToken(string token);
        string? GetEmailFromToken(string token);
        IList<string>? GetRolesFromToken(string token);
    }
}