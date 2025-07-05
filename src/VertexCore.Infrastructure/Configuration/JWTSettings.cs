using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VertexCore.Infrastructure.Configuration
{
    /**
     * This class represents the settings for JWT (JSON Web Token) configuration.
     * It contains properties that are typically used to configure JWT authentication,
     * such as the secret key, issuer, audience, and expiration time.
     **/
    public class JWTSettings
    {
        public string SecretKey { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int ExpirationMinutes { get; set; } = 15;
    }
}