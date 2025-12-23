using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VertexCore.Domain.Entities;

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

        public DbSet<Product> Products { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Instructor> Instructors { get; set; }


        public DbSet<Department> Departments { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Section> Sections { get; set; }


        /**
         * This method is used to configure the model for the identity context.
         * It can be overridden to customize the model, such as adding custom tables or relationships.
         **/
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Apply configurations for identity entities
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }
}