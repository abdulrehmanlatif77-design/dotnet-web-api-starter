using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VertexCore.Domain.Entities;


namespace VertexCore.Infrastructure.Configuration.EntityConfigurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.Credits)
                   .IsRequired();

            // Configure optional relationship to Department using a shadow FK
            builder.HasOne(c => c.Department)
                   .WithMany()
                   .HasForeignKey("DepartmentId")
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
