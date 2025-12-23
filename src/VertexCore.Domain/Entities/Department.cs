namespace VertexCore.Domain.Entities
{
    /// <summary>
    /// Represents a department in the domain.
    /// </summary>
    public class Department : BaseEntity<Guid>
    {
        // DeptCode is represented by the inherited `Id` property (Guid)

        public required string Name { get; set; }
        public string? Location { get; set; }
        public string? PhoneNumber { get; set; }
        public decimal Budget { get; set; }

        // Foreign key referencing the Instructor who is the head of the department
        public Guid InstructorId { get; set; }

    }
}
