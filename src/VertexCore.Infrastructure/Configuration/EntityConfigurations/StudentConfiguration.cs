using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VertexCore.Domain.Entities;

namespace VertexCore.Infrastructure.Configuration.EntityConfigurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(s => s.Id);

            builder.Property(s => s.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(s => s.MiddleInitial)
                   .HasMaxLength(5);

            builder.Property(s => s.LastName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(s => s.DateOfBirth)
                   .IsRequired();

            builder.Property(s => s.Gender)
                   .HasMaxLength(20);

            builder.Property(s => s.Address)
                   .HasMaxLength(200);

            builder.Property(s => s.PhoneNumber)
                   .HasMaxLength(20);

            builder.Property(s => s.EmailAddress)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.EnrollmentDate)
                   .IsRequired();

            // Store enum as integer (default). If you prefer strings, use HasConversion<string>().
            builder.Property(s => s.Degree)
                   .IsRequired();

            // GPA with precision (max 3 digits, 2 decimal places e.g. 4.00)
            builder.Property(s => s.GPA)
                   .HasPrecision(3, 2);
        }
    }
}
