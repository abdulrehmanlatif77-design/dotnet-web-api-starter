using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using VertexCore.Domain.DTOs;
using VertexCore.Domain.Interfaces.Services;
using VertexCore.Infrastructure.Interfaces;
using VertexCore.Infrastructure.Configuration;

namespace VertexCore.Infrastructure.Services
{
    /**
     * This class implements the ITokenService interface to provide functionality
     * for generating and validating JWT tokens.
     * It uses the JWTSettings configuration to create tokens with user information and claims.
     * The class also implements the ITokenParser interface to extract information from tokens.
     * The GenerateToken method creates a JWT token based on the provided user information and
     *optional expiration time.
     **/
    public class TokenService : ITokenService, ITokenParser
    {
        // The JWTSettings instance holds the configuration settings for JWT,
        // such as secret key, issuer, audience, and expiration time.
        private readonly JWTSettings _jwtSettings;
        public TokenService(JWTSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }
        public string GenerateToken(TokenUserDto userDto, int? expirationMinutes = null)
        {
            // Check if the user has any roles assigned
            var roles = userDto.Roles?.Any() ?? false ? string.Join(",", userDto.Roles) : "user";

            // Create claims based on the user information
            // The claims include the user's ID, username, email, roles, and a unique identifier
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, userDto.UserId.ToString()),
            new Claim(ClaimTypes.Name, userDto.Username ?? string.Empty),
            new Claim(JwtRegisteredClaimNames.Email, userDto.Email ?? string.Empty),
            new Claim(ClaimTypes.Role, roles),
            new Claim(JwtRegisteredClaimNames.Jti, $"{userDto.UserId}-{Guid.NewGuid()}") // Unique identifier for the token associated with the user
            };

            // Create the key and credentials for signing the token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Expiration time for the token
            // If expirationMinutes is not provided, use the default value from JWTSettings
            var expirationTime = expirationMinutes ?? _jwtSettings.ExpirationMinutes;

            // Create the JWT token with the specified claims, issuer, audience, expiration time, and signing credentials
            // The issuer and audience are set to the values from JWTSettings
            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expirationTime),
                signingCredentials: creds
            );

            // Serialize the token to a string format
            // This string can be used as a bearer token in HTTP requests for authentication
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool ValidateToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _jwtSettings.Issuer,
                ValidAudience = _jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey))
            };

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);

                return true; // Token is valid
            }
            catch
            {
                return false; // Token is invalid
            }
        }

        public ClaimsPrincipal? GetClaimsPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = _jwtSettings.Issuer,
                ValidateAudience = true,
                ValidAudience = _jwtSettings.Audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero // Optional: make expiration check strict
            };

            try
            {
                return tokenHandler.ValidateToken(token, validationParameters, out _);
            }
            catch
            {
                return null; // Token is invalid or cannot be validated
            }
        }

        public string? GetEmailFromToken(string token)
        {
            var claimsPrincipal = GetClaimsPrincipalFromToken(token);
            return claimsPrincipal?.FindFirst(ClaimTypes.Email)?.Value;
        }
        
        public IList<string>? GetRolesFromToken(string token)
        {
            var claimsPrincipal = GetClaimsPrincipalFromToken(token);
            return claimsPrincipal?.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();
        }

        public string? GetUserIdFromToken(string token)
        {
            var claimsPrincipal = GetClaimsPrincipalFromToken(token);
            return claimsPrincipal?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public string? GetUsernameFromToken(string token)
        {
            var claimsPrincipal = GetClaimsPrincipalFromToken(token);
            return claimsPrincipal?.FindFirst(ClaimTypes.Name)?.Value;
        }
    }
}