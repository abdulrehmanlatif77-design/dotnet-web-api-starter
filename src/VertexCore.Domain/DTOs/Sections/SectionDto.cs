using System;

namespace VertexCore.Domain.Dtos
{
    public class SectionDto
    {
        public Guid Id { get; set; }
        public required string SectionNumber { get; set; }
        public required string Semester { get; set; }
        public int Year { get; set; }
        public string? RoomNumber { get; set; }
        public DateTime MeetingDay { get; set; }
        public TimeSpan MeetingTime { get; set; }
        public Guid? CourseId { get; set; }
        public Guid? InstructorId { get; set; }
    }
}
