using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VertexCore.Domain.Entities;


namespace VertexCore.Infrastructure.Configuration.EntityConfigurations
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.ToTable("Sections");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.SectionNumber)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(s => s.Semester)
                   .IsRequired()
                   .HasMaxLength(20);
            builder.Property(s => s.Year)
                   .IsRequired();
            builder.Property(s => s.RoomNumber)
                   .HasMaxLength(20);
            builder.Property(s => s.MeetingDay)
                   .IsRequired()
                   .HasColumnType("date");
            builder.Property(s => s.MeetingTime)
                   .IsRequired();
            // Configure optional relationship to Course using a shadow FK
            builder.HasOne(s => s.Course)
                   .WithMany(c => c.Sections)
                   .HasForeignKey("CourseId")
                   .OnDelete(DeleteBehavior.SetNull);
            // Configure optional relationship to Instructor using a shadow FK
            builder.HasOne(s => s.Instructor)
                   .WithMany(i => i.Sections)
                   .HasForeignKey("InstructorId")
                   .OnDelete(DeleteBehavior.SetNull);

            // Configure many-to-many between Section and Student via join table
            builder.HasMany(s => s.Students)
                   .WithMany(st => st.Sections)
                   .UsingEntity<Dictionary<string, object>>(
                        "SectionStudent",
                        j => j.HasOne<Student>().WithMany().HasForeignKey("StudentId").OnDelete(DeleteBehavior.Cascade),
                        j => j.HasOne<Section>().WithMany().HasForeignKey("SectionId").OnDelete(DeleteBehavior.Cascade)
                   );
        }
    }
}
