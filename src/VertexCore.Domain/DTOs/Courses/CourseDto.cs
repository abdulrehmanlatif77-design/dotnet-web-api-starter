using System;

namespace VertexCore.Domain.Dtos
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public int Credits { get; set; }
        public Guid? DepartmentId { get; set; }
    }
}
