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

            // Configure explicit relationship to Department using the existing FK property
            builder.HasOne(c => c.Department)
                   .WithMany(d => d.Courses)               // specify inverse navigation
                   .HasForeignKey(c => c.DepartmentId)    // map to the existing FK property
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
