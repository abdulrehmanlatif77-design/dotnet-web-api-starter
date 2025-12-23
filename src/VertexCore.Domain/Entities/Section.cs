namespace VertexCore.Domain.Entities
{
    /// <summary>
    /// Represents an academic section in the domain.
    /// </summary>
    public class Section : BaseEntity<Guid>
    {
        // SectionID is represented by the inherited `Id` property (Guid)

        public required string SectionNumber { get; set; }
        public required string Semester { get; set; }
        public int Year { get; set; }

        public string? RoomNumber { get; set; }

        // Date of the meeting (date-only semantics)
        public DateTime MeetingDay { get; set; }

        // Time of the meeting
        public TimeSpan MeetingTime { get; set; }

        // Navigation property to Course (required)
        public Course? Name { get; set; }

        // Navigation property to Instructor (optional)
        public Instructor? Instructor { get; set; }
    }
}
