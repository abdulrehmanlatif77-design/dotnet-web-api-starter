namespace VertexCore.Domain.Entities
{
    /// <summary>
    /// Represents a course in the domain.
    /// </summary>
    public class Course : BaseEntity<Guid>
    {
        // CourseID is represented by the inherited `Id` property (Guid)

        public required string Title { get; set; }
        public int Credits { get; set; }

        // Foreign key to Department
        public Guid? DepartmentId { get; set; }
        // Navigation property
        public Department? Department { get; set; }

        // Sections for this course
        public ICollection<Section>? Sections { get; set; }
    }
}
