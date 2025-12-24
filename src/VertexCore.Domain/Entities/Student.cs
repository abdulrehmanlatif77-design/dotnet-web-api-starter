namespace VertexCore.Domain.Entities
{
    /// <summary>
    /// Represents a student in the domain.
    /// </summary>
    public class Student : BaseEntity<Guid>
    {
        // StudentID is represented by the inherited `Id` property (Guid)

        public required string FirstName { get; set; }
        public string? MiddleInitial { get; set; }
        public required string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string? Gender { get; set; }

        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public required string EmailAddress { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public DegreeType Degree { get; set; }

        public decimal GPA { get; set; }

    }

    /// <summary>
    /// Degree types supported for a student.
    /// </summary>
    public enum DegreeType
    {
        BE,
        BTech,
        MTech
    }
}
