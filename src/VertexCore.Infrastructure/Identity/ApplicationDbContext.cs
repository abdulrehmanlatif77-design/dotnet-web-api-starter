using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VertexCore.Infrastructure.Identity
{
    /**
     * This class represents the application database context for identity.
     * It extends the IdentityDbContext class provided by ASP.NET Core Identity.
     * This context is used to interact with the database for user management,
     * roles, and other identity-related operations.
     **/
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<AppUser>(options)
    {
    }
}