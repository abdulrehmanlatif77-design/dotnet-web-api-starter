using System;

namespace VertexCore.Domain.Dtos
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleInitial { get; set; }
        public required string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string? Gender { get; set; }

        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public required string EmailAddress { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public VertexCore.Domain.Entities.DegreeType Degree { get; set; }

        public decimal GPA { get; set; }
    }
}
