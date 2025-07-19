using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VertexCore.Domain.DTOs
{
    /**
     * This class represents a user in the context of a token.
     * It contains properties that are typically included in a JWT token payload.
     * This DTO is used to transfer user information securely, especially after authentication.
     **/
    public class TokenUserDto
    {
        public required string UserId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public IList<string>? Roles { get; set; }
    }
}