using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VertexCore.Domain.DTOs;

namespace VertexCore.Domain.Interfaces.Services
{
    /**
     * This interface defines the contract for token services.
     * It includes methods for generating and validating tokens.
     * Implementations of this interface will handle the specifics of token generation and validation.
     **/
    public interface ITokenService
    {
        string GenerateToken(TokenUserDto userDto, int? expirationMinutes = null);
        bool ValidateToken(string token);
    }
}