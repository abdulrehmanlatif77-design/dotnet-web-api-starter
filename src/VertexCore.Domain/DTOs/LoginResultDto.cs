using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VertexCore.Domain.DTOs
{
    public class LoginResultDto
    {
        public string? Email { get; set; }
        public string? Token { get; set; }
    }
}