using Microsoft.AspNetCore.Identity;

namespace VertexCore.Infrastructure.Identity
{
    /*
    * This class represents the application user in the identity system.
    * It extends the IdentityUser class provided by ASP.NET Core Identity.
    * ASP.NET Core Identity provides a default implementation for user management,
    * including properties like UserName, Email, PasswordHash, etc.
    * You can add additional properties to this class if needed.
    * For example, you might want to add properties like FirstName, LastName, etc
    **/
    public class AppUser : IdentityUser
    {
        // You can add additional properties here if needed
        // For example:
        // public string FirstName { get; set; }
        // public string LastName { get; set; }

    }
}