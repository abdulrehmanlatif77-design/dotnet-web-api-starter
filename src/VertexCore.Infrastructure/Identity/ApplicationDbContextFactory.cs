using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace VertexCore.Infrastructure.Identity
{
    // Design-time factory for EF Core tooling. This avoids invoking the application's
    // Startup/Program during design-time (migrations) and provides a DbContext with
    // a connection string.
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Use the same connection string as the WebAPI project's appsettings.json.
            // Adjust if you run migrations on a different machine.
            var connectionString = "Server=SURYARAJESH\\SQLEXPRESS;Database=VertexCoreDb;Integrated Security=true;TrustServerCertificate=true;";

            builder.UseSqlServer(connectionString);

            return new ApplicationDbContext(builder.Options);
        }
    }
}
