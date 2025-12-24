using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VertexCore.Domain.Entities;

namespace VertexCore.Infrastructure.Configuration.EntityConfigurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(d => d.Budget)
                   .HasPrecision(18, 2);

            // Configure optional relationship to Instructor using a shadow FK
            builder.HasOne(d => d.Instructor)
                   .WithMany()
                   .HasForeignKey("InstructorId")
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
