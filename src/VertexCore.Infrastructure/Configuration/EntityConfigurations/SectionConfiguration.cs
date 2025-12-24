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
        }
    }
}
