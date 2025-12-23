using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VertexCore.Domain.Entities;


namespace VertexCore.Infrastructure.Configuration.EntityConfigurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructors");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(i => i.LastName)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(i => i.Address)
                   .HasMaxLength(200);
            builder.Property(i => i.HomePhone)
                   .HasMaxLength(15);
            builder.Property(i => i.OfficePhone)
                   .HasMaxLength(15);
            builder.Property(i => i.EmailAddress)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(i => i.Salary)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();
            builder.Property(i => i.Position)
                   .HasMaxLength(100);
            builder.Property(i => i.HireDate)
                   .IsRequired();
        }
    }
}
